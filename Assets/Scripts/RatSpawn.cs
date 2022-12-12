using UnityEngine;
public class RatSpawn : MonoBehaviour
{
    public Transform Zombie, Player;
    public GameObject Rat;
    public float distance;
    bool isCreated;
    private void Update()
    {
        if (Vector3.Distance(Zombie.position, Player.position) <=distance)
        {
            if (!isCreated)
            {
               GameObject RatClone = Instantiate(Rat, transform.position, Quaternion.identity);
               RatClone.transform.LookAt(Player.transform.position);
               isCreated = true;
            }            
        }
    }
}