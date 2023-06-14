using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody bullet;
    public float shootSpeed;

    public Transform bulletSpawn;

    public Camera mainCam;


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ShootBullet();
        }
    }


    private void ShootBullet()
    {
        Rigidbody bulletShot = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        Vector3 direction = mainCam.transform.forward;
        bulletShot.AddForce(direction * shootSpeed, ForceMode.Impulse);
    }
}
