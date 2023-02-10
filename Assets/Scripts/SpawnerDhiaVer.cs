using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDhiaVer : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] float range;
    private float waitTime = 5;
    private float numberOfEnemies = 1;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(10);
        while (true)
        {
            for(int i = 0; i < numberOfEnemies; i++)
            {
                SpawnEnemyInRRandomPos();
            }
            yield return new WaitForSeconds(waitTime);
            if (waitTime > 1)
            {
                waitTime -= (waitTime * 0.01f);
            }
            else if(numberOfEnemies < 11)
            {
                numberOfEnemies+=0.25f;
            }
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
