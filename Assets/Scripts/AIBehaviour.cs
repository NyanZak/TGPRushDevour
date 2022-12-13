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
    private int currentPatrolPointIndex = 0;
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
            aiAnimator.SetBool("IsMoving", true);
            destination = patrolPoints[currentPatrolPointIndex].position;

            if (Vector3.Distance(aiTransform.position, destination) < reachThreshold)
            {
                currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
            }
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
