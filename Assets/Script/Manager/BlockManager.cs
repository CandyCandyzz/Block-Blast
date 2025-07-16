using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public Block[,] gridBlocks = new Block[8,8];

    public List<Block> centerBlocks = new();
    public List<List<Block>> horGroups = new();
    public List<List<Block>> verGroups = new();

    [SerializeField] private DestroyBlocks destroyBlocks;
    [SerializeField] private GroupBlocks groupBlocks = new();

    [SerializeField] private ScoreManager scoreManager;
    private FindCenterPos centerPos = new();

    public void SetBlockPos(Block block)
    {
        int x = block.pos.x;
        int y = block.pos.y;
        gridBlocks[x,y] = block;
    }

    public void ListCenter(List<Block> blocksCenter)
    {
        centerBlocks = blocksCenter;
    }

    public void DestroyBlocks(List<int> rowsFull, List<int> colsFull)
    {
        horGroups = groupBlocks.HorGroups(gridBlocks,centerBlocks,rowsFull);
        verGroups = groupBlocks.VerGroups(gridBlocks, centerBlocks, colsFull);

        EnablePopUp(centerBlocks,rowsFull.Count,colsFull.Count);
        destroyBlocks.DestroyFullBlock(centerBlocks, horGroups, verGroups);
    }

    private void EnablePopUp(List<Block> blocksCenter,int numsRow,int numsCol)
    {
        Vector2 pos = centerPos.CenterPosofBlocks(blocksCenter);
        string colorHex = blocksCenter[0].blockInfo.colorHex;

        scoreManager.CountScore(numsRow, numsCol, pos, colorHex);
    }
}
