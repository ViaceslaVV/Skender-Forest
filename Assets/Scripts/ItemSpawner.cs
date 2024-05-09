using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Vector3 worldSize = Vector3.one * 100;
    public int count = 8;
    public GameObject itemPrefab;
    
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            var pos = new Vector3();
            pos.x = Random.Range(10, worldSize.x - 10);
            pos.y = 100;
            pos.z = Random.Range(10, worldSize.z - 10);
            
            if (Physics.Raycast(pos, Vector3.down, out var hit))
            {
                pos = hit.point;
                Instantiate(itemPrefab, pos, Quaternion.identity);
            }
        }
    }
}
