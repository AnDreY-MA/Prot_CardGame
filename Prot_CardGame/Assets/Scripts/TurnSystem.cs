using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    private bool _turnPlayer;
    public bool PlayerTurn => _turnPlayer;

    public bool TurnClick { get; private set; }

    private Enemy[] _enemy;
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
        _enemy = FindObjectsOfType<Enemy>();
    }

    public void SwitchTurn()
    {
        if (_timerAttack.IsPlayerAttack)
        {
            CheckAttack();
            _timerAttack.SwitchTimer();
        }

        TurnClick = true;
    }

    private void CheckAttack()
    {
        if (_activeSystem.CardType == TypeCard.Attack)
        {
            _player.SetEnergyPoints(_activeSystem.PriceAttack);
            /*_enemy.SetDamageEnemy(_activeSystem.DamageCard);*/
            EnumerationEnemy();
        }
        else if (_activeSystem.CardType == TypeCard.Heal)
        {
            _player.SetEnergyPoints(_activeSystem.PriceAttack);
            _player.SetHeal(_activeSystem.DamageCard);
        }
    }

    private void EnumerationEnemy()
    {
        foreach (Enemy e in _enemy)
        {
            if (e.IsSelectEnemy == true)
                e.SetDamageEnemy(_activeSystem.DamageCard);
        }
    }
}
