using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage;
    public float speed;
    public float life = 1;

    Vector2 dir;
    SpriteRenderer player;

    private SpriteRenderer projectile;
    public bool projectileDir = false;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        dir = player.flipX ? Vector2.right : Vector2.left;
        projectile = GetComponent<SpriteRenderer>();
        projectile.flipX = player.flipX ? projectileDir : !projectileDir;
    }

    private void Update()
    {   
        transform.Translate(dir * speed * Time.deltaTime);
        life += Time.deltaTime;
        if (life > 2) {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the boss some damage + spawn particle effects + screen shake
        if (other.CompareTag("Enemy")) {
            other.GetComponent<EnemyMovement>().health -= damage;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Guard")) {
            other.GetComponent<EnemyGuardMovement>().health -= damage;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            Destroy(gameObject);
        }
    }
}
