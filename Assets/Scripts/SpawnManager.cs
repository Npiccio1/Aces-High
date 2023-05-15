using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 5;
    private float spawnPosZ = 5;
    public float interval;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;
    private int score;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
        score = 0;
        UpdateScore(0);

        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //randomly generate enemy index and spawn position
            
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
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
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnEnemy());
        UpdateScore(0);

        //titleScreen.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
