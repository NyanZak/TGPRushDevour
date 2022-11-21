using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayer : MonoBehaviour
{
    public GameObject Player;
    public Animator anim;
    public bool turnChecking = false;

    private void Update()
    {
        if (turnChecking == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                GetComponent<BoxCollider>().enabled = false;
                TurnRight();
            }
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<BoxCollider>().enabled = false;
                TurnLeft();
            }
            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<BoxCollider>().enabled = false;
                TurnForward();
            }
            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<BoxCollider>().enabled = false;
                TurnBack();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        turnChecking = true;
        Debug.Log("Player Entered");
        Player.GetComponent<movement>().enabled = false;
        anim.SetBool("walking", false);
        anim.SetBool("idling", true);
    }
    public void TurnLeft()
    {
        Debug.Log("Left");
        Player.transform.rotation = transform.rotation = Quaternion.LookRotation(-transform.right);
        Player.GetComponent<movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
    }
    public void TurnRight()
    {
        Debug.Log("Right");
        Player.transform.rotation = transform.rotation = Quaternion.LookRotation(transform.right);
        Player.GetComponent<movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
    }
     public void TurnForward()
     {
        Debug.Log("Forward");
        Player.transform.rotation = transform.rotation = Quaternion.LookRotation(transform.forward);
        Player.GetComponent<movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
    }
   public void TurnBack()
   {
        Debug.Log("Back");
        Player.transform.rotation = transform.rotation = Quaternion.LookRotation(-transform.forward);
        Player.GetComponent<movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
    }
}