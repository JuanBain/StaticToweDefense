using System;
using UnityEngine;

namespace _Main.Scripts
{
    public class BasicEnemy : BaseEnemy
    {
        private void Start()
        {
            MoveEnemy(PlayerController.Instance.Player.position);
        }

        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (other.CompareTag("Player"))
            {
                PlayerController.Instance.DoDamage(damage);
            }
        }
    }
}