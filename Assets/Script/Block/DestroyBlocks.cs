using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlocks : MonoBehaviour
{
    [SerializeField] private float timeDestroy;

    public void DestroyFullBlock(List<Block> centerBlocks, 
        List<List<Block>> lrBlocks, 
        List<List<Block>> udBlocks)
    {

        StartCoroutine(DestroyBlock(centerBlocks, lrBlocks, udBlocks));

    }


    private IEnumerator DestroyBlock(List<Block> centerBlocks, 
        List<List<Block>> lrBlocks, 
        List<List<Block>> udBlocks)
    {

        int index = 0;

        DestroyCenterBlocks(centerBlocks);
        yield return new WaitForSeconds(timeDestroy);

        while (true)
        {
            DestroyRowBlocks(lrBlocks,index);
            DestroyColBlocks(udBlocks,index);

            if (index >= 6)
            {
                break;
            }

            yield return new WaitForSeconds(timeDestroy);
            index++;
        }

    }

    private void DestroyCenterBlocks(List<Block> centerBlocks)
    {
        for (int i = 0; i < centerBlocks.Count; i++)
        {
            Block block = centerBlocks[i];
            block.DestroyBlock();
        }
    }

    //Destroy A Block in Left & Right of CenterBlocks per Index
    private void DestroyRowBlocks(List<List<Block>> lrBlocks,int index)
    {
        if (lrBlocks.Count <= 1) { return; }

        List<Block> row = new();
        for (int i = 0; i < lrBlocks.Count; i++)
        {
            row = lrBlocks[i];
            if (index < row.Count)
            {
                row[index].DestroyBlock();
            }
        }
    }

    //Destroy A Block in Up & Down of CenterBlocks per Index
    private void DestroyColBlocks(List<List<Block>> udBlocks,int index)
    {
        if (udBlocks.Count <= 1) { return; }

        List<Block> col = new();
        for (int i = 0; i < udBlocks.Count; i++)
        {
            col = udBlocks[i];
            if (index < col.Count)
            {
                col[index].DestroyBlock();
            }
        }
    }
}
