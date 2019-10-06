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
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        timeToShoot += Time.deltaTime;
        if (Input.GetKeyDown("space") && (timeToShoot >= 0.5f)) {
            Instantiate(projectile, groundCheck1.position, transform.rotation);
            timeToShoot = 0;
        }

        healthBar.value = health;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) {
            health -= 5;
            // Destroy(gameObject);
            // Instantiate(explosion, transform.position, Quaternion.identity);
            // Instantiate(explosionTwo, transform.position, Quaternion.identity);
        }
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        Debug.DrawRay(position, direction, Color.blue, distance);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
