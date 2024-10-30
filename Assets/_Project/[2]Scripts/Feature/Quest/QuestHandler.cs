using Infrustructure.Service.Factory;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Feature.Quest
{
    public class QuestHandler
    {
        [SerializeField] private List<QuestConfig> _questConfigs = new List<QuestConfig>();

        private List<Quest> _quests = new List<Quest>();

        private QuestHandler(IFactory factory)
        {
            _questConfigs = factory.GetQuestConfigs();

            InitQuests();
        }

        private void InitQuests()
        {
            foreach (var item in _questConfigs)
            {
                Quest quest = new Quest(item);

                _quests.Add(quest);
            }
        }

        public bool TryGetQuests(QuestType questType, out Quest quest)
        {
            foreach (var item in _quests)
            {
                if (item.GetQuestType == questType)
                {
                    quest = item;
                    return true;
                }
            }

            quest = null;
            return false;
        }
    }
}