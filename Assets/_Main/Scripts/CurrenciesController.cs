using System.Collections;
using System.Collections.Generic;
using _Main.Scripts;
using UnityEngine;

public class CurrenciesController : Singleton<CurrenciesController>
{
    [SerializeField]
    private float principalCurrency, secundaryCurrency;

    public float PrincipalCurrency
    {
        get => principalCurrency;
        set => principalCurrency = value;
    }
    public float SecundaryCurrency
    {
        get => secundaryCurrency;
        set => secundaryCurrency = value;
    }
    
}