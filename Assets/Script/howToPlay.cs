using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class howToPlay : MonoBehaviour
{
   public void next1(){
    SceneManager.LoadScene("inGame");
   }

   public void next2(){
        SceneManager.LoadScene("mario");
    }
}

