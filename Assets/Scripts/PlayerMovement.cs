using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

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

    //sets position of x-zpos to the current position of the object
    void Start()
    {
        playerrb = GetComponent<Rigidbody>();
        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;
    }

    //checks if keys are held
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

    //applies the final force
    void FixedUpdate()
    {
        playerrb.AddForce(new Vector3(xforce, 0, zforce), ForceMode.Force);
        xforce = 0.0f;
        zforce = 0.0f;
    }

    public void PlayerDie()
    {
        Destroy(gameObject);
        Time.timeScale = 0.0f;
    }
}
