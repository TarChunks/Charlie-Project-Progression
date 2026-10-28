using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject spawnObject;
    public CoinSpawner spawner;
    public int position;
    public Vector3 spin = new Vector3(0, 1, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnObject = GameObject.Find("CoinManager");
        spawner = spawnObject.GetComponent<CoinSpawner>();
        position = spawner.coinPos;
    }

    void FixedUpdate()
    {
        transform.Rotate(spin);

    }
}
