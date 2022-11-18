using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private Transform PlayerTransform;
    private NavMeshAgent NavMeshAgent;
    bool isMoving;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        NavMeshAgent = GetComponent<NavMeshAgent>();
        PlayerTransform = player.transform;
    }
    void  Update()
    {
       if (!isMoving)
        {
            NavMeshAgent.destination = PlayerTransform.position;
            isMoving = true;
        }
    }
}