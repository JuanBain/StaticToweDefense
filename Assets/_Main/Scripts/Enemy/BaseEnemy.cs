using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private float health;

    private float currentHealth;

    public float damage;

    [SerializeField]
    private Image healthBar;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public virtual void MoveEnemy(Vector3 newPosition)
    {
        currentHealth = health;
        transform.DOMove(newPosition, 10f / moveSpeed).OnComplete(() =>
        {
            Debug.Log("Complete");
            Debug.Log("Move");
        }).Play();
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Bullet choco");
            DoDamage(PlayerController.Instance.Damage);
            Destroy(other.gameObject);
        }
    }

    public virtual void DoDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / health;
    }

    private void KillEnemy()
    {
        EnemysController.Instance.Enemies.Remove(this);
        EnemysController.Instance.EnemiesInRange.Remove(this);
        Destroy(this.gameObject);
    }

    public virtual void DoDamage()
    {
    }
}