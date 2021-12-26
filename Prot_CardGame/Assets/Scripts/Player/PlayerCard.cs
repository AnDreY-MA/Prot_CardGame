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

    public event Action<int> OnHealthChange;
    public event Action<int> OnEnergyChange;
    public event Action<int> OnDamageChange;

    private TimerAttack _timerAttack;

    #region Behavior

    private void OnEnable()
    {
        _timerAttack = FindObjectOfType<TimerAttack>();
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
        else if (_timerAttack.IsPlayerAttack == false)
        {
            transform.position = _startPosPlayer.position;
            transform.rotation = _startPosPlayer.rotation;
        }
    }

    public void SetDamage(int damage)
    {
        _healthPoints -= damage;
        
        if (OnHealthChange != null)
            OnHealthChange.Invoke(_healthPoints);
        if (OnDamageChange != null)
            OnDamageChange.Invoke(damage);
    }

    public void SetHeal(int healPoint)
    {
        _healthPoints += healPoint;
    }

    public void SetEnergyPoints(int energyPoints)
    {
        _energyPoints -= energyPoints;
        if (OnEnergyChange != null)
            OnEnergyChange.Invoke(_energyPoints);
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
