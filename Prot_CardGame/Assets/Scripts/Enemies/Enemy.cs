using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private DataEnemy _dataEnemy;
    [SerializeField] private TextMesh _textDamage;
    [SerializeField] private UnityEvent _eventEnemy = new UnityEvent();

    private float _delayAttack = 2;

    private int _health;

    private PlayerCard _player;
    private TurnSystem _turnSystem;

    private void Start()
    {
        _player = FindObjectOfType<PlayerCard>();
        _turnSystem = FindObjectOfType<TurnSystem>();
        _health = _dataEnemy.health;
        _textDamage.gameObject.SetActive(false);
    }

    private void Update()
    {
        CheckDamage();
        CheckAttack();
    }
    
    public void CheckAttack()
    {
        if (_turnSystem.PlayerTurn == false)
        {
            _delayAttack -= Time.deltaTime;
            float t = Mathf.Round(_delayAttack);

            if(t == 0)
            {
                _player.SetDamage(_dataEnemy.attackDamage);
                _eventEnemy?.Invoke();
                _delayAttack = 2;
            }
        }
    }

    private void CheckDamage()
    {   
        if (_health <= 0)
            Destroy(gameObject);
    }

    public void SetDamageEnemy(int damage)
    {
        StartCoroutine(ViewDamage(damage));
        _health -= damage;
    }

    private IEnumerator ViewDamage(int damage)
    {
        _textDamage.gameObject.SetActive(true);
        _textDamage.text = "-" + damage.ToString();
        yield return new WaitForSeconds(0.5f);
        _textDamage.gameObject.SetActive(false);
    }
}
