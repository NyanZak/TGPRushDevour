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
                if (turnChecking == true)
                {
                        directions[noClick].SetActive(false);
                        noClick++;
                        if ((noClick) >= directions.Length)
                        {
                            noClick = 0;
                        }
                        directions[noClick].SetActive(true);
                    }
                }
          else if (context.interaction is HoldInteraction)
            {
                if (noClick == 0)
                {
                    GetComponent<BoxCollider>().isTrigger = false;
                    canvas.gameObject.SetActive(false);
                    TurnLeft();
                }
                if (noClick == 1)
                {
                    GetComponent<BoxCollider>().isTrigger = false;
                    canvas.gameObject.SetActive(false);
                    TurnForward();
                }
                if (noClick == 2)
                {
                    GetComponent<BoxCollider>().isTrigger = false;
                    canvas.gameObject.SetActive(false);
                    TurnRight();
                }
                if (noClick == 3)
                {
                    GetComponent<BoxCollider>().isTrigger = false;
                    canvas.gameObject.SetActive(false);
                    TurnBack();
                }
            }
        };
    }
    private void OnTriggerEnter(Collider other)
    {
        this.enabled = true;
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

    private void OnTriggerExit(Collider other)
    {
        this.enabled = false;
    }
    public void TurnLeft()
    {
        Player.transform.rotation = Quaternion.LookRotation(-transform.right);
        Player.GetComponent<movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
        GetComponent<BoxCollider>().isTrigger = false;
        StartCoroutine(ResetBox());
    }
    public void TurnRight()
    {
        Player.transform.rotation = Quaternion.LookRotation(transform.right);
        Player.GetComponent<movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
        StartCoroutine(ResetBox());
    }
    public void TurnForward()
    {
        Player.transform.rotation = Quaternion.LookRotation(transform.forward);
        Player.GetComponent<movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
        GetComponent<BoxCollider>().isTrigger = false;
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(ResetBox());
    }
    public void TurnBack()
    {
        Player.transform.rotation = Quaternion.LookRotation(-transform.forward);
        Player.GetComponent<movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
        StartCoroutine(ResetBox());
    }

    IEnumerator ResetBox()
    {
        Debug.Log("RE-ENABLE BOX COLLIDER");
        yield return new WaitForSeconds(0.5f);
        GetComponent<BoxCollider>().enabled = true;
    }
}