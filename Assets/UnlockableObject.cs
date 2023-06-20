using UnityEngine;

public class UnlockableObject : MonoBehaviour
{
    public string playerPrefsKey = "objectState";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString(playerPrefsKey, "unlocked");
            Destroy(gameObject);
        }
    }
}