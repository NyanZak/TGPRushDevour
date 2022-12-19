using UnityEngine;
using Cinemachine;
public class ChangeFOV : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    void Update()
    {
        vcam.m_Lens.FieldOfView = GameManager.instance.cameraFOV;
    }
}