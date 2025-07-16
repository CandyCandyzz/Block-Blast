using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Transform[] slot;
    [SerializeField] private PieceSpawner pieceSpawner;

    [Header("GameOver")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private PieceManager pieceManager;
    [SerializeField] private Transform effContainer;

    [SerializeField] private Transform text;
    [SerializeField] private Transform buttonAgain;
    [SerializeField] private Transform beginSlidePos;
    [SerializeField] private float timeSlide;


    private void Start()
    {
        pieceSpawner.Spawn();
    }

    #region spawn
    public void ChecknSpawn()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i].childCount >= 1) { return; }
        }
        pieceSpawner.Spawn();
        pieceManager.AnyPieceCanPlaced();
    }
    #endregion

    #region GameStatus
    public void GameOver()
    {
        StartCoroutine(WaitEffDone());
    }

    private IEnumerator WaitEffDone()
    {
        yield return new WaitUntil(() => effContainer.childCount == 0);
        gameOverPanel.SetActive(true);
        StartCoroutine(Slide());
    }

    private IEnumerator Slide()
    {
        Vector2 textOriginPos = text.position;
        Vector2 buttonOriginPos = buttonAgain.position;

        text.position = beginSlidePos.position;
        buttonAgain.position = beginSlidePos.position;

        float time = 0;
        while (time < timeSlide)
        {
            time += Time.deltaTime;
            text.position = Vector2.Lerp(text.position, textOriginPos, time / timeSlide);
            buttonAgain.position = Vector2.Lerp(buttonAgain.position, buttonOriginPos, time / timeSlide);
            yield return null;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
    #endregion
}
