using UnityEngine;

public class StarTimer : MonoBehaviour
{
    public GameObject player;
    public float starSpeed = 0.05f;
    public Vector3 PlayerPos = new Vector3 (0, 0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, starSpeed);
    }
}
