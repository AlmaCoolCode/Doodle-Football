using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Football : MonoBehaviour
{
    [SerializeField] private Transform BallStart;
    [SerializeField] AudioSource kick;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        transform.position = BallStart.position;
        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //kick.PlayOneShot(kick.clip);
        kick.Play();
    }
}
