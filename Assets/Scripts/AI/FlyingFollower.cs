using System.Collections;
using UnityEngine;

namespace AI
{
    public class FlyingFollower : MonoBehaviour
    {
        private Transform _follower;
        private Transform _target;
        private float _speed;
        private Coroutine _followCorout;
        public void Follow(Transform follower, Transform target, float speed)
        {
            _follower = follower;
            _target = target;
            _speed = speed;
            if (_followCorout != null)
            {
                StopCoroutine(_followCorout);
            }

            StartCoroutine(FolowCorout());
        }
        private IEnumerator FolowCorout()
        {
            float simulaitonStep = .025f;
            WaitForSeconds wait = new WaitForSeconds(simulaitonStep);
            while (true)
            {
                yield return wait;
                Vector3 direction = (_target.position - _follower.position).normalized;
                _follower.position += direction * _speed * simulaitonStep;
            }
        }
    }
}
