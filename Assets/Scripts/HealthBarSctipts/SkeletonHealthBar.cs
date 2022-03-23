
using UnityEngine;
using UnityEngine.UI;

public class SkeletonHealthBar : MonoBehaviour
{
    private Image HealthBar;
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MaxHealth;


    void Start()
    {

        HealthBar = GetComponent<Image>();

        MaxHealth = Monster.SkeletonHealth;
    }

    void Update()
    {
        CurrentHealth = Monster.SkeletonHealth;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
