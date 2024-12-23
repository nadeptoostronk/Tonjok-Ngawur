using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [SerializeField]
    private float fillAmount; // Nilai pengisian bar
    [SerializeField]
    private float lerpSpeed; // Kecepatan animasi bar
    [SerializeField]
    private Image content; // Objek Image yang merepresentasikan bar

    public float MaxVal { get; set; }

    public float Value
    {
        get
        {
            return fillAmount * MaxVal; // Kembalikan nilai actual
        }
        set
        {
            fillAmount = Map(value, 0, MaxVal, 0, 1);
        }
    }
    
    public float health;
    public float maxHealth;

    void Start(){
        maxHealth = health  ;
    }

    void Update()
    {
        HandleBar();
    }

    void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
