using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float maxHealth;
    public float health;
    Image heathBarImg;

    private void Start()
    {
        heathBarImg = GetComponent<Image>();
    }

    public void Damage(float damage)
    {
        health -= damage;
        heathBarImg.fillAmount = health / 100;
    }
}
