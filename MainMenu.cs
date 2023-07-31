using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Replace 1 with the correct build index of "Demo" scene.
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
