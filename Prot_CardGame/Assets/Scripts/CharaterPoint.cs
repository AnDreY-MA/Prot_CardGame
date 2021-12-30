using UnityEngine;
public class CharaterPoint : WayPoint
{
    [SerializeField] private string _name;
    public string Name => _name;
    private void Start() => _typeGround = TypeGround.Character;
}
