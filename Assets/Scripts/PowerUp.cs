using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    Fire = 0,
    Ice = 1,
    Grow = 2
}

public class PowerUp : MonoBehaviour
{
    [SerializeField] PowerUpType powerUpType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            switch (powerUpType)
            {
                case PowerUpType.Fire:
                    GameManager.Instance.football.Fireball(player.enemyGoal);
                    break;
                case PowerUpType.Ice:
                    player.enemy.Freeze();
                    break;
                case PowerUpType.Grow:
                    player.Grow();
                    break;
                default:
                    break;
            }
           
            Destroy(gameObject);
        }
        
    }
}
