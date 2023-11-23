using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]  bool useObjectPool = true;
    [SerializeField] PoolManager poolManager;
    [SerializeField] GameObject prefab;
    [SerializeField] int spawnCount = 1;
    [SerializeField] float spawnInterval = 0.1f;
    [SerializeField] Vector3 minspawnPosition = Vector3.zero;
    [SerializeField] Vector3 maxSpawnPosition = Vector3.zero;
    [SerializeField] float destroyWaitTime = 1f;

    WaitForSeconds spawnIntervalWait;

    void Start()
    {
        spawnIntervalWait = new WaitForSeconds(spawnInterval);

        StartCoroutine(nameof(SpawnTimer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTimer()
    {
        int i;
        while (true)
        {
            for(i = 0; i < spawnCount; i++)
            {
                Spawn(prefab);
            }

            yield return spawnIntervalWait;
        }
    }

    void Spawn (GameObject prefab)
    {
        Destroyer destroyer;
        Vector3 pos = new Vector3(Random.Range(minspawnPosition.x, maxSpawnPosition.x), Random.Range(minspawnPosition.y, maxSpawnPosition.y), Random.Range(minspawnPosition.z, maxSpawnPosition.z));

        if(useObjectPool)
        {
            destroyer = poolManager.GetGameObject(prefab, pos, Quaternion.identity).GetComponent<Destroyer>();
            destroyer.PoolManager = poolManager;
        }
        else
        {
            destroyer = Instantiate(prefab, pos, Quaternion.identity).GetComponent<Destroyer>();
        }

        if(destroyer != null)
        {
            destroyer.StartDestroyTimer(destroyWaitTime);
        }
    }
}
