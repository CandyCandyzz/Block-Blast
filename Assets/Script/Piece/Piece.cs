using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public List<Block> blocks;

    private BlockManager blockManager;

    public float distance;
    public bool canPlaced = true;

    private void Start()
    {
        blockManager = FindAnyObjectByType<BlockManager>();
        SetPosForBlock();
    }

    public void SetCenter()
    {
        blockManager.ListCenter(blocks);
    }

    private void SetPosForBlock()
    {
        GetDistanceBlock();

        Block block00 = Block00();
        block00.pos = new Vector2Int(0, 0);

        foreach (var block in blocks)
        {
            if(block00 != block)
            {
                Pos(block00, block);
            }
        }
    }
    private void GetDistanceBlock()
    {
        if (blocks.Count <= 1) { return; }

        for (int i = 0; i < blocks.Count; i++)
        {
            for (int j = i + 1; j < blocks.Count; j++)
            {
                Vector2 block1 = blocks[i].transform.position;
                Vector2 block2 = blocks[j].transform.position;

                bool sameRow = Mathf.Abs(block1.y - block2.y) < 0.0001f;
                bool sameCol = Mathf.Abs(block1.x - block2.x) < 0.0001f;

                if (sameRow || sameCol)
                {
                    distance = Vector2.Distance(block1, block2);
                    return;
                }
            }
        }
    }
    private Block Block00()
    {
        if (blocks == null || blocks.Count == 0) return null;

        Block best = null;
        float bestY = float.MinValue;
        float bestX = float.MaxValue;

        foreach (var go in blocks)
        {
            Vector3 p = go.transform.position;

            if (p.y > bestY + 0.0001f ||
               (Mathf.Abs(p.y - bestY) <= 0.0001f && p.x < bestX))
            {
                bestY = p.y;
                bestX = p.x;
                best = go;
            }
        }
        return best;
    }    
    private void Pos(Block block00,Block block)
    {
        Vector2 posBlock0 = block00.transform.position;
        Vector2 posBlock1 = block.transform.position;

        int n = Mathf.RoundToInt((posBlock1.x - posBlock0.x) / distance);
        int m = Mathf.RoundToInt((posBlock1.y - posBlock0.y) / distance);

        block.pos = new Vector2Int (-m, n);
    }
}
