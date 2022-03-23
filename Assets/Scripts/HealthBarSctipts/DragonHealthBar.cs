
using UnityEngine;
using UnityEngine.UI;

public class DragonHealthBar : MonoBehaviour
{
    private Image HealthBar;
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MaxHealth;


    void Start()
    {

        HealthBar = GetComponent<Image>();

        MaxHealth = Monster.DragonHealth;
    }

    void Update()
    {
        CurrentHealth = Monster.DragonHealth;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
