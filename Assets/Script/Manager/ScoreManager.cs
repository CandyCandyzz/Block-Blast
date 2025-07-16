using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private float timeScoreIncrease;

    [SerializeField] private TextMeshProUGUI textBest;
    [SerializeField] private TextMeshProUGUI textScore;

    [SerializeField] private ScorePopupSpawner spawner;
    private void Update()
    {
        UpdateUI();
    }

    public void CountScore(int numsRow,int numsCol,Vector2 pos,string colorHex)
    {
        int sum = numsRow + numsCol;
        int incScore = 8 * sum * sum;

        spawner.Spawn(pos, incScore,colorHex);
        IncreaseScore(incScore);
    }    
    private void IncreaseScore(int incScore)
    {
        int newScore = score + incScore; ///
        StartCoroutine(Increase(newScore));
    }

    private IEnumerator Increase(int newScore)
    {
        float time = 0;
        int originScore = score;
        while (time < timeScoreIncrease)
        {
            time += Time.deltaTime;
            score = Mathf.RoundToInt(Mathf.Lerp(originScore, newScore, time / timeScoreIncrease));
            yield return null;
        }
    }

    private void UpdateUI()
    {
        textScore.text = score.ToString();
    }    
}
