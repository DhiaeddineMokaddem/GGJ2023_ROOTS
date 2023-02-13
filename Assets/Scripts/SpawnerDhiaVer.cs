using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpawnerDhiaVer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI spawnerText;
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] float range;
    private float waitTime = 5;
    private float numberOfEnemies = 1;
    public float timer;
    private bool gameStarts;
    public float pourcentage;
    private IEnumerator Start()
    {
        timer = waitTime;
        yield return new WaitForSeconds(30);
        gameStarts= true;
        //while (true)
        //{
        //    for(int i = 0; i < numberOfEnemies; i++)
        //    {
        //        SpawnEnemyInRRandomPos();
        //    }
        //    yield return new WaitForSeconds(waitTime);
        //    if (waitTime > 1)
        //    {
        //        waitTime -= (waitTime * 0.01f);
        //    }
        //    else if(numberOfEnemies < 11)
        //    {
        //        numberOfEnemies+=0.25f;
        //    }
        //}
    }
    private void Update()
    {
        if (!gameStarts)
        {
            return;
        }
        spawnerText.text = Mathf.Floor(numberOfEnemies) + " enemies will spawn in " + timer.ToString("0.0") + " s";
        //spawner
        if (timer <= 0)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                SpawnEnemyInRRandomPos();
            }

            if (waitTime > 1)
            {
                waitTime *= pourcentage;
            }
            else if(numberOfEnemies < 4)
            {
                numberOfEnemies += 0.2f;
            }      
            timer = waitTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    private void SpawnEnemy(Vector3 location)
    {
        Instantiate(enemyPrefab, location, Quaternion.identity);
    }
    public void SpawnEnemyInRRandomPos()
    {
        Vector3 randomPos = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized * range;
        randomPos = new Vector3(randomPos.x, transform.position.y, randomPos.z);
        SpawnEnemy(randomPos);
    }
}
