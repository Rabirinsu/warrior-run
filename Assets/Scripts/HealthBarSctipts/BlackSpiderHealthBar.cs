
using UnityEngine;
using UnityEngine.UI;

public class BlackSpiderHealthBar : MonoBehaviour
{
    private Image HealthBar;
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MaxHealth;


    void Start()
    {

        HealthBar = GetComponent<Image>();

        MaxHealth = Monster.BlackSpiderHealth;
    }

    void Update()
    {
        CurrentHealth = Monster.BlackSpiderHealth;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
