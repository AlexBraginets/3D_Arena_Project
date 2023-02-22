using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Data
{
    [CreateAssetMenu]
    public class BallisticBulletRewardConfig : ScriptableObject
    {
        [SerializeField] private Reward[] _rewards;
        public void ApplyReward(Player player)
        {
            var rewardType = Random.value < .5f ? RewardType.Health : RewardType.UltimatePower;
            var reward = GetReward(rewardType);
            switch (rewardType)
            {
                case RewardType.Health:
                    player.AddHealth(reward.Amount);
                    break;
                case RewardType.UltimatePower:
                    player.AddPower(reward.Amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Reward GetReward(RewardType rewardType)
        {
            return _rewards.First(reward => reward.Type == rewardType);
        }
    }
}
