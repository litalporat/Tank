using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConrolScript : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController controller;
    public Transform cameraTransform; // 2 camera
    public float playerSpeed = 5;

    public float mouseSensivity = 1; 
    Vector2 look;


    Vector3 velocity; 
    float mass = 1f;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // UpdateLook(); 
        UpdateMovement(); 
        UpdateGravity(); 
    }

    void UpdateLook()
    {  
        look.x += Input.GetAxis("Mouse X") * mouseSensivity; 
        look.y += Input.GetAxis("Mouse Y") * mouseSensivity;
        look.y = Mathf.Clamp(look.y, -90, 90);
        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0); //2.1
        transform.localRotation = Quaternion.Euler(0, look.x, 0); //2 � palyer
     }
    void UpdateMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var input = new Vector3();
        input += transform.forward * z;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);

        controller.Move((input * playerSpeed/*9*/ + velocity) * Time.deltaTime);
    }
    private void UpdateGravity()
    {     
        var gravity = Physics.gravity * mass * Time.deltaTime;
        velocity.y = controller.isGrounded ? -1 : velocity.y + gravity.y;
    }
}
