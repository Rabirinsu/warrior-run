
using UnityEngine;
using UnityEngine.UI;

public class SpiderHealthBar : MonoBehaviour
{
    private Image HealthBar;
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MaxHealth;


    void Start()
    {

        HealthBar = GetComponent<Image>();

        MaxHealth = Monster.spiderHealth;
    }

    void Update()
    {
        CurrentHealth = Monster.spiderHealth;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
