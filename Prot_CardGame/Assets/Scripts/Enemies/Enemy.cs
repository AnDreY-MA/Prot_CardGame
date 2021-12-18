using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private DataEnemy _dataEnemy;
    [SerializeField] private TextMesh _textDamage;
    
    private bool _selecting;
    public bool IsSelectEnemy => _selecting;

    private bool _isAttacking;

    private int _health;
    private int countAttack = 1;

    private SpriteRenderer _spriteEnemy;

    private PlayerCard _player;
    private TimerAttack _timerAttack;

    #region Behaviour
    private void Start()
    {
        _spriteEnemy = GetComponent<SpriteRenderer>();
        _spriteEnemy.sprite = _dataEnemy.spriteEnemy;
        _player = FindObjectOfType<PlayerCard>();
        _timerAttack = FindObjectOfType<TimerAttack>();
        _health = _dataEnemy.health;
        _textDamage.gameObject.SetActive(false);
    }

    private void Update()
    {
        CheckDamage();
        CheckAttack();
    }

    private void OnMouseDown()
    {
        if (_selecting == false && _timerAttack.IsPlayerAttack) _selecting = true;
        else _selecting = false;
    }
    #endregion 
    public void CheckAttack()
    {
        if (_timerAttack.IsPlayerAttack == false && countAttack == 1)
        {
            _player.SetDamage(_dataEnemy.attackDamage);
            countAttack = 0;
        }
        if (_timerAttack.IsPlayerAttack == true) countAttack = 1;
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
        _selecting = false;
    }

    private IEnumerator ViewDamage(int damage)
    {
        _textDamage.gameObject.SetActive(true);
        _textDamage.text = "-" + damage.ToString();
        yield return new WaitForSeconds(0.5f);
        _textDamage.gameObject.SetActive(false);
    }
}
