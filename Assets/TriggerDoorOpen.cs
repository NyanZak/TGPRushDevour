using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorOpen : MonoBehaviour
{
    [SerializeField] private Animator myElevator = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 collisionNormal = other.ClosestPointOnBounds(transform.position) - transform.position;
            if (collisionNormal.y > 0)
            {
                // Player entered from the top
                Debug.Log("Player entered from the top");
            }
            else
            {
                // Player entered from the bottom
                Debug.Log("Player entered from the bottom");
                myElevator.Play("ElevatorOpen", 0, 0f);
            }
        }
    }
}
