using NUnit.Framework;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] SpawnPoints = new GameObject[4];
    public bool[] SpawnToggles = new bool[4];

    public GameObject coin;
    public int coinCap = 4;
    int coinCount = 0;
    public float spawnTime = 5.0f;
    float timeTime = 0.0f;
    bool SpawnCoinLoop = false;

    public int coinPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        timeTime += Time.deltaTime;

        if (coinCount == 0)
        {
            SpawnCoin();
            timeTime = 0.0f;
        }
        
        if (coinCount == 0)
        {
            SpawnCoin();
            timeTime = 0.0f;
        }

        if (timeTime > spawnTime && coinCount < coinCap)
        {
            SpawnCoin();
            timeTime = 0.0f;
        }

        else if (timeTime > spawnTime && coinCount >= coinCap)
        {
            timeTime = 0.0f;
        }
    }

    void SpawnCoin()
    {
        Debug.Log(timeTime);
        int i = 0;
        while (SpawnCoinLoop == false)
        {
            int j = Random.Range(0, 4);
            if (SpawnToggles[j] == false)
            {
                i = j;
                SpawnCoinLoop = true;
            }
        }
        SpawnCoinLoop = false;
        Instantiate(coin, SpawnPoints[i].transform.position, SpawnPoints[i].transform.rotation);
        Debug.Log(SpawnPoints[i].transform.position);
        Debug.Log(SpawnPoints[i].gameObject.name);
        coinPos = i;
        SpawnToggles[i] = true;
        coinCount++;
    }

    public void ResetSpawn(int i)
    {
        SpawnToggles[i] = false;
        coinCount--;
    }
}
