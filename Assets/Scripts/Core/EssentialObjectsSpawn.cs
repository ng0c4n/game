using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialObjectsSpawn : MonoBehaviour
{
    [SerializeField] GameObject essentialObjectsPrefab;
    private void Awake()
    {
        var existingObjects = FindObjectsOfType<EssentialObjects>();
        if(existingObjects.Length == 0)
        {
            //If there is a grid, the spawn at center
            var spawnPos = new Vector3 (0, 0, 0);
            var grid = FindObjectOfType<Grid>();
            if(grid != null )
                spawnPos = grid.transform.position;
            Instantiate(essentialObjectsPrefab, spawnPos, Quaternion.identity);

        }
    }
}
