using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    private Text turnText;

    private bool _turnPlayer;
    public bool PlayerTurn => _turnPlayer;

    public bool TurnClick { get; private set; }

    private ActiveSystem _activeSystem;

    private void Start()
    {
        _activeSystem = FindObjectOfType<ActiveSystem>();
        turnText = GetComponent<Text>();
        _turnPlayer = true;
        turnText.text = "You turn";
    }

    private void Update()
    {
        TurnClick = false;
    }

    public void SwitchTurn()
    {
        if (PlayerTurn == true)
        {
            turnText.text = "Enemy turn";
            _turnPlayer = false;
            Enemy.EnemyS.SetDamageEnemy(_activeSystem.DamageCard);
        }
        else if (PlayerTurn == false)
        {
            turnText.text = "You turn";
            _turnPlayer = true;
        }

        TurnClick = true;
    }
}
