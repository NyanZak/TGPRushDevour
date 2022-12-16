using UnityEngine;
public class MovingTrain : MonoBehaviour
{
    private GameObject trainInstance;
    public GameObject trainPrefab;
    public float speed = 10f;
    public float resetDelay = 15f;
    void Start()
    {       
        trainInstance = Instantiate(trainPrefab);
        trainInstance.transform.position = transform.position;
        Invoke("ResetTrainPosition", resetDelay);
    }
    void Update()
    {
        trainInstance.transform.position += transform.forward * speed * Time.deltaTime;
    }
    void ResetTrainPosition()
    {
        trainInstance.transform.position = transform.position;
    }
}