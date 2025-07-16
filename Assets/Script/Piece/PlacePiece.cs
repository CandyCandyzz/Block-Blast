using UnityEngine;

public class PlacePiece
{
    public bool Placee(Piece piece)
    {
        if(CanPlaced(piece))
        {
            Place(piece);
            return true;
        }
        return false;
    }    

    private void Place(Piece piece)
    {
        for (int i = 0; i < piece.blocks.Count; i++)
        {
            piece.blocks[i].SetPos();
        }
        piece.SetCenter();
    }

    private bool CanPlaced(Piece piece)
    {
        for (int i = 0; i < piece.blocks.Count; i++)
        {
            piece.blocks[i].GraphicRayCast();

            bool blockCanPlace = piece.blocks[i].isCanPlaced;

            if (!blockCanPlace)
            {
                return false;
            }
        }
        return true;
    }
}
