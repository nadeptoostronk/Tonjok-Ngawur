using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Hentikan musik latar saat berpindah ke scene mapSelect
        if (SoundManager.instance != null)
        {
            SoundManager.instance.StopMusic();
        }

        SceneManager.LoadScene("mapSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        SceneManager.LoadScene("option");
    }
}
