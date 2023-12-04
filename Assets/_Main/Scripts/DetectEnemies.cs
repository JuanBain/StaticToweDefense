using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectEnemies : MonoBehaviour
{
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy in range");
            EnemysController.Instance.EnemiesInRange.Add(other.gameObject.GetComponent<BaseEnemy>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy out of range");
            EnemysController.Instance.EnemiesInRange.Remove(other.gameObject.GetComponent<BaseEnemy>());
        }
    }
}