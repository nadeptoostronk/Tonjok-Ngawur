using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mapSelect : MonoBehaviour
{
    
   public void map1(){
    SceneManager.LoadScene("how to play1");
   }

   public void menu(){
    SceneManager.LoadScene("Menu");
   }

   public void map2(){
        SceneManager.LoadScene("how to play2");
    }
}
