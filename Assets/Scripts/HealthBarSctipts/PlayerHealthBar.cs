
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Image HealthBar;
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MaxHealth;


    void Start()
    {

        HealthBar = GetComponent<Image>();

        MaxHealth = Monster.PlayerHealth;
    }

    void Update()
    {
        CurrentHealth = Monster.PlayerHealth;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
