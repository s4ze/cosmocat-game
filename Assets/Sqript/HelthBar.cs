using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private ShipLogic playerHealth;

    void Start()
    {
        SetMaxHealth(playerHealth.health);
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth(playerHealth.HP);
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

}
