using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject spawnObject;
    public CoinSpawner spawner;
    public int position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnObject = GameObject.Find("CoinManager");
        spawner = spawnObject.GetComponent<CoinSpawner>();
        position = spawner.coinPos;
    }
}
