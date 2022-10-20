using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    [SerializeField] private int _width, _depth;

    [SerializeField] private TileScript _tilePrefab;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, TileScript> _tiles;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, TileScript>();
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _depth; z++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, z), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {z}";

                var isOffset = (x + z) % 2 == 1;
                spawnedTile.Init(isOffset);
            }
        }

        _cam.transform.position = new Vector3((float)_width/2 -0.5f, (float)_depth/2 -0.5f, -10);
    }
    public TileScript GetTileAtPosition(Vector2 pos)
    {
        if(_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }
}
