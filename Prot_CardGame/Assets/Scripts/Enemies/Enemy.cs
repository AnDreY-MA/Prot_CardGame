using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private DataEnemy _dataEnemy;
    [SerializeField] private TextMesh _textDamage;

    private float _delayAttack = 2;

    private int _health;

    private SpriteRenderer _spriteEnemy;

    private PlayerCard _player;
    private TurnSystem _turnSystem;

    private void Start()
    {
        _spriteEnemy = GetComponent<SpriteRenderer>();
        _spriteEnemy.sprite = _dataEnemy.spriteEnemy;
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
            float time = Mathf.Round(_delayAttack);

            if(time == 0)
            {
                _player.SetDamage(_dataEnemy.attackDamage);
                _turnSystem.SwitchTurn();
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
