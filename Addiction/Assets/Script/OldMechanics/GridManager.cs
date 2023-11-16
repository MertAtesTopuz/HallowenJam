using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject gridPos;

    private void Start()
    {
        GenerateGrid();
        StartCoroutine(spawnTime());
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, parent.transform);
                spawnedTile.transform.position = new Vector3(x, y);
                spawnedTile.name = $"Tile {x} {y}";
            }
        }
    }

    IEnumerator spawnTime()
    {
        yield return new WaitForSeconds(1f);
        gridPos.transform.position = new Vector3(-7.39f, -0.95f, gridPos.transform.position.z);
    }
}
