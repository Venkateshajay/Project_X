using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManagerTemp : MonoBehaviour
{   public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ReloadScene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
