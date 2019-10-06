using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGuardMovement : MonoBehaviour
{
    // health
    public int health = 50;

    // movement
    public float speed;
    private Transform target;
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

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if(target.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = flipped;
        }
        if(target.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = !flipped;
        }
        }
        else {
            Destroy(gameObject);
        }
    }
}
