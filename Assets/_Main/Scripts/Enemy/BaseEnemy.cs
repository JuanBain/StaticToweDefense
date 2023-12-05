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

    [SerializeField]
    private float timeInCollider;

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
            TakeDamage(PlayerController.Instance.Damage);
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timeInCollider += Time.deltaTime;
            if (timeInCollider >= 1)
            {
                PlayerController.Instance.TakeDamage(damage);
                timeInCollider = 0;
            }
        }
    }

    public virtual void TakeDamage(float damage)
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
        WavesController.Instance.RemoveEnemy(this);
        Destroy(this.gameObject);
    }


    public virtual void Initialize(float newHealth, float newDamage)
    {
        this.health = newHealth;
        this.damage = newDamage;
        currentHealth = newHealth;
    }
}