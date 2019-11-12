using System;
using System.Collections;
using UnityEngine;
public class SceneManager : MonoBehaviour
{
    public void GoToToneGenerator()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
