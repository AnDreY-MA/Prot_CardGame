using System.Collections;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _energyPoints;
    [SerializeField] private TextMesh _textHP;
    [SerializeField] private TextMesh _textEP;
    [SerializeField] private TextMesh _takingDamage;

    [SerializeField] GameObject _abilityCards;
    [SerializeField] Transform _placeHand;

    [SerializeField] private Transform _startPosPlayer;

    private TurnSystem _turnSystem;
    private ActiveSystem _activeSystem;
    private TimerAttack _timerAttack;

    #region Behavior

    private void Start()
    {
        _turnSystem = FindObjectOfType<TurnSystem>();
        _activeSystem = FindObjectOfType<ActiveSystem>();
        _timerAttack = FindObjectOfType<TimerAttack>();
    }

    private void Update()
    {
        _healthPoints = Mathf.Clamp(_healthPoints, 0, 100);
        _energyPoints = Mathf.Clamp(_energyPoints, 0, 100);
        ViewStats();
        CheckTurn();
    }
    #endregion

    private void CheckTurn()
    {
        _abilityCards.SetActive(_timerAttack.IsPlayerAttack);

        if (_timerAttack.IsPlayerAttack == true)
        {
            transform.position = _placeHand.position;
            transform.rotation = _placeHand.rotation;
        }
        else if (_timerAttack.IsPlayerAttack == false)
        {
            transform.position = _startPosPlayer.position;
            transform.rotation = _startPosPlayer.rotation;
        }
    }

    private void ViewStats()
    {
        _textHP.text = _healthPoints.ToString();
        _textEP.text = _energyPoints.ToString();
        
        if(_turnSystem.TurnPlayer == false)
            _energyPoints -= _activeSystem.PriceAttack;

        if (Input.GetKeyDown(KeyCode.Q))
            _healthPoints -= 1;
        if (Input.GetKeyDown(KeyCode.E))
            _energyPoints -= 1;
    }

    public void SetDamage(int damage)
    {
        _healthPoints -= damage;
        StartCoroutine(ViewDamage(damage));
    }

    private IEnumerator ViewDamage(int damage)
    {
        _takingDamage.gameObject.SetActive(true);
        _takingDamage.text = $"-{damage}";
        yield return new WaitForSeconds(0.5f);
        _takingDamage.gameObject.SetActive(false);
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
