using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    // health
    public int health = 100;
    public Slider healthBar;

    // movement
    public float speed;
    private Transform target;
    public GameObject teslaLocation;
    public GameObject skyTesla;
    private float actionTime = 0;
    public bool flipped = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // call falling tesla
        if (health > 0) {
        actionTime += Time.deltaTime;
        if (actionTime > 5) {
            Instantiate(skyTesla, teslaLocation.GetComponent<Transform>().position, transform.rotation);
            actionTime = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if(target.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = flipped;
        }
        if(target.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = !flipped;
        }
        healthBar.value = health;
        }
    }
}
