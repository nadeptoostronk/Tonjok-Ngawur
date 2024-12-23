using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;

    void Start(){
        maxHealth = health  ;
    }

    private void Awake()
    {
        health = maxHealth;
        
    }
}
