using System.Collections;
using UnityEngine;

public class BreakVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem effect;

    public void PlayEffect()
    {
        StartCoroutine(WaitDonenDestroy());
    }

    private IEnumerator WaitDonenDestroy()
    {
        effect.Play();
        yield return new WaitUntil(() => !effect.IsAlive());
        Destroy(gameObject);
    }

    public void ChangeSprite(Sprite sprite)
    {
        var tsa = effect.textureSheetAnimation;
        tsa.mode = ParticleSystemAnimationMode.Sprites;
        tsa.SetSprite(0, sprite);
    }

    public void ChangeStarColor(string colorHex)
    {
        Color color;
        ColorUtility.TryParseHtmlString(colorHex, out color);
        var main = effect.main;
        main.startColor = color;
    }
}
