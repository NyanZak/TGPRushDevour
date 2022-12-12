using UnityEngine;
public class HideMouse : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}