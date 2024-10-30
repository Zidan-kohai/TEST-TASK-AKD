using Feature.Quest;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrustructure.Service.Factory
{
    public interface IFactory
    {
        public List<QuestConfig> GetQuestConfigs();
    }

    public class Factory : IFactory
    {
        private const string PathToQuest = "Quest";
        public List<QuestConfig> GetQuestConfigs() =>
            Resources.LoadAll<QuestConfig>("Quest").ToList();
    }
}
