using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    // Health
    public int health = 100;
    public Slider healthBar;

    // Movement
    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck1;
    public LayerMask groundLayer;
    private bool isGrounded;
    private float distance;

    // Weapon
    public GameObject projectile;
    private float timeToShoot = 0.5f;
    public Transform projectileLocator;
    public GameObject[] projectiles;
    int currIndex = 0;

    //Animation
    public Animator animator;
    public bool isCorgi = true;
    private float transitionTime = 1;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = IsGrounded();
        
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            animator.SetBool("isWalking", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("isWalking", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("isWalking", true);
        }

        if(!Input.anyKey)
        {
            animator.SetTrigger("ToIdle");
        }

        transitionTime += Time.deltaTime;
        if(Input.GetKey(KeyCode.J) && (transitionTime >= 1) && (GetComponent<Rigidbody2D>().velocity.y == 0))
        {
            isCorgi = !isCorgi;
            animator.SetBool("isCorgi", isCorgi);
            transitionTime = 0;
            projectile = currIndex == 0 ? projectiles[1] : projectiles[0];
            currIndex = currIndex == 0 ? 1 : 0;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W)) {
            animator.SetBool("isWalking", false);
        }

        timeToShoot += Time.deltaTime;
        if (Input.GetKeyDown("space") && (timeToShoot >= 0.5f)) {
            Instantiate(projectile, projectileLocator.position, transform.rotation);
            timeToShoot = 0;
        }

        healthBar.value = health;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("lol");
        if (other.CompareTag("Enemy")) {
            health -= 10;
        }
        else if (other.CompareTag("Guard")) {
            Debug.Log("HIT!");
            health -= 5;
        }
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 3.0f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        Debug.DrawRay(position, direction, Color.blue, distance);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
