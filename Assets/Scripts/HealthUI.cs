using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Health health;
    public Slider slider;

    void Start()
    {
        if (health != null)
        {
            slider.maxValue = health.maxHealth;
            slider.value = health.currentHealth;
        }
    }

    void Update()
    {
        if (health != null)
        {
            slider.value = health.currentHealth;
        }
    }
}
