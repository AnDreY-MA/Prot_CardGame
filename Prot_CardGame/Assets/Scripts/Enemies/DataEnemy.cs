using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy")]
public class DataEnemy : ScriptableObject
{
    public int health;
    public int attackDamage;
    public Sprite spriteEnemy;
}
