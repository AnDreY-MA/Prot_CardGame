using UnityEngine;

public enum TypeGround { AbleMove, UnAbleMove, Character }

public class WayPoint : MonoBehaviour
{
    [SerializeField] protected TypeGround _typeGround;

    public TypeGround TypeGround => _typeGround;
}
