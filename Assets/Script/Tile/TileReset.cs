using System.Collections.Generic;

public class TileReset
{
    public void ResetTile(Block[,] gridBlocks, Tile[,] tiles, List<int> rowsFull, List<int> colsFull)
    {
        foreach (var x in rowsFull)
        {
            for (int y = 0; y < 8; y++)
            {
                tiles[x, y].isFill = false;
                SetDestroyForBlock(gridBlocks, x, y);
            }
        }

        foreach (var y in colsFull)
        {
            for (int x = 0; x < 8; x++)
            {
                tiles[x, y].isFill = false;
                SetDestroyForBlock(gridBlocks, x, y);
            }
        }
    }

    private void SetDestroyForBlock(Block[,] gridBlocks, int x,int y)
    {
        gridBlocks[x, y].isDestroyed = true;
    }
}
