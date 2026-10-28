using System.Xml;
using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject Explosion;
    float ExplosionTime = 0.0f;
    float ExplosionTimeInterval = 0.05f;
    public float ExplosionTimer = 1.0f;
    bool isExploding = false;
    
    float xval = 0.05f;
    float yval = 0.05f;
    float zval = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Explosion = transform.GetChild(0).gameObject;
    }

    private void FixedUpdate()
    {
        if (isExploding == true)
        {
            ExplosionTime += Time.deltaTime;
        }
        if (ExplosionTime >= ExplosionTimer && isExploding == true)
        {
            Destroy(gameObject);
        }
        if (ExplosionTime < ExplosionTimer && isExploding == true && ExplosionTime >= ExplosionTimeInterval)
        {
            Explosion.transform.localScale = new Vector3(xval, yval, zval);
            xval += 0.01f;
            yval += 0.01f;
            zval += 0.01f;
            ExplosionTimeInterval += 0.1f;
        }
        Debug.Log(ExplosionTime);
        Debug.Log(ExplosionTimeInterval);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    void Explode()
    {
        Explosion.SetActive(true);
        isExploding = true;
    }
}
