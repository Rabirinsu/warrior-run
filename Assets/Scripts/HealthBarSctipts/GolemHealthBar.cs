
using UnityEngine;
using UnityEngine.UI;

public class GolemHealthBar : MonoBehaviour
{
    private Image HealthBar;
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MaxHealth;
  

    void Start()
    {

        HealthBar = GetComponent<Image>();
        MaxHealth = Monster.golemHealth;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Monster.golemHealth;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
