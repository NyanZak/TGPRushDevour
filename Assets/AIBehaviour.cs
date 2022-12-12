using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class AIBehaviour : MonoBehaviour
{
    public Transform aiTransform;
    public Transform Player;
    public float patrolSpeed;
    public float followSpeed;
    public float maxFollowingDistance;
    public Transform[] patrolPoints;
    private Vector3 destination;
    public float reachThreshold;
    Animator aiAnimator;

    void Start()
    {
        aiAnimator = GetComponent<Animator>();
        destination = patrolPoints[0].position;
        
    }
    void Update()
    {
        float distance = Vector3.Distance(aiTransform.position, Player.position);
        if (distance <= maxFollowingDistance)
        {
            aiAnimator.SetBool("IsMoving", true);
            destination = Player.position;
            aiTransform.position = Vector3.Lerp(aiTransform.position, destination, followSpeed * Time.deltaTime);
            aiTransform.LookAt(Player);
        }
        else
        {
            // If the player is out of range, go back to patrolling
            aiAnimator.SetBool("IsMoving", true);
            for (int i = 0; i < patrolPoints.Length; i++)
            {
                if (Vector3.Distance(aiTransform.position, patrolPoints[i].position) <= reachThreshold)
                {
                    if (i == patrolPoints.Length - 1)
                    {
                        destination = patrolPoints[0].position;
                        break;
                    }
                    else
                    {
                        destination = patrolPoints[i + 1].position;
                        break;
                    }
                }
            }

            // Check if the AI is not moving
            if (aiTransform.position == destination)
            {
                aiAnimator.SetBool("IsMoving", false);
            }
            else
            {
                aiTransform.position = Vector3.Lerp(aiTransform.position, destination, patrolSpeed * Time.deltaTime);
                aiTransform.LookAt(destination);
            }
        }
    }

}