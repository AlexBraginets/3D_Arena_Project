using System.Linq;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Teleportation
{
    public class TeleportManager : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Transform[] teleportPoints;

        private void OnTriggerExit(Collider other)
        {
            if (!other.IsPlayer()) return;
            TeleportPlayer();
        }

        private void TeleportPlayer()
        {
            Vector3 teleportPosition = GetTeleportPosition();
            TeleportPlayer(teleportPosition);
        }

        private void TeleportPlayer(Vector3 position)
        {
            player.position = position;
        }

        private Vector3 GetTeleportPosition()
        {
            var enemies = ReferencesHolder.Instance.EnemiesList.Enemies;
            if (enemies.Count == 0)
            {
                int rndIdx = Random.Range(0, teleportPoints.Length);
                Transform rndPoint = teleportPoints[rndIdx];
                return rndPoint.position;
            }

            float maxRadius = 5f;
            Vector3[] points = enemies.Select(enemy => enemy.Position).ToArray();
            Vector3 furthestPoint = TeleportationUtils.FurthestPoint(points, maxRadius);

            return furthestPoint;
        }
    }
}