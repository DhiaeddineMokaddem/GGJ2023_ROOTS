using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image healthSlider;
    public TextMeshProUGUI healthText;
    //public Gradient gradient;
    public Image fill;
    private float maxHealth;
    public Image fakeFill;
    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
        fakeFill.fillAmount = fakeFill.fillAmount - (fakeFill.fillAmount - healthSlider.fillAmount) / 10;
    }
    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        healthSlider.fillAmount = maxHealth;
        healthText.text = maxHealth.ToString("0");
    }
    public void SetHealth(float health)
    {
        healthSlider.fillAmount = health / maxHealth;
        healthText.text = health.ToString("0");
    }
}