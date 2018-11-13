using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawn = -10.0f;
    private float tileLength = 10.0f;
    private int amnTilesOnSCreen = 5;
    private List<GameObject> activeTiles;
    private float safeZone = 0.0f;
    private int lastPrefabIndex = 0;
	void Start () {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnTilesOnSCreen; i++)
        {
            if (i < 2)
                TileSpawn(0);
            TileSpawn();
        }

    }
	
	private void Update () {
        if(playerTransform.position.z - safeZone > (spawn - amnTilesOnSCreen * tileLength))
        {
            TileSpawn();
            DeleteTile();
        }

    }
    private void TileSpawn (int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawn;
        spawn += tileLength;
        activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
