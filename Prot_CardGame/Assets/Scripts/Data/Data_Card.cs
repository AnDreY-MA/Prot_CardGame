using UnityEngine;

[CreateAssetMenu(fileName = "New Card")]
public class Data_Card : ScriptableObject
{
    public string cardType;
    public int damagePoint;
    public int priceForAttack;
    public Sprite spriteCard;
}
