using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] PoolManager poolManager;

    [SerializeField] float interval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_shot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator _shot()
    {
        while (true)
        {
            poolManager.Launch(transform.position);
            yield return new WaitForSeconds(interval);
        }
    }
}
