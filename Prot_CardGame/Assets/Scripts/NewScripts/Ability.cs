using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private Data_Card _cardData;

    private string _typeCard;
    private int _damagePoints;

    private SpriteRenderer _sprite;

    private Vector3 _startPosition;

    private ActiveCard _systemActiveCard;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _systemActiveCard = FindObjectOfType<ActiveCard>();
        _startPosition = transform.position;
    }

    private void Start()
    {
        _sprite.sprite = _cardData.spriteCard;
        _typeCard = _cardData.cardType;
        _damagePoints = _cardData.damagePoint;
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

    public Data_Card GetDataCard()
    {
        return _cardData;
    }
}
