using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private bool _isPlaceAble;

    public WayPoint _wayPoint;
    public bool IsPlaceAble => _isPlaceAble;

    private float _gridSizeX = 2.5f;
    private float _gridSizeY = 4f;

    public float GridSizeX => _gridSizeX;
    public float GridSizeY => _gridSizeY;

    public Vector2 GridPos()
    {
        return new Vector2(transform.position.x / _gridSizeX, transform.position.y / _gridSizeY);
    }
}
