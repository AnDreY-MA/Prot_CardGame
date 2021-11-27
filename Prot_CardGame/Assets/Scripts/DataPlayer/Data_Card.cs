using UnityEngine;

[CreateAssetMenu(fileName = "New Card")]
public class Data_Card : ScriptableObject
{
    public int damagePoint;
    public int priceForAttack;
    public TypeCard typeCard;
    public Sprite spriteCard;
}
