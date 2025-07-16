using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour
{
    //Status
    public BlockInfoSO blockInfo;
    public bool isDestroyed = false;

    //Place
    public bool isCanPlaced = false;
    private Tile targetTile;

    //SetPos
    public Vector2Int pos;
    private BlockManager blockManager;

    [SerializeField] private BlockBreakEffect breakEffect;

    private void Start()
    {
        blockManager = FindAnyObjectByType<BlockManager>();
    }

    public void GraphicRayCast()
    {
        Vector3 sceenPos = Camera.main.WorldToScreenPoint(transform.position);
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = sceenPos;

        List<RaycastResult> raycastResults = new();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        Block block = GetComponent<Block>();
        foreach (var ui in raycastResults)
        {
            Tile tile;
            Block rayBlock = ui.gameObject.GetComponent<Block>();

            if (ui.gameObject.TryGetComponent<Tile>(out tile))
            {
                targetTile = tile;
            }

            //ui.gameObject.TryGetComponent<Tile>(out targetTile);
            if (rayBlock != null && block != rayBlock 
                || targetTile != null && targetTile.isFill)
            {
                return;
            }
        }
        
        if (targetTile != null)
        {
            isCanPlaced = true;
        }
    }

    public void SetPos()
    {
        transform.position = targetTile.transform.position;
        targetTile.isFill = true;
        pos = targetTile.pos;

        blockManager.SetBlockPos(this);
    }

    public void ResetStatus()
    {
        isCanPlaced = false;
    }

    public void DestroyBlock()
    {  
        if (this == null) { return; }
        if (isDestroyed)
        {
            Sprite sprite = blockInfo.sprite;
            string colorHex = blockInfo.colorHex;
            Vector2 pos = transform.position;

            breakEffect.Play(sprite,colorHex,pos);
        }
    }
}
