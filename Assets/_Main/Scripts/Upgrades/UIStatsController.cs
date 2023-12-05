using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatsController : Singleton<UIStatsController>
{
    [SerializeField]
    private TMP_Text currentAttack, healthText, currentCurrency;

    private void Start()
    {
        UpdateAttack();
        UpdateHealth();
        UpdateCurrency();
    }

    public void UpdateAttack()
    {
        currentAttack.text = $"{PlayerController.Instance.Damage}";
    }

    public void UpdateHealth()
    {
        healthText.text = $"{PlayerController.Instance.CurrentHealth}";
    }

    public void UpdateCurrency()
    {
        currentCurrency.text = $"{CurrenciesController.Instance.SecundaryCurrency}";
    }
}