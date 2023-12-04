using System.Collections;
using System.Collections.Generic;
using _Main.Scripts;
using UnityEngine;

public class GameModel : Singleton<GameModel>
{
    [SerializeField]
    private Transform player;

    

    public Transform Player => player;

   

    protected override void Awake()
    {
        base.Awake();
    }
}