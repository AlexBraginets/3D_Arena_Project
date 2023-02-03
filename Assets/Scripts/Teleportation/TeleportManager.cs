using UnityEngine;
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
            int rndIdx = Random.Range(0, teleportPoints.Length);
            Transform rndPoint = teleportPoints[rndIdx];
            return rndPoint.position;
        }
    }
}
