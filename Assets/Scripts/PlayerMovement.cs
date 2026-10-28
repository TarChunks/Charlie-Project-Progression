using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

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

    //Lighting
    //public Shader Shader1;
    //public Shader Shader2;
    //public Shader Shader3;
    //public Shader Shader4;
    public Material Material1;
    public Material Material2;
    public Material Material3;
    public Material Material4;
    public Material Material5;
    [SerializeField] string shaderToggle1x1Name = "_ToggleSmooth";
    [SerializeField] string shaderToggle1x2Name = "_ToggleMetal";
    [SerializeField] string shaderToggle2x1Name = "_BaseBool";
    [SerializeField] string shaderToggle3x1Name = "_ShininessToggle";
    [SerializeField] string shaderToggle3x2Name = "_SmoothnessToggle";
    [SerializeField] string shaderToggle4x1Name = "_EmissionToggle";

    public float boolTemp1;
    public float boolTemp2;

    public GameObject LoseScreen;
    public GameObject WinScreen;

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

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            float shaderValue1 = Material1.GetFloat(shaderToggle1x1Name);
            float shaderValue2 = Material1.GetFloat(shaderToggle1x2Name);
            boolTemp1 = Toggle(shaderValue1);
            boolTemp2 = Toggle(shaderValue2);
            Material1.SetFloat("_ToggleSmooth", boolTemp1);
            Material1.SetFloat("_ToggleMetal", boolTemp2);

        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {

            float shaderValue1 = Material2.GetFloat(shaderToggle2x1Name);
            boolTemp1 = Toggle(shaderValue1);
            Material2.SetFloat("_BaseBool", boolTemp1);
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            float shaderValue1 = Material3.GetFloat(shaderToggle3x1Name);
            float shaderValue2 = Material3.GetFloat(shaderToggle3x2Name);
            boolTemp1 = Toggle(shaderValue1);
            boolTemp2 = Toggle(shaderValue2);
            Material3.SetFloat("_ShininessToggle", boolTemp1);
            Material3.SetFloat("_SmoothnessToggle", boolTemp2);
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            float shaderValue1 = Material4.GetFloat(shaderToggle4x1Name);
            float shaderValue2 = Material5.GetFloat(shaderToggle4x1Name);
            boolTemp1 = Toggle(shaderValue1);
            boolTemp2 = Toggle(shaderValue2);
            Material4.SetFloat("_EmissionToggle", boolTemp1);
            Material5.SetFloat("_EmissionToggle", boolTemp2);
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
        LoseScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void PlayerWin()
    {
        WinScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public float Toggle(float toggle)
    {
        if (toggle == 0.0f)
        {
            toggle = 1.0f;
            return (toggle);
        }

        else
        {
            toggle = 0.0f;
            return (toggle);
        }
    }
}
