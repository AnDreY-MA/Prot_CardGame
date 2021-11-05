using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int health;
    [SerializeField] private GameObject placeCard;
    [SerializeField] private GameObject cardDeck;

    private Text textHealth;

    private RectTransform posCard;

    private Vector2 startPos;

    private Animator animDeck;

    private int countClick = 0;

    private void Start()
    {
        animDeck = cardDeck.gameObject.GetComponent<Animator>();
        posCard = GetComponent<RectTransform>();
        startPos = posCard.anchoredPosition;
        textHealth = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        textHealth.text = health.ToString();
        if (Input.GetKeyDown(KeyCode.Q))
            health -= 1;
    }

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        posCard.anchoredPosition = new Vector2(posCard.anchoredPosition.x, posCard.anchoredPosition.y + 5f);        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        posCard.anchoredPosition = startPos;
    }*/



    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (countClick == 0)
        {
            countClick += 1;
            placeCard.GetComponent<SpriteRenderer>().color = Color.red;
            animDeck.SetBool("Active", true);
        }
        else
        {
            countClick = 0;
            placeCard.GetComponent<SpriteRenderer>().color = Color.white;
            animDeck.SetBool("Active", false);
        }
    }

    
}
