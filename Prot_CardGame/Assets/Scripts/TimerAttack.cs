using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerAttack : MonoBehaviour
{
    [SerializeField] private float _maxTime = 10f;
    [SerializeField] private float _speedTime = 2f;
    [SerializeField] private float _delayTime = 0.5f;

    public Action OnTimeChanged;

    private bool _isPlayerAttack = true;
    public bool IsPlayerAttack => _isPlayerAttack;

    private Image _lineTime;

    private float _leftTime;

    private void Start()
    {
        _lineTime = GetComponent<Image>();
        _leftTime = _maxTime;
    }

    private void Update()
    {
        WorkTimer();
    }

    private void WorkTimer()
    {
        if (_isPlayerAttack == true)
        {
            _leftTime -= Time.deltaTime;          
            if (_leftTime <= 0) _isPlayerAttack = false;
        }

        _lineTime.fillAmount = _leftTime / _maxTime;
        
        StartCoroutine(TimeUpdate());
    }

    public IEnumerator TimeUpdate()
    {
        if (_isPlayerAttack == false)
        {
            yield return new WaitForSeconds(1);
            _leftTime += Time.deltaTime * _speedTime * 2;
            if (_leftTime >= _maxTime) _isPlayerAttack = true;
        }
    }

    public void SwitchTimer() => _leftTime = 0;
}
