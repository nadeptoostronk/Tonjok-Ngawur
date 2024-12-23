using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript1 : MonoBehaviour
{
    public GameObject gameOverUI;


     public void gameOver(){
        gameOverUI.SetActive(true);
    }
}
