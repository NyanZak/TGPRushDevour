using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonMash : MonoBehaviour
{
    public GameObject Player;
    public Canvas canvas;
    public GameObject Model;
    public Animator anim;
    public Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<movement>().enabled = false;
        transform.parent.GetComponent<ButtonMashBar>().enabled = true;
        anim.SetBool("walking", false);
        canvas.enabled = true;
        anim.SetBool("idling", true);
    }
    public void Complete()
    {
       GetComponent<BoxCollider>().enabled = false;
       Player.GetComponent<movement>().enabled = true;
       transform.parent.GetComponent<ButtonMashBar>().enabled = false;
       canvas.enabled = false;
       Model.SetActive(false);
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
    }
}