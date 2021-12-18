using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerAttack : MonoBehaviour
{
    [SerializeField] private float _maxTime = 10f;
    [SerializeField] private float _speedTime = 2f;

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
        StartCoroutine(WorkTimer());
    }

    private IEnumerator WorkTimer()
    {
        if (_isPlayerAttack == true)
        {
            _leftTime -= Time.deltaTime;          
            if (_leftTime <= 0) _isPlayerAttack = false;
        }

        _lineTime.fillAmount = _leftTime / _maxTime;

        if (_isPlayerAttack == false)
        {
            yield return new WaitForSeconds(1);
            _leftTime += Time.deltaTime * _speedTime;
            if (_leftTime >= _maxTime) _isPlayerAttack = true;
        }
    }

    public void SwitchTimer() => _leftTime = 0;
}
