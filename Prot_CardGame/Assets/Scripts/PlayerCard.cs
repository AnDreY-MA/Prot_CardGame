using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour, IPointerClickHandler
{
    [Header("Stats")]
    [SerializeField] private int healthPoints;
    [SerializeField] private int magicPoints;

    [Header("Objects")]
    [SerializeField] private GameObject cardDeck;
    [SerializeField] private TurnSystem turnSystem;

    [Header("Text")]
    [SerializeField] private Text textHP;
    [SerializeField] private Text textMP;

    private RectTransform posCard;

    private Vector2 startPos;

    private Animator animDeck;

    private int countClick = 0;

    public bool IsActiveDeck { get; private set; }

    private void Start()
    {
        animDeck = cardDeck.gameObject.GetComponent<Animator>();
        posCard = GetComponent<RectTransform>();
        startPos = posCard.anchoredPosition;
    }

    private void Update()
    {
        ViewStats();
        if(!turnSystem.PlayerTurn)
            animDeck.SetBool("Active", false);
    }

    private void ViewStats()
    {
        textHP.text = healthPoints.ToString();
        textMP.text = magicPoints.ToString();
        if (Input.GetKeyDown(KeyCode.Q))
            healthPoints -= 1;
        if (Input.GetKeyDown(KeyCode.E))
            magicPoints += 1;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ActivateCard();
    }

    private void ActivateCard()
    {
        if (turnSystem.PlayerTurn)
        {
            if (countClick == 0)
            {
                countClick += 1;
                animDeck.SetBool("Active", true);
                IsActiveDeck = true;
            }
            else
            {
                countClick = 0;
                animDeck.SetBool("Active", false);
                IsActiveDeck = false;
            }
        }
        else
            return;
    }
}
