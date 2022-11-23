using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class TurnPlayer : MonoBehaviour
{
    public GameObject Player;
    public Animator anim;
    bool turnChecking = false;
    public Canvas canvas;
    public GameObject[] directions;
    int noClick = 0;
    float pressTimer;
    bool pressing;
    [SerializeField] private InputActionReference actionReference;

    private void OnEnable()
    {
        actionReference.action.Enable();
    }

    private void OnDisable()
    {
        actionReference.action.Disable();
    }


    private void Awake()
    {
        canvas.gameObject.SetActive(false);
        pressing = false;
        if (!(actionReference.action.interactions.Contains("TapInteraction") && actionReference.action.interactions.Contains("HoldInteraction")))
        {
            return;
        }
    }
    private void Update()
    {
        actionReference.action.performed += context =>
        {
            if (context.interaction is TapInteraction)
            {
                Debug.Log("TAP");
                if (turnChecking == true)
                {
                        directions[noClick].SetActive(false);
                        noClick++;
                        Debug.Log("CLICK");

                        if ((noClick) >= directions.Length)
                        {
                            noClick = 0;
                        }
                        directions[noClick].SetActive(true);
                    }
                }
        //    else if (context.interaction is HoldInteraction)
            {
                Debug.Log("HOLD");




            }
        };



        //if (turnChecking == true)
        //{
        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        directions[noClick].SetActive(false);
        //        noClick++;
        //        Debug.Log("CLICK");

        //        if ((noClick) >= directions.Length)
        //        {
        //            noClick = 0;
        //        }
        //        directions[noClick].SetActive(true);
        //    }
        //    float fire = Input.GetAxis("Fire1");
        //    if (fire > 0)
        //    {
        //        pressTimer += Time.deltaTime;
        //        if (pressTimer >= 2)
        //        {
        //            Debug.Log("HOLD");
        //            if (noClick == 0)
        //            {
        //                GetComponent<BoxCollider>().enabled = false;
        //                canvas.gameObject.SetActive(false);
        //                TurnLeft();
        //            }
        //            if (noClick == 1)
        //            {
        //                GetComponent<BoxCollider>().enabled = false;
        //                canvas.gameObject.SetActive(false);
        //                TurnForward();
        //            }
        //            if (noClick == 2)
        //            {
        //                GetComponent<BoxCollider>().enabled = false;
        //                canvas.gameObject.SetActive(false);
        //                TurnRight();
        //            }
        //            if (noClick == 3)
        //            {
        //                GetComponent<BoxCollider>().enabled = false;
        //                canvas.gameObject.SetActive(false);
        //                TurnBack();
        //            }
        //            else
        //            {
        //                pressTimer = 0;
        //            }
        //        }
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        turnChecking = true;
        foreach (GameObject obj in directions)
        {
            obj.SetActive(false);
        }
        directions[0].SetActive(true);
        Player.GetComponent<movement>().enabled = false;
        anim.SetBool("walking", false);
        anim.SetBool("idling", true);
        canvas.gameObject.SetActive(true);
    }
    public void TurnLeft()
    {
        Player.transform.rotation = Quaternion.LookRotation(-transform.right);
        Player.GetComponent<movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
    }
    public void TurnRight()
    {
        Player.transform.rotation = Quaternion.LookRotation(transform.right);
        Player.GetComponent<movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
    }
    public void TurnForward()
    {
        Player.transform.rotation = Quaternion.LookRotation(transform.forward);
        Player.GetComponent<movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
    }
    public void TurnBack()
    {
        Player.transform.rotation = Quaternion.LookRotation(-transform.forward);
        Player.GetComponent<movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
    }
}