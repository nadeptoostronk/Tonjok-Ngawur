using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BarStat 
{

    [SerializeField]
    public BarScript bar;
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float currentVal;

    public float CurrentVal {
        get {
            return currentVal;
        }
        set {
            this.currentVal = value;
            bar.Value = currentVal;
        }
    }

    public float MaxVal {
        get {
            return maxVal;
        }
        set {
            this.maxVal = value;
            bar.MaxVal = value;
        }
    }

    public float health;
    public float maxHealth;

    void Start(){
        maxHealth = health  ;
    }

    public void Initialize() {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }
}
