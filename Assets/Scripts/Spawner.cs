using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] Spawners;
    
    public float WaitForGameToStart = 10f; // a changable 
    public float SpawnedRate = 1f; // spawn rate of enemies
    public float Timer; // cooldown between each enemy spawn



    Transform parentTransform;
    Transform[] childTransforms;

    private void Start()
    {
        parentTransform = gameObject.GetComponent<Transform>();
        childTransforms = parentTransform.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {

        if (WaitForGameToStart >= 0)
        {
            WaitForGameToStart -= Time.deltaTime;
        }
        else
        {
            if (Timer <= 0)
            {
                Instantiate(prefab, childTransforms[Random.Range(0,transform.childCount)].transform.position, Quaternion.identity); // 
                Timer = SpawnedRate;
            }
            else
            {
                Timer -= Time.deltaTime;
            }
        }

        //create an array of children gameobjets


    }
}
