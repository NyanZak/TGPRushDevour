using UnityEngine;
public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    public Vector3 moveVector;
    private Animator anim;
    public float stepRate = 0.5f;
    public float stepCoolDown;
    private float minPitch = 0.90f;
    private float maxPitch = 1.10f;
    public AudioSource audioSource;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        rb.MovePosition(transform.position + transform.forward * moveSpeed);
        anim.SetBool("walking", true);
        stepCoolDown -= Time.deltaTime;
        if (stepCoolDown < 0f)
        {
           audioSource.pitch = (Random.Range(minPitch, maxPitch));
           audioSource.Play();
           stepCoolDown = stepRate;
        }
    }
}