using System.Collections.Generic;
using System.Linq;
using Enemies;
using UnityEngine;
using Utils;

namespace Metrics
{
    public class ProximityEnemyProvider : MonoBehaviour
    {
        private List<Enemy> Enemies => ReferencesHolder.Instance.EnemiesList.Enemies;

        public Enemy ClosestEnemy(Vector3 position, Enemy excludeEnemy)
        {
            return Enemies.Where(enemy => enemy != excludeEnemy)
                .OrderBy(enemy => Vector3.Distance(enemy.Position, position)).FirstOrDefault();
        }
    }
}