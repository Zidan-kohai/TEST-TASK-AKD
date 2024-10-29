using System;
using UnityEngine;
using UnityEngine.Events;

namespace Feature.Quest
{
    public class Quest
    {
        /// <summary>
        /// The first argument is the progress, and the second one determines whether the reward can be claimed.
        /// </summary>
        public UnityEvent<int, bool> OnStateChange = new();

        public event Action OnClaim;

        private readonly QuestConfig _config;

        private readonly QuestData _data;

        public QuestType GetQuestType => _config.QuestType;
        public int GetMaxProgress => _config.MaxProgress;
        public int GetCurrentProgress => _data.Progress;
        public string GetDescription => _config.Description;
        public bool GetIsClaimed => _data.IsClaimed;
        public string GetRewardText => _config.RewardText;

        public Quest(QuestConfig config, UnityEvent onClaim = null, QuestData data = null)
        {
            _config = config;
            _data = data ?? new();
            OnClaim = () => onClaim?.Invoke();
        }

        public void Increament(int delta)
        {
            if (_data.Progress >= _config.MaxProgress) return;

            _data.Progress += delta;

            _data.Progress = Mathf.Clamp(_data.Progress, 0, _config.MaxProgress + 1);

            bool canClaimed = !_data.IsClaimed && _data.Progress >= _config.MaxProgress;

            OnStateChange?.Invoke(_data.Progress, canClaimed);
        }

        public void Claim()
        {
            if (_data.Progress < _config.MaxProgress) return;

            _data.IsClaimed = true;

            OnClaim?.Invoke();
        }
    }
}