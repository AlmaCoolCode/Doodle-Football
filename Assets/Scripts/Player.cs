using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float jumpspeed = 10;
    [SerializeField] float movespeed = 10;
    [SerializeField] int playerNumber = 1;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform playerStart;
    [SerializeField] public Transform enemyGoal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ySpeed = rigidbody.velocity.y;
        if (Input.GetButton("Jump" + playerNumber) && IsOnGround())
        {
            ySpeed = jumpspeed;
        }
        rigidbody.velocity = new Vector2(movespeed * Input.GetAxis("Horizontal" + playerNumber), ySpeed);
    }
    private bool IsOnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f);
        return hit.collider != null;
    }

    public void Reset()
    {
        transform.position = playerStart.position;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
    }
}
