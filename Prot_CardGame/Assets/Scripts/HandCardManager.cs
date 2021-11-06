using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class HandCardManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject objectActive;
    //[SerializeField] private AbilityCard card = null;
    [SerializeField] private Queue<AbilityCard> activeCard = new Queue<AbilityCard>();

    public bool IsSelectCard { get; private set; }

    

    private Image imgActiveCard;
    private Sprite defImage;

    private void Start()
    {
        imgActiveCard = objectActive.GetComponent<Image>();
        defImage = imgActiveCard.sprite;
    }

    private void Update()
    {

    }

    public void SetActiveCard(AbilityCard card)
    {
        if (activeCard.Count == 0)
        {
            activeCard.Enqueue(card);
            imgActiveCard.sprite = activeCard.Peek().GetCardData().spriteCard;
        }       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (activeCard.Count != 0)
        {
            activeCard.Dequeue();
            imgActiveCard.sprite = defImage;
        }
    }
}
