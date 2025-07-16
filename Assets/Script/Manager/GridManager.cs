using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Transform panelTile;
    public Tile[,] tiles = new Tile[8, 8];

    [SerializeField] private BlockManager blockManager;
    private TileReset tileReset = new();


    private void Start()
    {
        GetTile();
    }
    private void GetTile()
    {
        int index = 0;
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                tiles[x, y] = panelTile.GetChild(index).GetComponent<Tile>();
                tiles[x, y].pos = new Vector2Int(x, y);
                index++;
            }
        }
    }

    public void ChecknDestroy()
    {
        List<int> rowsFull = RowsFull();
        List<int> colsFull = ColsFull();
        if (rowsFull.Count == 0 && colsFull.Count == 0) { return; }

        RsTile(rowsFull,colsFull);
        blockManager.DestroyBlocks(rowsFull,colsFull);
    }

    private List<int> RowsFull()
    {
        List<int> rowsFull = new();

        for (int x = 0; x < 8; x++)
        {
            bool rowFull = true;
            for (int y = 0; y < 8; y++)
            {
                if (!tiles[x, y].isFill)
                {
                    rowFull = false;
                    break;
                }
            }

            if (rowFull)
            {
                rowsFull.Add(x);
            }
        }
        return rowsFull;
    }
    private List<int> ColsFull()
    {
        List<int> colsFull = new();

        for (int y = 0; y < 8; y++)
        {
            bool colFull = true;
            for (int x = 0; x < 8; x++)
            {
                if (!tiles[x, y].isFill)
                {
                    colFull = false;
                    break;
                }
            }

            if (colFull)
            {
                colsFull.Add(y);
            }
        }
        return colsFull;
    }

    private void RsTile(List<int> rowsFull, List<int> colsFull)
    {
        tileReset.ResetTile(blockManager.gridBlocks, tiles, rowsFull, colsFull);
    }
}
