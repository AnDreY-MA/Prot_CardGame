using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilityCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Data_Card cardData;
    [SerializeField] private HandCardManager cardManager;

    private RectTransform posCard;

    private Text damagePoints;

    private Vector2 startPos;

    public Image ImgCard { get; private set; }

    private void Start()
    {
        posCard = GetComponent<RectTransform>();
        startPos = posCard.anchoredPosition;
        ImgCard = GetComponent<Image>();
        ImgCard.sprite = cardData.spriteCard;
        damagePoints = GetComponentInChildren<Text>();
        damagePoints.text = cardData.damagePoint.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        posCard.anchoredPosition = new Vector2(posCard.anchoredPosition.x, posCard.anchoredPosition.y + 10f);      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        posCard.anchoredPosition = startPos;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        cardManager.SetActiveCard(this);     
    }

    public Data_Card GetCardData()
    {
        return cardData;
    }
}
