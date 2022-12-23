using UnityEngine;
public class ButtonMash : MonoBehaviour
{
    public GameObject Player;
    public Canvas canvas;
    public GameObject Model;
    public Animator anim;
    public GameObject dialogue;

    private void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<Movement>().enabled = false;
        transform.parent.GetComponent<ButtonMashBar>().enabled = true;
        anim.SetBool("walking", false);
        canvas.enabled = true;
        anim.SetBool("idling", true);
        dialogue.SetActive(true);
    }
    public void Complete()
    {
       GetComponent<BoxCollider>().enabled = false;
       Player.GetComponent<Movement>().enabled = true;
       transform.parent.GetComponent<ButtonMashBar>().enabled = false;
       canvas.enabled = false;
       Model.SetActive(false);
       anim.SetBool("walking", true);
       anim.SetBool("idling", false);
        dialogue.SetActive(false);
    }
}