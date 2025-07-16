using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlockBreakEffect : MonoBehaviour
{
    [SerializeField] private float timeDisappear;
    [SerializeField] private Image image;

    private EffectSpawner effectSpawner;

    private void Start()
    {
        effectSpawner = FindAnyObjectByType<EffectSpawner>();
    }

    public void Play(Sprite sprite, string colorHex,Vector2 pos)
    {
        effectSpawner.Spawn(sprite, colorHex, pos);
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        Color baseColor = image.color;
        Color newColor = baseColor;
        newColor.a = 0;

        float time = 0f;

        while (time < timeDisappear)
        {
            time += Time.deltaTime;
            image.color = Color.Lerp(baseColor, newColor, time / timeDisappear);
            yield return null;
        }
        image.color = newColor;
        Destroy(gameObject);
    }
}
