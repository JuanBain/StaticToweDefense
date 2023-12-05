using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesController : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField]
    private float incrementalRange, incrementalSpeedAttack, incrementalAttack;

    [SerializeField]
    private int countUpgradesRange, countSpeedAttack, countUpgradesAttack;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void UpgradeRange()
    {
        PlayerController.Instance.Range += incrementalRange;
        PlayerController.Instance.Player.GetComponent<Player>().UpdateRange();
        countUpgradesRange++;
        var incrementCamera = countUpgradesRange / 7;
        mainCamera.orthographicSize = 5 + incrementCamera;
    }

    public void UpgradeSpeedAttack()
    {
        PlayerController.Instance.TimeToShoot -= incrementalSpeedAttack;
        Debug.Log("Shoots per second" + $"{1 / PlayerController.Instance.TimeToShoot}");
        countSpeedAttack++;
    }

    public void UpdateAttack()
    {
        PlayerController.Instance.Damage += incrementalAttack;
        countUpgradesAttack++;
        UIStatsController.Instance.UpdateAttack();
    }
}