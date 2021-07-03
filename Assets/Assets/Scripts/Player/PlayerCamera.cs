using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCamera : MonoBehaviour
{
    public Transform the_Player_Body;

    float mouse_Multiplier = 100;
    public float mouse_Sensitivity;

    float x_Rotation;

    public TMP_InputField mouse_Sensitivity_Text;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouse_Sensitivity_Text.text = mouse_Sensitivity.ToString();
    }
    void Update()
    {
        MouseMovement();
    }
    //change mouse sensitivity
    public void ChangeMouseSensitivity()
    {
        mouse_Sensitivity = float.Parse(mouse_Sensitivity_Text.text);//convert string to float
    }
    //Control camera movement
    void MouseMovement()
    {
        float mouse_Y = Input.GetAxis("Mouse Y") * (mouse_Sensitivity * mouse_Multiplier) * Time.deltaTime;
        float mouse_X = Input.GetAxis("Mouse X") * (mouse_Sensitivity * mouse_Multiplier) * Time.deltaTime;

        x_Rotation -= mouse_Y;
        x_Rotation = Mathf.Clamp(x_Rotation, -90, 90);

        transform.localRotation = Quaternion.Euler(x_Rotation, 0, 0);
        the_Player_Body.Rotate(Vector3.up * mouse_X);
    }
}
