using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private Data_Card _cardData;
    [SerializeField] private Transform _place;

    private SpriteRenderer _sprite;

    private Vector3 _startPosition;

    private ActiveSystem _systemActiveCard;

    #region Behavior
    private void OnEnable()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _systemActiveCard = FindObjectOfType<ActiveSystem>();
        _startPosition = _place.position;
        _sprite.sprite = _cardData.spriteCard;
    }

    private void OnMouseEnter()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
    }

    private void OnMouseDown()
    {
        _systemActiveCard.SetActiveCard(this);
    }

    private void OnMouseExit()
    {
        transform.position = _startPosition;
    }
    #endregion

    public Data_Card GetDataCard()
    {
        return _cardData;
    }
}
