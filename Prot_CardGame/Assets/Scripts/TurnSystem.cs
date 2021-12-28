using UnityEngine;
using System;

public class TurnSystem : MonoBehaviour
{
    private bool _turnPlayer;
    public bool TurnPlayer => _turnPlayer;

    public bool TurnClick { get; private set; }

    public Action<Enemy> OnEnemyChange;

    private ActiveSystem _activeSystem;
    private PlayerCard _player;
    private TimerAttack _timerAttack;

    private void Start()
    {
        _player = FindObjectOfType<PlayerCard>();
        _timerAttack = FindObjectOfType<TimerAttack>();
        _activeSystem = FindObjectOfType<ActiveSystem>();
        _turnPlayer = true;
    }

    private void Update()
    {
        TurnClick = false;
    }

    public void SwitchTurn()
    {
        if (_timerAttack.IsPlayerAttack)
        {
            CheckAttack();
            _timerAttack.SwitchTimer();
            _activeSystem.RemoveDataCard();
        }

        TurnClick = true;
    }

    private void CheckAttack()
    {
        if (_activeSystem.CardType == TypeCard.ATTACK)
        {
            _player.SetEnergyPoints(_activeSystem.PriceAttack);
            OnEnemyChange?.Invoke(_activeSystem.TargetEnemy);
            if(_activeSystem.TargetEnemy != null) _activeSystem.TargetEnemy.SetDamageEnemy(_activeSystem.DamageCard);
        }
        else if (_activeSystem.CardType == TypeCard.HEAL)
        {
            _player.SetEnergyPoints(_activeSystem.PriceAttack);
            _player.SetHeal(_activeSystem.DamageCard);
        }
    }
}
