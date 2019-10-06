using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaProjectile : MonoBehaviour
{

    public int damage = 10;
    public float speed;
    public float life = 1;

    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;
        if (life > 2) {
            Destroy(gameObject);
        }

    }
        private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the boss some damage + spawn particle effects + screen shake
        if (other.CompareTag("Player")) {
            other.GetComponent<PlayerMovement>().health -= damage;
            Destroy(gameObject);
        }
    }
}
