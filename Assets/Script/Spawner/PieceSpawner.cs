using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> piecePrefabs;
    [SerializeField] private Transform[] slot;
    public float pieceScale;

    public List<Piece> listPiecesSpawned = new();

    public void Spawn()
    {
        List<Piece> listPieces = new();
        for (int i = 0; i < slot.Length; i++)
        {
            GameObject piece = Instantiate(RamdomPiece(), slot[i]);
            piece.transform.position = slot[i].position;

            int angle = RandomAngle();
            piece.transform.eulerAngles = new Vector3(0, 0, angle);
            piece.transform.localScale = new Vector3(pieceScale, pieceScale, pieceScale);

            listPieces.Add(piece.GetComponent<Piece>());
        }
        listPiecesSpawned = listPieces;
    }
    private GameObject RamdomPiece()
    {
        int randomIndex = Random.Range(0, piecePrefabs.Count);
        return piecePrefabs[randomIndex];
    }
    private int RandomAngle()
    {
        int num = Random.Range(0, 4);
        int angle = num * 90;
        return angle;
    }
}
