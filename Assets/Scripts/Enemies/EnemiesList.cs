using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class EnemiesList : MonoBehaviour
    {
        [SerializeField] private int enemiesCount;
        [HideInInspector] public List<Enemy> Enemies = new List<Enemy>();


        public void RegisterEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
        }

        public void UnregisterEnemy(Enemy enemy)
        {
            Enemies.Remove(enemy);
        }

        private void Update()
        {
            enemiesCount = Enemies.Count;
        }
    }
}