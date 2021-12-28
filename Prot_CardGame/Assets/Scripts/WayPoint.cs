using UnityEngine;

public enum TypeGround { AbleMove, UnAbleMove, Character }

public class WayPoint : MonoBehaviour
{
    [SerializeField] private TypeGround _typeGround;

    private PlayerMovement _player;
    public TypeGround TypeGround => _typeGround;
}
