using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnDelay = 1f;
    public float Timer;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Timer <= 0)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            Timer = spawnDelay;
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }
}
