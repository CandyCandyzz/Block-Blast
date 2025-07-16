using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject blockEffPrefabs;
    [SerializeField] private GameObject starEffPrefabs;
    [SerializeField] private Transform effectContainer;

    private BreakVFX blockExploEff;
    private BreakVFX starEff;

    public void Spawn(Sprite sprite, string color, Vector2 pos)
    {
        InstanceEff(pos);

        ChangeSprite(sprite);
        ChangeStarColor(color);

        blockExploEff.PlayEffect();
        starEff.PlayEffect();
    }

    private void InstanceEff(Vector2 pos)
    {
        blockExploEff = Instantiate(blockEffPrefabs, pos, Quaternion.identity, effectContainer).GetComponent<BreakVFX>();
        starEff = Instantiate(starEffPrefabs, pos, Quaternion.identity, effectContainer).GetComponent<BreakVFX>();
    }
    private void ChangeSprite(Sprite spriteBlock)
    {
        blockExploEff.ChangeSprite(spriteBlock);
    }
    private void ChangeStarColor(string colorHex)
    {
        starEff.ChangeStarColor(colorHex);
    }
}
