using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestClass : MonoBehaviour
{
    public PartilceSystems partilceSystemsData;
    public ParticleSystem ParticleSystem_current;

    void Start()
    {
        ParticleSystem_current = Instantiate(partilceSystemsData.particleSystems[0]);
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Work");
        }
    }

    private void CameraKnown()
    {
        
    }    
}

