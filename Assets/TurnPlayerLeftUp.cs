using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
public class TurnPlayerLeftUp : MonoBehaviour
{
    public GameObject Player;
    public Animator anim;
    bool turnChecking = false;
    public Canvas canvas;
    public GameObject[] directions;
    public static int noClick = 0;
    [SerializeField] private InputActionReference actionReference;
    private Vector3 rayDirection;
    public enum Direction
    {
        Left,
        Forward
    }
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
            if (turnChecking == true)
            {
                if (context.interaction is TapInteraction)
                {
                    directions[noClick].SetActive(false);
                    noClick++;
                    if (noClick == 0)
                    {
                        rayDirection = -transform.right;
                    }
                    if (noClick == 1)
                    {
                        rayDirection = transform.forward;
                    }
                    if ((noClick) >= directions.Length)
                    {
                        noClick = 0;
                    }
                    directions[noClick].SetActive(true);
                }
                if (context.interaction is HoldInteraction)
                {
                    {
                        switch (noClick)
                        {
                            case 0:
                                GetComponent<BoxCollider>().enabled = false;
                                canvas.gameObject.SetActive(false);
                                Turn(Direction.Left);
                                break;
                            case 1:
                                GetComponent<BoxCollider>().enabled = false;
                                canvas.gameObject.SetActive(false);
                                Turn(Direction.Forward);
                                break;
                        }
                    }
                }
            }
        };
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.enabled = true;
            turnChecking = true;
            GetComponent<BoxCollider>().enabled = false;
            foreach (GameObject obj in directions)
            {
                obj.SetActive(false);
            }
            directions[0].SetActive(true);
            Player.GetComponent<Movement>().enabled = false;
            anim.SetBool("walking", false);
            anim.SetBool("idling", true);
            canvas.gameObject.SetActive(true);
            noClick = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            this.enabled = false; 
        }    
    }
    public void Turn(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                Player.transform.rotation = Quaternion.LookRotation(-transform.right);
                break;
            case Direction.Forward:
                Player.transform.rotation = Quaternion.LookRotation(transform.forward);
                break;
        }
        Player.GetComponent<Movement>().enabled = true;
        anim.SetBool("walking", true);
        anim.SetBool("idling", false);
        turnChecking = false;
        StartCoroutine(ResetBox());
    }
        IEnumerator ResetBox()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<BoxCollider>().enabled = true;
    }
}