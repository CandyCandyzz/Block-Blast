using System.Collections.Generic;

public class PiecePlacementChecker
{
    public List<Piece> pieces = new();
    Tile[,] tiles;

    public bool AnyPiecePlaceable(Tile[,] tiles,List<Piece> pieces)
    {
        this.tiles = tiles;
        this.pieces = pieces;

        CheckPiecesCanPlace();
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].canPlaced) { return true; }
        }
        return false;
    }
    private void CheckPiecesCanPlace()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i] != null && !PieceCanPlace(pieces[i]))
            {
                pieces[i].canPlaced = false;
            }
            if (pieces[i] != null && PieceCanPlace(pieces[i]))
            {
                pieces[i].canPlaced = true;
            }
        }
    }
    private bool PieceCanPlace(Piece piece)
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (BlocksCanPlace(piece, x, y))
                {
                    return true;
                }
            }
        }
        return false;
    }
    private bool BlocksCanPlace(Piece piece, int xCur, int yCur)
    {
        foreach (var block in piece.blocks)
        {
            int x = xCur + block.pos.x;
            int y = yCur + block.pos.y;

            if (x < 0 || y < 0 || x >= 8 || y >= 8
                || tiles[x, y] == null || tiles[x, y].isFill)
            {
                return false;
            }
        }
        return true;
    }
}
