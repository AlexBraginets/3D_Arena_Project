using Shooting.Bullets;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Shooting.Weapons
{
    public class TargetBulletWeapon : MonoBehaviour
    {
        [SerializeField] private TargetBullet _targetBulletPrefab;
        [SerializeField] private float _firingRate = 1f / 3f;

        private void Awake()
        {
            InvokeRepeating("ShootDemo", 1f / _firingRate, 1f / _firingRate);
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