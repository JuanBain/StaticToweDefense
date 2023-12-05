using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float range, damage, health, timeToShoot, bulletSpeed;

    [SerializeField]
    private float currentHealth;

    [SerializeField]
    private Image healthBar;

    private void Start()
    {
        currentHealth = health;
        UpdateHealthBar();
    }

    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    public float TimeToShoot
    {
        get => timeToShoot;
        set => timeToShoot = value;
    }

    public float BulletSpeed
    {
        get => bulletSpeed;
        set => bulletSpeed = value;
    }

    //TODO change player stats to singleton 
    public float Range
    {
        get => range;
        set => range = value;
    }

    public float CurrentHealth => currentHealth;


    public Transform Player => player;

    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Debug.Log("You are death");
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / health;
        UIStatsController.Instance.UpdateHealth();
    }

    protected override void Awake()
    {
        base.Awake();
    }
}