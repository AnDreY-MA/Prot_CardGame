using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActiveCard : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _activeCard;
    [SerializeField] private Sprite _defImage;

    private string _typeCard;
    private int _damageCard;

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
            _typeCard = card.GetDataCard().cardType;
            _damageCard = card.GetDataCard().damagePoint;
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
        _typeCard = null;
        _damageCard = 0;
    }
}
