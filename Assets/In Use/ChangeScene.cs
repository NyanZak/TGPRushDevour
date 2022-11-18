using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void changelevel(string scenename)
    {
        Application.LoadLevel(scenename);
    }
}
