using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] powerUpPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1, 5);
    }

    private void Spawn()
    {
        GameObject powerUp = Instantiate(powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)], transform);
        powerUp.transform.position += new Vector3(Random.Range(-6, 6), 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
