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
    [SerializeField] public int playerNumber = 1;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform playerStart;
    [SerializeField] public Transform enemyGoal;
    [SerializeField] public Goal ownGoal;
    [SerializeField] public Player enemy;
    [SerializeField] GameObject iceCube;
    [SerializeField] public int seitenWechsel = -1;
    private bool isFrozen = false;
    private bool hasRoboball = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal" + playerNumber), Input.GetAxis("Vertical" + playerNumber));
        if (hasRoboball)
        {
            GameManager.Instance.football.RoboMovement(input);
            return;
        }
        if (isFrozen) return;
        float ySpeed = rigidbody.velocity.y;
        if (Input.GetButton("Jump" + playerNumber) && IsOnGround())
        {
            ySpeed = jumpspeed;
        }
        rigidbody.velocity = new Vector2(movespeed * input.x, ySpeed);
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

    public void SeitenWechsel()
    {

    }

    public void Roboball()
    {
        StartCoroutine(RoboballCoroutine(3));
    }

    public void Freeze()
    {
        StartCoroutine(FreezeCoroutine(3));
    }

    public void Grow()
    {
        StartCoroutine(GrowCoroutine(2));
    }
    IEnumerator FreezeCoroutine(float freezeTime)
    {
        iceCube.SetActive(true);
        isFrozen = true;
        yield return new WaitForSeconds(freezeTime);
        isFrozen = false;
        iceCube.SetActive(false);
    }

    IEnumerator GrowCoroutine(float growTime)
    {
        transform.localScale = transform.localScale * 2;
        yield return new WaitForSeconds(growTime);
        transform.localScale = transform.localScale * 0.5f;
    }

    IEnumerator RoboballCoroutine(float roboballTime)
    {
        hasRoboball = true;
        GameManager.Instance.football.SetRoboSprite(true);
        yield return new WaitForSeconds(roboballTime);
        GameManager.Instance.football.SetRoboSprite(false);
        hasRoboball = false;
    }
}
