using Shooting.Bullets;
using UnityEngine;

namespace Shooting.Weapons
{
    public class BallisticBulletWeapon : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private BallisticBullet _bulletPrefab;
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _targetMask;

        public void Shoot()
        {
            var position = transform.position;
            var direction = _camera.transform.forward;
            Shoot(position, direction);
        }

        private void Shoot(Vector3 position, Vector3 direction)
        {
            var bullet = Instantiate(_bulletPrefab, position, Quaternion.identity);
            bullet.SetVelocity(direction * _bulletSpeed);
            bullet.SetTargetMask(_targetMask);
        }
    }
}