using System;
using System.Collections;
using Enemies.Data;
using UnityEngine;

namespace Enemies
{
    public class RedEnemy : Enemy
    {
        [SerializeField] private RedEnemyData config;
        private Transform _player;
        private void Setup(Transform player)
        {
            _player = player;
        }

        public void Attack(Transform player)
        {
            Setup(player);
            
        }

        private IEnumerator FlyAbove()
        {
            throw new NotImplementedException();
        }
    }
}
