using UnityEngine;
using System.Collections;

public class PlayerStatsBar : MonoBehaviour
{
    [SerializeField] private PlayerCard _player;
    [SerializeField] private TextMesh _healthText;
    [SerializeField] private TextMesh _energyText;
    [SerializeField] private TextMesh _takingDamage;

    private void OnEnable()
    {
        _healthText.text = _player.GetHealth().ToString();
        _energyText.text = _player.GetEnergy().ToString();
        _player.OnHealthChange += UpdateHealth;
        _player.OnEnergyChange += UpdateEnergy;
        _player.OnDamageChange += SetViewDamage;
    }

    private void OnDisable()
    {
        _player.OnHealthChange -= UpdateHealth;
        _player.OnEnergyChange -= UpdateEnergy;
        _player.OnDamageChange -= SetViewDamage;
    }

    private void UpdateHealth(int health)
    {
        if (_player == null) return;
        _healthText.text = health.ToString();
    }

    private void UpdateEnergy(int energy)
    {
        if (_player == null) return;
        _energyText.text = energy.ToString();
    }

    private void SetViewDamage(int damage) => StartCoroutine(ViewDamage(damage));
    
    private IEnumerator ViewDamage(int damage)
    {
        _takingDamage.gameObject.SetActive(true);
        _takingDamage.text = $"-{damage}";
        yield return new WaitForSeconds(0.5f);
        _takingDamage.gameObject.SetActive(false);
    }
}
