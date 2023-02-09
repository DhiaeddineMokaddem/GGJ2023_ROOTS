using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDhiaVer : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] float range;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            Vector3 randomPos = new Vector3(Random.Range(-1f,1f),0, Random.Range(-1f, 1f)).normalized * range;
            randomPos= new Vector3(randomPos.x,transform.position.y, randomPos.z);
            SpawnEnemy(randomPos);
            yield return new WaitForSeconds(1/(GameManager.instance.timePassed/10));
        }
    }
    private void SpawnEnemy(Vector3 location)
    {
        Instantiate(enemyPrefab, location, Quaternion.identity);
    }
}
