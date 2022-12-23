using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonMash1 : MonoBehaviour
{
    public GameObject Player;
    public Canvas canvas;
    public GameObject Model;
    public Animator anim;
    public string sceneName;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") ;
        {
            Debug.Log(other);
            Player.GetComponent<Movement>().enabled = false;
            transform.parent.GetComponent<ButtonMashBar1>().enabled = true;
            anim.SetBool("walking", false);
            canvas.enabled = true;
            anim.SetBool("idling", true);
        }
        
    }
    public void Complete()
    {
       GetComponent<BoxCollider>().enabled = false;
       Player.GetComponent<Movement>().enabled = true;
       transform.parent.GetComponent<ButtonMashBar1>().enabled = false;
       canvas.enabled = false;
       Model.SetActive(false);
       anim.SetBool("walking", true);
       anim.SetBool("idling", false);
    }

    public void Fail()
    {
        SceneManager.LoadScene(sceneName);
    }
}