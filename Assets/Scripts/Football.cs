using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
public class Football : MonoBehaviour
{
    [SerializeField] private Transform BallStart;
    //[SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject roboball;
    [SerializeField] AudioSource kick;
    [SerializeField] SpriteRenderer fire;
    [SerializeField] Sprite RoboSprite;
    [SerializeField] SpriteRenderer Renderer;
    //[SerializeField] PhysicsMaterial2D ballWeight;
    //private float originalGravity;
    //private float originalBounciness;
    //private float originalFriction;
    private Rigidbody2D body;
    private Sprite FootballSprite;
    //private bool isBlau = false;
    //private Coroutine blauCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        FootballSprite = Renderer.sprite;
        //originalGravity = rb.gravityScale;
        //originalBounciness = ballWeight.bounciness;
        //originalFriction = ballWeight.friction;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetRoboSprite(bool isaktiv)
    {
        if (isaktiv)
        {
            roboball.SetActive(true);
        }
        else
        {
            roboball.SetActive(false);
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

    //public void JumpPowerUp()
    //{
        //if (blauCoroutine != null)
        //{
            //StopCoroutine(blauCoroutine);
            //blauCoroutine = null;
            //isBlau = false;
            //ballWeight.bounciness = originalBounciness;
            //ballWeight.friction = originalFriction;
            //rb.gravityScale = originalGravity;
        //}

        //if (!isBlau)
        //{
            //originalGravity = rb.gravityScale;
        //}
        //blauCoroutine = StartCoroutine(Blau());
    //}
    //private IEnumerator Blau()
    //{
        //if (isBlau)
        //{
            //yield break;
        //}
        //isBlau = true;
        //ballWeight.bounciness = originalBounciness + 0.4f;
        //ballWeight.friction = originalFriction * 0.5f;
        //rb.gravityScale = originalGravity - 0.3f;
        //yield return new WaitForSeconds(10);
        //ballWeight.bounciness = originalBounciness;
        //ballWeight.friction = originalFriction;
        //rb.gravityScale = originalGravity;
        //isBlau = false;
    //}
}
