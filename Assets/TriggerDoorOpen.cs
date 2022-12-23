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
            myElevator.Play("ElevatorOpen", 0, 0f);
        }
    }
}
