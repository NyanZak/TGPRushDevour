using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingTrain : MonoBehaviour
{
    public GameObject trainPrefab;
    GameObject train;
    public float speed;
    public Vector3 direction;
    void Start()
    {
        train = Instantiate(trainPrefab, Vector3.zero, Quaternion.identity);
    }
    void Update()
    {
        train.transform.Translate(direction * speed * Time.deltaTime);
    }
}