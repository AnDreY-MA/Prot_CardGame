using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _energyPoints;
    [SerializeField] private TextMesh _textHP;
    [SerializeField] private TextMesh _textEP;

    [SerializeField] GameObject _abilityCards;
    [SerializeField] Transform _placeHand;

    [SerializeField] private Transform _startPosPlayer;

    private TurnSystem _turnSystem;
    private ActiveSystem _activeSystem;


    #region Behavior

    private void Start()
    {
        _turnSystem = FindObjectOfType<TurnSystem>();
        _activeSystem = FindObjectOfType<ActiveSystem>();
    }

    private void Update()
    {
        ViewStats();
        CheckTurn();
    }
    #endregion

    private void CheckTurn()
    {
        _abilityCards.SetActive(_turnSystem.PlayerTurn);

        if (_turnSystem.PlayerTurn)
        {
            transform.position = _placeHand.position;
            transform.rotation = _placeHand.rotation;
        }
        else if (_turnSystem.PlayerTurn == false)
        {
            transform.position = _startPosPlayer.position;
            transform.rotation = _startPosPlayer.rotation;
        }
    }

    private void ViewStats()
    {
        _textHP.text = _healthPoints.ToString();
        _textEP.text = _energyPoints.ToString();
        
        if(_turnSystem.PlayerTurn == false)
            _energyPoints -= _activeSystem.PriceAttack;

        if (Input.GetKeyDown(KeyCode.Q))
            _healthPoints -= 1;
        if (Input.GetKeyDown(KeyCode.E))
            _energyPoints -= 1;
    }

    public void SetHeal(int healPoint)
    {
        _healthPoints += healPoint;
    }

    public void SetEnergyPoints(int energyPoints)
    {
        _energyPoints -= energyPoints;
    }
}
