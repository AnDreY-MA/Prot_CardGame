using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    [SerializeField] private Ability[] _abilityCards;
    [SerializeField] private Transform[] _placesHand;

    private void OnEnable()
    {
        for (int i = 0; i < _abilityCards.Length; i++)
        {
            _abilityCards[i].SetStartPlace(_placesHand[i].transform);
            Instantiate(_abilityCards[i], transform);
        }
    }

}
