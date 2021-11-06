using UnityEngine;

[CreateAssetMenu(fileName = "New Card")]
public class Data_Card : ScriptableObject
{
    public string cardName;
    public int damagePoint;
    public Sprite spriteCard;
}
