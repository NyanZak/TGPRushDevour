using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    public Vector3 moveVector;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        rb.MovePosition(transform.position + transform.forward * moveSpeed);
        anim.SetBool("walking", true);
    }
}