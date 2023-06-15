using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankConroller : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController controller;
    public Transform cameraTransform;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float playerSpeed = 5;
    public float bulletSpeed = 10;
    Vector3 velocity; 
    public float mouseSensivity = 1; //1
    Vector2 look;
    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateLook();
        updateBullet();
    }

     void UpdateMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var input = new Vector3();
        input += transform.forward * z;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);

        controller.Move((input * playerSpeed + velocity) * Time.deltaTime);
    }

    void UpdateLook()
    {  
        look.x += Input.GetAxis("Mouse X") * mouseSensivity;
        look.y += Input.GetAxis("Mouse Y") * mouseSensivity;
        look.y = Mathf.Clamp(look.y, -90, 90);
        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0); 
        transform.localRotation = Quaternion.Euler(0, look.x, 0); 
     }

     void updateBullet()
     {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
     }

}

