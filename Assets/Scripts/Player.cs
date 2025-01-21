using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(new Vector2(10, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(new Vector2(-10, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0, 100));
        }
    }
}
