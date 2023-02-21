using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class EnemiesList : MonoBehaviour
    {
        [HideInInspector] public List<Enemy> Enemies = new List<Enemy>();


        public void RegisterEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
        }

        public void UnregisterEnemy(Enemy enemy)
        {
            Enemies.Remove(enemy);
        }
    }
}