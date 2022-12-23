using Unity.VisualScripting;
using UnityEngine;
public class HighlightTrigger : MonoBehaviour
{
    public float raycastDistance = 10f;
    public float highlightDistance = 5f;
    public LayerMask raycastMask;
    private Collider nearestTriggerCollider;
    public GameObject highlightIndicatorPrefab;
    public GameObject player;
    public float rayPositionY, rayPositionZ;
    private GameObject highlightIndicatorInstance;
    public Vector3 raycastDirection;
    public bool raycastEnabled = true;
    public Ray ray;
    private void Start()
    {
        highlightIndicatorPrefab.SetActive(false);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 9)
        {
            highlightIndicatorPrefab.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        highlightIndicatorPrefab.SetActive(false);
    }
    void Update()
    {
        Vector3 rayPosition = transform.position;
        rayPosition.y += rayPositionY;
        rayPosition.z += rayPositionZ;
        Ray ray = new Ray(rayPosition, raycastDirection);
        this.ray = ray;
        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, raycastMask))
        {
            if (hit.collider.isTrigger)
            {
                nearestTriggerCollider = hit.collider;
            }
        }
        if (nearestTriggerCollider != null && Vector3.Distance(rayPosition, nearestTriggerCollider.transform.position) <= highlightDistance)
        {
            if (highlightIndicatorInstance == null)
            {
                highlightIndicatorInstance = Instantiate(highlightIndicatorPrefab, nearestTriggerCollider.transform.position, Quaternion.identity);
                highlightIndicatorInstance.transform.parent = transform;
            }
            else
            {
                highlightIndicatorInstance.transform.position = nearestTriggerCollider.transform.position;
            }
        }
    }
}