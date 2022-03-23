
using UnityEngine;
using UnityEngine.UI;

public class BlackGolemHealthBar : MonoBehaviour
{
    private Image HealthBar;
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MaxHealth;


    void Start()
    {

        HealthBar = GetComponent<Image>();

        MaxHealth = Monster.BlackGolemHealth;
    }

    void Update()
    {
        CurrentHealth = Monster.BlackGolemHealth;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
