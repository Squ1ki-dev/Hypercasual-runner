using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] tilePrefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPos = 0;
    private float tileLength = 11.85f;

    [SerializeField] private Transform player;
    private int startTiles = 5;

    private void Start() => RandomTile();

    private void Update() => PositionTile();

    private void RandomTile()
    {
        for (int i = 0; i < startTiles; i++)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    private void PositionTile()
    {
        if(player.position.z - 15 > spawnPos - (startTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }   
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLength; 
    }
    
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
