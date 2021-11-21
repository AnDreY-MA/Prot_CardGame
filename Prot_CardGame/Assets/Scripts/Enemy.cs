using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private ParticleSystem _effectDamage;

    private ActiveSystem _activeSystem;
    private TurnSystem _turnSystem;

    public static Enemy EnemyS { get; private set; }

    private void Start()
    {
        EnemyS = GetComponent<Enemy>();
        _activeSystem = FindObjectOfType<ActiveSystem>();
        _turnSystem = FindObjectOfType<TurnSystem>();
    }

    private void Update()
    {
        CheckDamage();
    }

    private void CheckDamage()
    {
        /*if (_turnSystem.PlayerTurn == false)
        {
            _health -= _activeSystem.DamageCard;
            Debug.Log("Damage");
        }*/

        if (_health <= 0)
            Destroy(gameObject);
    }

    public void SetDamageEnemy(int damage)
    {
        _health -= damage;
        SetLifeTimeParticle();
    }

    private void SetLifeTimeParticle()
    {
        _effectDamage.Stop();

        var particleMainSetting = _effectDamage.main;
        particleMainSetting.startLifetime = 1f;

        _effectDamage.Play();
    }
}
