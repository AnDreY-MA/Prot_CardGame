using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    private Text turnText;

    private bool _turnPlayer;
    public bool PlayerTurn => _turnPlayer;

    public bool TurnClick { get; private set; }

    private void Start()
    {
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
        }
        else if (PlayerTurn == false)
        {
            turnText.text = "You turn";
            _turnPlayer = true;
        }

        TurnClick = true;
    }
}
