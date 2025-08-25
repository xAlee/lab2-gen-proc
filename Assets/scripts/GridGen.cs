using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class GridGen : MonoBehaviour
{
    public GameObject boxelPrefab;

    [SerializeField] private int sizeX = 20;
    [SerializeField] private int sizeZ = 20;

    [SerializeField] private int noiseHeight = 3;

    [SerializeField] private float SeparacionGrid = 1.1f;

    void Start()
    {
        for (int x = 0; x < sizeX; x++)
        {
            for(int z = 0; z < sizeZ; z++)
            {
                Vector3 pos = new Vector3(x * SeparacionGrid, genNoise(x,z,8f) * noiseHeight, z * SeparacionGrid);

                GameObject Cube = Instantiate(boxelPrefab,pos,Quaternion.identity) as GameObject;

                Cube.transform.SetParent(this.transform);
            }
        } 
    }

    private float genNoise(int x, int y, float scale)
    {
        float xNoise = (x + this.transform.position.x) / scale;
        float yNoise = (y + this.transform.position.y) / scale;

        return Mathf.PerlinNoise(xNoise, yNoise);
    }

    
}
