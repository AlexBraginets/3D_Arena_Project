using UnityEngine;
using Utils;

namespace Shooting
{
    public class TargetBulletWeapon : MonoBehaviour
    {
        [SerializeField] private TargetBullet _targetBulletPrefab;

        private void Awake()
        {
            InvokeRepeating("ShootDemo", 3f, 3f);
        }

        private void ShootDemo()
        {
            var player = ReferencesHolder.Instance.Player;
            var yOffset = .15f;
            Shoot(player.transform, yOffset);
        }

        public void Shoot(Transform target, float yOffset)
        {
            var bullet = Instantiate(_targetBulletPrefab, transform.position, Quaternion.identity);
            bullet.SetTarget(target, yOffset);
        }
    }
}