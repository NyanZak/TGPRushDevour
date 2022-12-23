using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorClose : MonoBehaviour
{
    [SerializeField] private Animator myElevator = null;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myElevator.Play("ElevatorClose", 0, 0f);
        }
    }
}
