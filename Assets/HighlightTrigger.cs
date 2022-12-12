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
    private Vector3 raycastDirection = Vector3.forward;
    public bool raycastEnabled = true;
    public Ray ray;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
        raycastDirection = Quaternion.AngleAxis(90, Vector3.up) * raycastDirection;
        }
        Vector3 rayPosition = transform.position;
        rayPosition.y += rayPositionY;
        rayPosition.z += rayPositionZ;
        Ray ray = new Ray(rayPosition, raycastDirection);
        this.ray = ray;
        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, raycastMask))
        {
            Debug.DrawRay(rayPosition, raycastDirection * raycastDistance, Color.blue);
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