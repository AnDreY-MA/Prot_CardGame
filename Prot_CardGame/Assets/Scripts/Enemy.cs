using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private ParticleSystem _effectDamage;

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
            SetLifeTimeParticle();
        }

        if (_health <= 0)
            Destroy(gameObject);
    }

    private void SetLifeTimeParticle()
    {
        _effectDamage.Stop();

        var particleMainSetting = _effectDamage.main;
        particleMainSetting.startLifetime = 1f;

        _effectDamage.Play();
    }
}
