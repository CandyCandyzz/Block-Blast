using UnityEngine;
using UnityEngine.EventSystems;

public class DragPiece : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private GridManager gridManager;
    private PieceManager pieceManager;
    private GameManager gameManager;

    [SerializeField] private Transform pieceContainer;
    private Vector2 origionPos;
    private Vector2 originScale;

    [SerializeField] Piece piece;
    private bool isPlaced = false;
    //private bool isCanPlaced = true;

    private void Start()
    {
        origionPos = transform.position;
        originScale = transform.localScale;

        gridManager = FindAnyObjectByType<GridManager>();
        gameManager = FindAnyObjectByType<GameManager>();
        pieceManager = FindAnyObjectByType<PieceManager>();
        pieceContainer = GameObject.Find("PieceContainer").transform;
    }

    #region Drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(isPlaced) { return; }
        //isCanPlaced = true;
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isPlaced) { return; }
        transform.position = Pos();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isPlaced) { return; }

        isPlaced = pieceManager.PlacePiece(piece);

        if(isPlaced)
        {
            transform.SetParent(pieceContainer);

            gameManager.ChecknSpawn();
            gridManager.ChecknDestroy();
            pieceManager.AnyPieceCanPlaced();
        }
        else
        {
            ReturnOriginPos();
            return;
        }
    }
    #endregion

    private Vector3 Pos()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }

    private void ReturnOriginPos()
    {
        transform.position = origionPos;
        transform.localScale = originScale;
        for (int i = 0; i < piece.blocks.Count; i++)
        {
            piece.blocks[i].ResetStatus();
        }
    }
}
