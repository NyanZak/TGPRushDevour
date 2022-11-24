using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class RatSpawn : MonoBehaviour
{
    public Transform Zombie;
    public Transform Player;
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