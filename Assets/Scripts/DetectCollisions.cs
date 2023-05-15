using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private SpawnManager spawnManager; 
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(gameObject.CompareTag("Player"))
        {
            spawnManager.GameOver();
        }
      
        spawnManager.UpdateScore(5);
        Destroy(other.gameObject);
        
    }
}
