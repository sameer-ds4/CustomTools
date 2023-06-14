using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;

    private Camera mainCam;

    public Vector3 camOffset;

    public Vector3 speed;
    public float dampFactor;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null)
        {
            mainCam.transform.position = Vector3.Slerp(transform.position, target.transform.position + camOffset, dampFactor);
        }
    }
}
