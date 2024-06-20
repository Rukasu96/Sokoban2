using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid : MonoBehaviour
{
    [SerializeField] private Transform cells;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private int offsetX;
    [SerializeField] private int offsetY;
    private Tile[][] tiles;

    public int OffsetX => offsetX;
    public int OffsetY => offsetY;
    public Tile[][] Tiles { get => tiles; }

    private void Awake()
    {
        SetupGrid();
    }

    private void SetupGrid()
    {
        tiles = new Tile[width][];

        for (int i = 0; i < width; i++)
        {
            tiles[i] = new Tile[height];
        }
        AssignTiles();
    }

    private void AssignTiles()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            foreach (Transform tileChild in cells)
            {
                if (Mathf.RoundToInt(tileChild.transform.position.x) + offsetX == i)
                {
                    Tile tile = new Tile();
                    tiles[i][Mathf.RoundToInt(tileChild.transform.position.y) + offsetY] = tile;
                }
            }

        }
    }

}
