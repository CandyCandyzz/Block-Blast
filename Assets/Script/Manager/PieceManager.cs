using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    private Tile[,] tiles;
    [SerializeField] private Transform panelSlot;
    [SerializeField] private GameManager gameManager;

    private PiecePlacementChecker placementChecker = new();
    private PlacePiece placePiece = new();

    private void Start()
    {
        tiles = FindAnyObjectByType<GridManager>().tiles;
    }

    public void AnyPieceCanPlaced()
    {
        List<Piece> pieces = new();
        pieces = panelSlot.GetComponentsInChildren<Piece>().ToList();

        bool hasStepPlaced = placementChecker.AnyPiecePlaceable(tiles,pieces);
        if (!hasStepPlaced)
        {
            gameManager.GameOver();
        }
    }

    public bool PlacePiece(Piece piece)
    {
        if (placePiece.Placee(piece))
        {
            return true;
        }
        return false;
    }
}
