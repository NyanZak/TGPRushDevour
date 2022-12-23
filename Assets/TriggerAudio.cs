using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerAudio : MonoBehaviour
{
    [SerializeField] private Animator myElevator = null;
    public GameObject Player;
    public GameObject fadeCanvas;
    public float delay = 8f;
    public string sceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 collisionNormal = other.ClosestPointOnBounds(transform.position) - transform.position;
            if (collisionNormal.y > 0)
            {
                // Player entered from the top
                Debug.Log("Player entered from the top");
                

            }
            else
            {
                // Player entered from the bottom
                Debug.Log("Player entered from the bottom");
                FindObjectOfType<AudioManager>().Play("Lift");
                myElevator.Play("ElevatorClose", 0, 0f);
                Player.GetComponent<Movement>().enabled = false;
                fadeCanvas.SetActive(true);
                Invoke("SwitchScene", delay);
            }

        }
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
