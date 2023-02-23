using System.Linq;
using Teleportation;
using UnityEngine;
using Utils;

namespace Test
{
    public class TeleportationUtilsTest : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private void OnDrawGizmos()
        {
            Debug.LogError("OnGrawGizmos");
            if (!Application.isPlaying) return;
            var enemies = ReferencesHolder.Instance.EnemiesList.Enemies;
            if (enemies.Count == 0) return;
            float maxRadius = 5f;
            Vector3[] points = enemies.Select(enemy => enemy.Position).ToArray();
            Vector3 furthestPoint = TeleportationUtils.FurthestPoint(points, maxRadius);
            
            Gizmos.DrawSphere(furthestPoint, 1f);
            Debug.LogError("Gizmos.DrawSphere");
            target.position = furthestPoint;
        }
    }
}
