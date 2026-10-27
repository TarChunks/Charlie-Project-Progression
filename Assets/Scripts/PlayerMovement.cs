using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerrb;
    public float playerSpeed = 1.0f;
    float xPos;
    float yPos;
    float zPos;
    bool vertMovement = false;
    bool horzMovement = false;
    float xforce = 0.0f;
    float zforce = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerrb = GetComponent<Rigidbody>();
        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.dKey.isPressed)
        {
            xforce = playerSpeed;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            xforce = -playerSpeed;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            zforce = playerSpeed;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            zforce = -playerSpeed;
        }
    }

    private void FixedUpdate()
    {
        playerrb.AddForce(new Vector3(xforce, 0, zforce), ForceMode.Force);
        xforce = 0.0f;
        zforce = 0.0f;
    }
}
