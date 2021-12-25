using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private DataEnemy _dataEnemy;
    [SerializeField] private TextMesh _textDamage;

    private int _health;
    private int countAttack = 1;

    private SpriteRenderer _spriteEnemy;

    private PlayerCard _player;
    private TimerAttack _timerAttack;

    private Animator _animator;

    #region Behaviour
    private void Start()
    {
        _animator = GetComponent<Animator>();
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
        {
            StartCoroutine(DestroyEnemy());
        }    
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("Destroy", true);
        Destroy(gameObject, 2.5f);
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
