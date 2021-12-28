using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PlayerCard : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _energyPoints;

    [SerializeField] GameObject _handDeck;
    [SerializeField] Transform _placeHand;

    [SerializeField] private Transform _startPosPlayer;

    #region Events
    public event Action<int> OnHealthChange;
    public event Action<int> OnEnergyChange;
    public event Action<int> OnDamageChange;
    #endregion

    private bool _isAttacking = false;

    private TurnSystem _turnSystem;
    private TimerAttack _timerAttack;

    #region Behavior

    private void OnEnable()
    {
        _timerAttack = FindObjectOfType<TimerAttack>();
        _turnSystem = FindObjectOfType<TurnSystem>();
        _turnSystem.OnEnemyChange += Attack;
    }

    private void OnDisable()
    {
        _turnSystem.OnEnemyChange -= Attack;
    }

    private void Update()
    {
        _healthPoints = Mathf.Clamp(_healthPoints, 0, 100);
        _energyPoints = Mathf.Clamp(_energyPoints, 0, 100);
        CheckTurn();
    }
    #endregion

    private void CheckTurn()
    {
        _handDeck.SetActive(_timerAttack.IsPlayerAttack);

        if (_timerAttack.IsPlayerAttack == true)
        {
            transform.position = _placeHand.position;
            transform.rotation = _placeHand.rotation;
        }
        if (_isAttacking == false)
        {
            transform.position = _startPosPlayer.position;
            transform.rotation = _startPosPlayer.rotation;
            _isAttacking = true;
        }
    }

    private void Attack(Enemy enemy)
    {
        StartCoroutine(CheckAttack(enemy));
    }

    private IEnumerator CheckAttack(Enemy enemy)
    {
        if (enemy == null) 
            yield break;
        transform.position = enemy.transform.position;
        yield return new WaitForSeconds(1f);
        _isAttacking = false;
    }

    public void SetDamage(int damage)
    {
        _healthPoints -= damage;
     
        OnHealthChange?.Invoke(_healthPoints);
        OnDamageChange?.Invoke(damage);
    }

    public void SetHeal(int healPoint)
    {
        _healthPoints += healPoint;
    }

    public void SetEnergyPoints(int energyPoints)
    {
        _energyPoints -= energyPoints;
        OnEnergyChange?.Invoke(_energyPoints);
    }

    public int GetHealth()
    {
        return _healthPoints;
    }

    public int GetEnergy()
    {
        return _energyPoints;
    }
}
