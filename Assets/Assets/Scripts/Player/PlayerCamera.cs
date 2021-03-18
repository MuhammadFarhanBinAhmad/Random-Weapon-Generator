using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform the_Player_Body;
    public float mouse_Sensitivity;

    float x_Rotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseMovement();

    }

    void MouseMovement()
    {
        float mouse_Y = Input.GetAxis("Mouse Y") * mouse_Sensitivity * Time.deltaTime;
        float mouse_X = Input.GetAxis("Mouse X") * mouse_Sensitivity * Time.deltaTime;

        x_Rotation -= mouse_Y;
        x_Rotation = Mathf.Clamp(x_Rotation, -90, 90);

        transform.localRotation = Quaternion.Euler(x_Rotation, 0, 0);
        the_Player_Body.Rotate(Vector3.up * mouse_X);
    }
}
