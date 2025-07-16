using System.Collections.Generic;
using UnityEngine;

public class FindCenterPos
{
    public Vector2 CenterPosofBlocks(List<Block> blocksCenter)
    {
        return CenterPos(BlocksDestroyed(blocksCenter));
    }

    private List<Block> BlocksDestroyed(List<Block> blocksCenter)
    {
        List<Block> blocksIsDestroyed = new();
        foreach (var block in blocksCenter)
        {
            if (block != null && block.isDestroyed)
            {
                blocksIsDestroyed.Add(block);
            }
        }
        return blocksIsDestroyed;
    }

    private Vector2 CenterPos(List<Block> blocksDestroyed)
    {
        Vector3 centerPos = Vector2.zero;
        foreach (var block in blocksDestroyed)
        {
            centerPos += block.transform.position;
        }

        centerPos = centerPos/blocksDestroyed.Count;
        return centerPos;
    }
}
