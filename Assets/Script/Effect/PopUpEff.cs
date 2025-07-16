using System.Collections;
using TMPro;
using UnityEngine;

public class ScorePopUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private float timePopUp;
    [SerializeField] private float timePopDown;
    [SerializeField] private float timeDisappear;

    public void Initialize(Vector2 pos,int incScore,string colorHex)
    {
        if (incScore == 0) 
        {
            Destroy(gameObject);
            return; 
        }
        transform.position = pos;
        text.text = incScore.ToString();
        Color a;
        ColorUtility.TryParseHtmlString(colorHex,out a);
        text.color = a;

        StartCoroutine(PopUp());
        StartCoroutine(Disappear());
    }

    private IEnumerator PopUp()
    {
        Vector2 originScale = transform.localScale;
        Vector2 popUpScale = originScale * 1.2f;
        transform.localScale = Vector2.zero;

        float time = 0;
        while (time < timePopUp)
        {
            time += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector2.zero, popUpScale, time/timePopUp);
            yield return null;
        }

        time = 0f;
        while (time < timePopDown)
        {
            time += Time.deltaTime;
            transform.localScale = Vector3.Lerp(popUpScale, originScale, time / timePopDown);
            yield return null;
        }
    }

    private IEnumerator Disappear()
    {
        Color baseColor = text.color;
        Color newColor = baseColor;
        newColor.a = 0;

        float time = 0f;

        while (time < timeDisappear)
        {
            time += Time.deltaTime;
            text.color = Color.Lerp(baseColor, newColor, time / timeDisappear);
            yield return null;
        }
        text.color = newColor;
        Destroy(gameObject);
    }
}
