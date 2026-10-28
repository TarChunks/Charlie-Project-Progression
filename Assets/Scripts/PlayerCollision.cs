using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody playerrb;
    public PlayerMovement movement;
    public CoinSpawner spawner;

    private void Start()
    {
        movement.gameObject.GetComponent<PlayerMovement>();
        spawner.gameObject.GetComponent<CoinSpawner>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            movement.PlayerDie();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            int pos = other.gameObject.GetComponent<Coin>().position;
            spawner.ResetSpawn(pos);
            Destroy(other.gameObject);
        }
    }
}
