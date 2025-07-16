using UnityEngine;

public class ScorePopupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject scorePUPrefabs;
    [SerializeField] private Transform popupCon;

    public void Spawn(Vector2 pos, int incScore, string colorHex)
    {
        ScorePopUp popUp = Instantiate(scorePUPrefabs, popupCon).GetComponent<ScorePopUp>();
        popUp.Initialize(pos, incScore,colorHex);
    }
}
