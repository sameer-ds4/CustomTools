using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    public GameObject building_prefab;

    public Vector3 bounds;

    private Color[] colors = { Color.red, Color.magenta, Color.blue, Color.yellow, Color.cyan, Color.gray };

    public int maxBuildings;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBuildings();
    }

    private void SpawnBuildings()
    {
        for (int i = 0; i < maxBuildings; i++)
        {
            GameObject building = Instantiate(building_prefab, RandomizePosition(), Quaternion.identity);
            RandomizeColors(building);
        }
    }

    private Vector3 RandomizePosition()
    {
        float z = Random.Range(bounds.z, -bounds.z);
        float x = Random.Range(bounds.x, -bounds.x);

        return new Vector3(x, 4.5f, z);
    }

    private void RandomizeColors(GameObject building_current)
    {
        int x = Random.Range(0, colors.Length);
        building_current.GetComponent<Renderer>().material.color = colors[x];
    }
}
