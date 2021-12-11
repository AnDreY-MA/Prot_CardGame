using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    private Text turnText;

    private bool _turnPlayer;
    public bool PlayerTurn => _turnPlayer;

    public bool TurnClick { get; private set; }

    private Enemy _selectEnemy;

    private Enemy[] _enemy;
    private ActiveSystem _activeSystem;
    private PlayerCard _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerCard>();
        
        _activeSystem = FindObjectOfType<ActiveSystem>();
        turnText = GetComponent<Text>();
        _turnPlayer = true;
        turnText.text = "You turn";
    }

    private void Update()
    {
        TurnClick = false;
        _enemy = FindObjectsOfType<Enemy>();
    }

    public void SwitchTurn()
    {
        if (_turnPlayer == true)
        {
            turnText.text = "Enemy turn";
            _turnPlayer = false;
            CheckAttack();
        }
        else if (_turnPlayer == false)
        {
            turnText.text = "You turn";
            _turnPlayer = true;
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
