using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _energyPoints;
    [SerializeField] private TextMesh _textHP;
    [SerializeField] private TextMesh _textEP;

    [SerializeField] GameObject _abilityCards;

    private Animator animDeck;

    private TurnSystem _turnSystem;

    private bool _isTurnPlayer;
    public bool IsTurnPlayer => _isTurnPlayer;

    private void Awake()
    {
        animDeck = _abilityCards.gameObject.GetComponent<Animator>();
        _turnSystem = FindObjectOfType<TurnSystem>();
    }

    private void Update()
    {
        ViewStats();
        CheckTurn();
    }

    private void CheckTurn()
    {
        _abilityCards.SetActive(_turnSystem.PlayerTurn);
    }

    private void ViewStats()
    {
        _textHP.text = _healthPoints.ToString();
        _textEP.text = _energyPoints.ToString();
        if (Input.GetKeyDown(KeyCode.Q))
            _healthPoints -= 1;
        if (Input.GetKeyDown(KeyCode.E))
            _energyPoints -= 1;
    }
}
