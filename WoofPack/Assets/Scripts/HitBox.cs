using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Transform location;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (location == null) {
            Destroy(gameObject);
        }
        else {
        transform.position = location.position;
        }

    }
}
