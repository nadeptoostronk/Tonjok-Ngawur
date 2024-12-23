using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private CharacterAnimation myAnim;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float forceJump;

    private bool facingRight;
    private bool isJumping;
    private bool isGrounded;
    public bool isDefense;

    public float attackDemage;
    public float ultiDemage;
    public bool isDie;

    private PlayerController GetPlayer1;
    private Health myHealth;

    private BarStat healthBar;
    public GameManagerScript2 gameManager;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<CharacterAnimation>();
        myHealth = GetComponent<Health>();

        // Inisialisasi healthBar
        healthBar = new BarStat();

        // Cari objek health bar berdasarkan tag
        GameObject healthBarObject = GameObject.FindGameObjectWithTag("Enemyhealthbar");
        if (healthBarObject != null)
        {
            Debug.Log("Health Bar object found!");
            healthBar.bar = healthBarObject.GetComponent<BarScript>();
            healthBar.Initialize();
        }
        else
        {
            Debug.LogError("Health Bar object not found! Ensure the tag 'playerhealthbar' is correctly assigned.");
        }
    }

    void Start()
    {
        healthBar.MaxVal = myHealth.maxHealth;
        GetPlayer1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerController>();
        facingRight = true;
    }

    void Update()
    {

       // Perbarui health bar berdasarkan nilai health player
    healthBar.bar.Value = myHealth.health;

    // Debugging
    Debug.Log("Current Health: " + myHealth.health);
    Debug.Log("Health Bar Fill Amount: " + healthBar.bar.Value);
    CheckUserInput();
    DeadChecker();
    }

    private void FixedUpdate()
    {
        float horizontal2 = Input.GetAxis("Horizontal2");
        float vertical2 = Input.GetAxis("Vertical2"); // Gunakan input untuk Player 2
        HandleMovement(horizontal2, vertical2);
        Flip(horizontal2);
    }

    private void HandleMovement(float horizontal2, float vertical2)
    {
        if (isDie)
            return;

        myRigidbody.velocity = new Vector2(horizontal2 * movementSpeed, myRigidbody.velocity.y);
        if (vertical2 > 0 && isGrounded)
        {
            // Jika tombol pada stik konsol ditekan untuk lompat
            myRigidbody.AddForce(new Vector2(0, forceJump));
            myAnim.Jump(true);
            isJumping = true;
        }
        myAnim.Run(horizontal2);
    }

    private void Flip(float horizontal2)
    {
        if (isDie)
            return;

        if (horizontal2 < 0 && !facingRight || horizontal2 > 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void DeadChecker()
    {
        if (isDie)
            return;

        if (myHealth.health <= 0)
        {
            isDie = true;
            gameManager.gameOver();
            myAnim.Die(isDie);
        }
    }

    private void CheckUserInput()
    {
        if (isDie)
            return;

       // Gunakan kontroler stik untuk aksi pertahanan
        if (Input.GetButtonDown("Fire6"))  // Fire3 biasanya dikaitkan dengan tombol pada stik
        {
            isDefense = true;
            myAnim.Defense(isDefense);
        }

        if (Input.GetButtonUp("Fire6"))
        {
            isDefense = false;
            myAnim.Defense(isDefense);
        }

        // Deteksi tombol serangan pada kontroler (gunakan "Fire1" atau yang sesuai di pengaturan Input Manager)
        if (Input.GetButtonDown("Fire4"))  // Ganti dengan tombol serangan yang Anda pilih
        {
            myAnim.Attack1();  // Panggil animasi serangan
            // Tambahkan logika serangan lebih lanjut jika diperlukan (misalnya: memberikan damage ke lawan)
        }

        // Tambahkan lebih banyak kombinasi tombol untuk serangan jika perlu
        if (Input.GetButtonDown("Fire5"))  // Misalnya untuk serangan khusus atau ulti
        {
            myAnim.Ulti();  // Panggil animasi serangan ulti
            // Lakukan hal lainnya yang diperlukan (misalnya: memberikan damage tambahan)
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            myAnim.Jump(false);
            isGrounded = true;
            isJumping = false;
        }

        if (isDie)
            return;

        if (collision.CompareTag(Tags.Attack_Tag) && !isDefense)
        {
            myAnim.Hurt();
            myHealth.health -= GetPlayer1.attackDemage;
        }
        if (collision.CompareTag(Tags.Ulti_Tag) && !isDefense)
        {
            myAnim.Hurt();
            myHealth.health -= GetPlayer1.ultiDemage;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
