using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    private Player2Controller GetPlayer2;
    private Health myHealth;

    private BarStat healthBar;
    public GameManagerScript1 gameManager;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<CharacterAnimation>();
        myHealth = GetComponent<Health>();

        // Inisialisasi healthBar
        healthBar = new BarStat();

        // Cari objek health bar berdasarkan tag
        GameObject healthBarObject = GameObject.FindGameObjectWithTag("PlayerHealthBar");
        if (healthBarObject != null)
        {
            Debug.Log("Health Bar object found!");
            healthBar.bar = healthBarObject.GetComponent<BarScript>();
            healthBar.Initialize();
        }
        else
        {
            Debug.LogError("Health Bar object not found! Ensure the tag 'PlayerHealthBar' is correctly assigned.");
        }
    }

    void Start()
    {
        healthBar.MaxVal = myHealth.maxHealth;
        GetPlayer2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2Controller>();
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
        // Gunakan Input dari stik konsol untuk pergerakan
        float horizontal = Input.GetAxis("Horizontal");  // Horizontal movement (left-right)
        float vertical = Input.GetAxis("Vertical");      // Vertical movement (up-down)

        HandleMovement(horizontal, vertical);
        Flip(horizontal);
    }

    private void HandleMovement(float horizontal, float vertical)
    {
        if (isDie)
            return;

        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);

        if (vertical > 0 && isGrounded)
        {
            // Jika tombol pada stik konsol ditekan untuk lompat
            myRigidbody.AddForce(new Vector2(0, forceJump));
            myAnim.Jump(true);
            isJumping = true;
        }

        myAnim.Run(horizontal);  // Jalankan animasi berdasarkan pergerakan horizontal
    }

    private void Flip(float horizontal)
    {
        if (isDie)
            return;

        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void DeadChecker()
    {
        if (isDie)
            return;

        if (myHealth.health <= 0)
        {
            gameManager.gameOver();
            isDie = true;
            myAnim.Die(isDie);
        }
    }

    private void CheckUserInput()
    {
        if (isDie)
            return;

        // Gunakan kontroler stik untuk aksi pertahanan
        if (Input.GetButtonDown("Fire3"))  // Fire3 biasanya dikaitkan dengan tombol pada stik
        {
            isDefense = true;
            myAnim.Defense(isDefense);
        }

        if (Input.GetButtonUp("Fire3"))
        {
            isDefense = false;
            myAnim.Defense(isDefense);
        }

        // Deteksi tombol serangan pada kontroler (gunakan "Fire1" atau yang sesuai di pengaturan Input Manager)
        if (Input.GetButtonDown("Fire1"))  // Ganti dengan tombol serangan yang Anda pilih
        {
            myAnim.Attack1();  // Panggil animasi serangan
            // Tambahkan logika serangan lebih lanjut jika diperlukan (misalnya: memberikan damage ke lawan)
        }

        // Tambahkan lebih banyak kombinasi tombol untuk serangan jika perlu
        if (Input.GetButtonDown("Fire2"))  // Misalnya untuk serangan khusus atau ulti
        {
            myAnim.Ulti();  // Panggil animasi serangan ulti
            // Lakukan hal lainnya yang diperlukan (misalnya: memberikan damage tambahan)
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            myAnim.Jump(false);
            isGrounded = true;
            isJumping = false;
        }

        if (isDie)
            return;

        if (collision.tag == "Attacker" && !isDefense)
        {
            myAnim.Hurt();
            myHealth.health -= GetPlayer2.attackDemage;
        }
        if (collision.tag == "UltiAttack" && !isDefense)
        {
            myAnim.Hurt();
            myHealth.health -= GetPlayer2.ultiDemage;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
