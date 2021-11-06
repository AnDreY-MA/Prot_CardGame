using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    private PlayerCard playerCard;

    private Text turnText;

    public bool PlayerTurn { get; private set; }

    public bool ButtonClick { get; private set; }

    private void Start()
    {
        playerCard = FindObjectOfType<PlayerCard>();
        turnText = GetComponent<Text>();
        PlayerTurn = true;
        turnText.text = "You turn";
    }

    public void SwitchTurn()
    {
        if (PlayerTurn == true)
        {
            turnText.text = "Enemy turn";
            PlayerTurn = false;
        }
        else if (PlayerTurn == false)
        {
            turnText.text = "You turn";
            PlayerTurn = true;
        }
    }
}
