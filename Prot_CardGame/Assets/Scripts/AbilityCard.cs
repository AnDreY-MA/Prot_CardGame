using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilityCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private string nameCard;
    [SerializeField] private int damage;

    public Image imgCard { get; private set; }

    private RectTransform posCard;

    private Vector2 startPos;

    private int countClick = 0;

    public bool isActive { get; private set; }


    private void Start()
    {
        posCard = GetComponent<RectTransform>();
        startPos = posCard.anchoredPosition;
        imgCard = GetComponent<Image>();
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
        if (!isActive)
            isActive = true;
        else if (isActive)
            isActive = false;

        
    }
}
