using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public float countdown = 2f;

    public Text waveCountdownText;

    public GameManager gameManager;

    private int waveIndex = 0;
    private int enemies = 0;


    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive > 0)
        {
            return;
        }

        if(waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        //Debug.Log("Wave Incoming");
        Wave wave = waves[waveIndex];
        EnemyBlueprint eb = enemies[enemyIndex];

        for (int a = 0; a < wave.waveCount; a++)
        {
            yield return new WaitForSeconds(1f / wave.waveRate);

            for (int i = 0; i < eb.enemyCount; i++)
            {
                SpawnEnemy(eb.enemy);
                yield return new WaitForSeconds(1f / eb.enemyRate);
            }
        }

        waveIndex++;
        PlayerStats.Rounds++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("LEVEL WON!");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject eb)
    {
        Instantiate(eb, spawnPoint.position, spawnPoint.rotation);
    }
}
