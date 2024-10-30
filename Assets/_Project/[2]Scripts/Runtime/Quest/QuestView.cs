﻿using Feature.Quest;
using TMPro;
using UnityEngine;
using Zenject;

namespace Runtime.Quest
{
    public class QuestView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _questDescription;
        [SerializeField] private TextMeshProUGUI _questProgress;

        private QuestHandler _questHandler;
        private Feature.Quest.Quest _quest;

        [Inject]
        public void Constructor(QuestHandler questHandler)
        {
            _questHandler = questHandler;
        }

        public void Awake()
        {
            if(_questHandler.TryGetQuests(QuestType.moveItemsFromShelfToPickup, out _quest))
            {
                _quest.OnStateChange.AddListener(QuestProgressChange);
            }

            _questDescription.text = _quest.GetDescription;

            QuestProgressChange(_quest.GetCurrentProgress, false);
        }

        private void QuestProgressChange(int progress, bool canClaim)
        {
            _questProgress.text = $"{progress}/{_quest.GetMaxProgress}";
        }
    }
}