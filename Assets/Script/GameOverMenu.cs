using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Menu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
