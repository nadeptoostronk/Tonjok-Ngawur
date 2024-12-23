using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    None,
    Attack1,
    Attack2,
    Attack3,
    Attack4,
    Ulti
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation myAnim;

    private bool activateTimeToReset;
    private float defaultComboTimer = 0.5f;
    private float currentComboTimer;
    private ComboState currentComboState;

    [SerializeField]
    private GameObject Attacker1Point;
    [SerializeField]
    private GameObject Attacker2Point;
    [SerializeField]
    private GameObject UltiAttackerPoint;

    private void Awake()
    {
        myAnim = GetComponent<CharacterAnimation>();
    }

    void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.None;
    }

    void Update()
    {
        ComboAttack();
        ResetComboState();
    }

    void ComboAttack()
    {
        if (Input.GetButtonDown("Fire1")) // Ganti dengan input yang sesuai jika menggunakan kontroler
        {
            if (currentComboState == ComboState.Attack4 || currentComboState == ComboState.Ulti)
            {
                return;
            }

            currentComboState = (ComboState)((int)currentComboState + 1);
            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;

            switch (currentComboState)
            {
                case ComboState.Attack1:
                    myAnim.Attack1();
                    break;
                case ComboState.Attack2:
                    myAnim.Attack2();
                    break;
                case ComboState.Attack3:
                    myAnim.Attack1();
                    break;
                case ComboState.Attack4:
                    myAnim.Attack2();
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.K)) // Input untuk ulti
        {
            if (currentComboState == ComboState.Attack4 || currentComboState == ComboState.Ulti)
            {
                return;
            }

            currentComboState = ComboState.Ulti;
            activateTimeToReset = true;
            currentComboTimer = defaultComboTimer;

            myAnim.Ulti(); // Mainkan animasi ulti
        }
    }

    void ResetComboState()
    {
        if (activateTimeToReset)
        {
            currentComboTimer -= Time.deltaTime;

            if (currentComboTimer <= 0f)
            {
                currentComboState = ComboState.None;
                activateTimeToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }

    public void ActivateAttacker1()
    {
        Attacker1Point.SetActive(true);
    }

    public void ActivateAttacker2()
    {
        Attacker2Point.SetActive(true);
    }

    public void ActivateUltiAttacker()
    {
        UltiAttackerPoint.SetActive(true);
    }

    public void DeactivateAttacker1()
    {
        Attacker1Point.SetActive(false);
    }

    public void DeactivateAttacker2()
    {
        Attacker2Point.SetActive(false);
    }

    public void DeactivateUltiAttacker()
    {
        UltiAttackerPoint.SetActive(false);
    }

    public void DeactivateAllAttack()
    {
        Attacker1Point.SetActive(false);
        Attacker2Point.SetActive(false);
        UltiAttackerPoint.SetActive(false);
    }
}
