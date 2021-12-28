using UnityEngine;

public class ActivedCard : MonoBehaviour
{
    private Ability _ability = null;

    public Ability ActivededCard => _ability;

    public void SetAbilityCard(Ability ability) => _ability = ability;

    public void RemoveAbilityCard() => _ability = null; 
}
