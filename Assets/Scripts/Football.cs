using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Football : MonoBehaviour
{
    [SerializeField] private Transform BallStart;
    [SerializeField] AudioSource kick;
    [SerializeField] SpriteRenderer fire;
    [SerializeField] Sprite RoboSprite;
    [SerializeField] SpriteRenderer Renderer;
    private Rigidbody2D body;
    private Sprite FootballSprite;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        FootballSprite = Renderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetRoboSprite(bool isaktiv)
    {
        if (isaktiv)
        {
            Renderer.sprite = RoboSprite;
        }
        else
        {
            Renderer.sprite = FootballSprite;
        }
    }

    public void Reset()
    {
        transform.position = BallStart.position;
        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
    }

    public void Fireball(Transform target)
    {
        fire.enabled = true;
        body.velocity = (target.position - transform.position).normalized * 40;
        transform.up = transform.position - target.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //kick.PlayOneShot(kick.clip);
        kick.Play();
        fire.enabled = false;
    }

    public void RoboMovement(Vector3 direction)
    {
        body.velocity = direction * 5;
    }

    public void schwarz(int schwarz)
    {
        if(schwarz == 1)
        {
            transform.localPosition = transform.position + new Vector3(0, 0, -1);
        }
        if (schwarz == 2)
        {
            transform.localPosition = transform.position + new Vector3(0, 0, 1);
        }

    }

}
