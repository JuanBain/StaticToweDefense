using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }

    public virtual void MoveEnemy(Vector3 newPosition)
    {
        transform.DOMove(newPosition, 10f / MoveSpeed).OnComplete(() =>
        {
            Debug.Log("Complete");
            Debug.Log("Move");
        }).Play();
    }
    
}