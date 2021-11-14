using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 5;

    private ActiveSystem _activeSystem;
    private TurnSystem _turnSystem;

    private void Start()
    {
        _activeSystem = FindObjectOfType<ActiveSystem>();
        _turnSystem = FindObjectOfType<TurnSystem>();
    }

    private void Update()
    {
        CheckDamage();
    }

    private void CheckDamage()
    {
        if (_turnSystem.PlayerTurn == false)
        {
            _health -= _activeSystem.DamageCard;
        }

        if (_health <= 0)
            Destroy(gameObject);
    }
}
