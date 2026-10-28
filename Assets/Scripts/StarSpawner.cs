using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject Star;
    public GameObject TimerStar;
    public GameObject PowerUp;
    float starTime = 0.0f;
    float starTimerTime = 0.0f;
    float powerUpTimerTime = 0.0f;
    public float starCooldownTime = 2.5f;
    public float starTimerCooldownTime = 30.0f;
    public float powerUpTime = 0.0f;
    bool starTimerIsSpawned = false;
    bool powerUpIsSpawned = false;
    public float spawnHeight = 10.0f;
    public float powerUpSpawnHeight = 2.0f;
    Vector3 spawnPos;
    Vector3 timerSpawnPos = new Vector3(0,2,0);
    float xpos;
    float zpos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerUpTime = Random.Range(10, 30);
    }

    // Update is called once per frame
    void Update()
    {
        starTime += Time.deltaTime;
        starTimerTime += Time.deltaTime;
        powerUpTimerTime += Time.deltaTime;
        if (starTime >= starCooldownTime)
        {
            StarSpawn();
            starTime = 0.0f;
        }
        if (starTimerTime >= starTimerCooldownTime && starTimerIsSpawned == false)
        {
            StarTimerSpawn();
        }

        if (powerUpTimerTime >= powerUpTime && powerUpIsSpawned == false)
        {
            PowerUpSpawn();
        }
    }

    void StarSpawn()
    {
        xpos = Random.Range(-10.0f, 10.0f);
        zpos = Random.Range(-10.0f, 10.0f);
        spawnPos = new Vector3(xpos, spawnHeight, zpos);
        Instantiate(Star, spawnPos, Quaternion.Euler(0,0,0));
    }

    void StarTimerSpawn()
    {
        Instantiate(TimerStar, timerSpawnPos, Quaternion.Euler(90,0,0));
        starTimerIsSpawned = true;
    }

    void PowerUpSpawn()
    {
        xpos = Random.Range(-10.0f, 10.0f);
        zpos = Random.Range(-10.0f, 10.0f);
        spawnPos = new Vector3(xpos,powerUpSpawnHeight, zpos);
        Instantiate(PowerUp, spawnPos, Quaternion.Euler(0, 0, 0));
        powerUpIsSpawned = true;
    }
}
