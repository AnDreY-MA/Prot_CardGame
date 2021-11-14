using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActiveSystem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _activeCard;
    [SerializeField] private Sprite _defImage;

    private int _damageCard;
    public int DamageCard => _damageCard;

    private int _priceAttack;
    public int PriceAttack => _priceAttack;

    private Queue<Ability> _isActiveCard = new Queue<Ability>();

    private TurnSystem _turnSystem;

    private void Start()
    {
        _activeCard.sprite = _defImage;
        _turnSystem = FindObjectOfType<TurnSystem>();
    }

    private void Update()
    {
        if (_turnSystem.TurnClick && _isActiveCard.Count != 0)
        {
            RemoveDataCard();
        }
    }

    public void SetActiveCard(Ability card)
    {
        if (_isActiveCard.Count == 0)
        {
            _isActiveCard.Enqueue(card);
            _activeCard.sprite = _isActiveCard.Peek().GetDataCard().spriteCard;
            _damageCard = card.GetDataCard().damagePoint;
            _priceAttack = card.GetDataCard().priceForAttack;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isActiveCard.Count != 0)
        {
            RemoveDataCard();
        }
    }

    private void RemoveDataCard()
    {
        _isActiveCard.Dequeue();
        _activeCard.sprite = _defImage;
        _damageCard = 0;
        _priceAttack = 0;
    }
}
