using UnityEngine;
using UnityEngine.UI;

public class TimerAttack : MonoBehaviour
{
    [SerializeField] private float _maxTime = 10;

    private bool _isAttack = true;

    private Image _lineTime;

    private float _leftTime;

    private void Start()
    {
        _lineTime = GetComponent<Image>();
        _leftTime = _maxTime;
    }

    private void Update()
    {
        if (_leftTime > 0 && _isAttack)
        {
            _leftTime -= Time.deltaTime * 2;
            _lineTime.fillAmount = _leftTime / _maxTime;
        }
    }
}
