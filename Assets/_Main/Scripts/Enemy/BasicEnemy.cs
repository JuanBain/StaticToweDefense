using System;
using UnityEngine;

namespace _Main.Scripts
{
    public class BasicEnemy : BaseEnemy
    {
        private void Start()
        {
            MoveEnemy(GameModel.Instance.Player.position);
        }
    }
}