using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ParticleSystemData", menuName = "ScriptableObjects/ParticleSystemData", order = 0)]

public class PartilceSystems : ScriptableObject
{
    public List <ParticleSystem> particleSystems;

}
