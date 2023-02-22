using UnityEngine;

namespace Enemies
{
    public class EnemyReference : MonoBehaviour
    {
        [SerializeField] private Enemy _reference;
        public Enemy Reference => _reference;
    }
}