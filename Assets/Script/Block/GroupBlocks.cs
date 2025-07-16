using System.Collections.Generic;
using System.Linq;

public class GroupBlocks
{
    public List<List<Block>> HorGroups(Block[,] gridBlocks,List<Block> centerBlocks, List<int> rowsFull)
    {
        List<List<Block>> listRows = new();
        if (rowsFull.Count == 0) { return listRows; }

        int x;

        for (int i = 0; i < rowsFull.Count; i++)
        {
            x = rowsFull[i];

            List<Block> row = new();
            for (int y = 0; y < 8; y++)
            {
                row.Add(gridBlocks[x, y]);
            }

            int indexLeft = row.FindIndex(a => a == BlockLeft(x,centerBlocks));
            int indexRight = row.FindIndex(a => a == BlockRight(x,centerBlocks));

            List<Block> leftOfCenterBlocks = row.Take(indexLeft).Reverse().ToList();
            List<Block> rightOfCenterBlocks = row.Skip(indexRight + 1).ToList();

            listRows.Add(leftOfCenterBlocks);
            listRows.Add(rightOfCenterBlocks);
        }
        return listRows;
    }
    private Block BlockLeft(int xRow, List<Block> centerBlocks)
    {
        Block leftBlock = centerBlocks.Find(a => a.pos.x == xRow);
        return leftBlock;
    }
    private Block BlockRight(int xRow, List<Block> centerBlocks)
    {
        Block rightBlock = centerBlocks.FindLast(a => a.pos.x == xRow);
        return rightBlock;
    }


    public List<List<Block>> VerGroups(Block[,] gridBlocks, List<Block> centerBlocks,List<int> colsFull)
    {
        List<List<Block>> listCols = new();
        if (colsFull.Count == 0) { return listCols; }

        int y;

        for (int i = 0; i < colsFull.Count; i++)
        {
            y = colsFull[i];

            List<Block> col = new();
            for (int x = 0; x < 8; x++)
            {
                col.Add(gridBlocks[x, y]);
            }

            int indexUp = col.FindIndex(a => a == BlockUp(y,centerBlocks));
            int indexDown = col.FindIndex(a => a == BlockDown(y, centerBlocks));

            List<Block> upOfCenterBlocks = col.Take(indexUp).Reverse().ToList();
            List<Block> downOfCenterBlocks = col.Skip(indexDown + 1).ToList();

            listCols.Add(upOfCenterBlocks);
            listCols.Add(downOfCenterBlocks);
        }
        return listCols;
    }
    private Block BlockUp(int yRow, List<Block> centerBlocks)
    {
        Block upBlock = centerBlocks.Find(a => a.pos.y == yRow);
        return upBlock;
    }
    private Block BlockDown(int yRow, List<Block> centerBlocks)
    {
        Block downBlock = centerBlocks.FindLast(a => a.pos.y == yRow);
        return downBlock;
    }
}
