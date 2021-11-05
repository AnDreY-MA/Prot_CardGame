using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class HandCardManager : MonoBehaviour
{
    [SerializeField] private GameObject objectActive;
    [SerializeField] private AbilityCard card = null;

    private bool active;

    private Image activeCard;

    private void Start()
    {
        activeCard = objectActive.GetComponent<Image>();
    }

    private void Update()
    {
        if(card)
            activeCard.sprite = card.imgCard.sprite;
    }
}
