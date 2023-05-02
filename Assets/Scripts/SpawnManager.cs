using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 5;
    private float spawnPosZ = 5;
    public float interval;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //randomly generate enemy index and spawn position
            
        }
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX) + transform.position.x, 0, spawnPosZ + transform.position.z);
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], spawnPos,
                enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
}
