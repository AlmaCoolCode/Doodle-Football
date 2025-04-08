using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1, 10);
    }

    private void Spawn()
    {
        GameObject powerUp = Instantiate(powerUpPrefab, transform);
        powerUp.transform.position += new Vector3(Random.Range(-10, 10), Random.Range(-3, 3), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
