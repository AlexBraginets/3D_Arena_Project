using UnityEngine;
using Utils;

namespace Enemies
{
    public class EnemiesDestroyer : MonoBehaviour
    {
        public void KillAllEnemies()
        {
            var enemiesList = ReferencesHolder.Instance.EnemiesList;
            var enemies = enemiesList.Enemies;
            foreach (var enemy in enemies)
            {
                enemy.Kill();
            }
        }
    }
}