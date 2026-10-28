using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject Star;
    public GameObject TimerStar;
    float starTime = 0.0f;
    float starTimerTime = 0.0f;
    public float starCooldownTime = 2.5f;
    bool starTimerIsSpawned = false;
    public float spawnHeight = 10.0f;
    Vector3 spawnPos;
    float xpos;
    float zpos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        starTime += Time.deltaTime;
        starTimerTime += Time.deltaTime;
        if (starTime >= starCooldownTime)
        {
            StarSpawn();
            starTime = 0.0f;
        }
    }

    void StarSpawn()
    {
        xpos = Random.Range(-10.0f, 10.0f);
        zpos = Random.Range(-10.0f, 10.0f);
        spawnPos = new Vector3(xpos, spawnHeight, zpos);
        Instantiate(Star, spawnPos, Quaternion.Euler(0,0,0));
    }
}
