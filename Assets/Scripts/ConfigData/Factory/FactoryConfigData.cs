using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bado_City
{
    /// <summary>
    /// Classe per creare accoglienti posti di lavoro
    /// </summary>
    [CreateAssetMenu(fileName = "NewFactoryConfigData", menuName = "Factory/NewFactory", order = 0)]
    public class FactoryConfigData : ScriptableObject
    {
        public List<QuizConfigData> PossibQuestions = new List<QuizConfigData>();
        public int MaxQuestions;
        [HideInInspector]
        public List<QuizConfigData> CurrentQuiz = new List<QuizConfigData>();
        public FactoryInfo info;
        [System.Serializable]
        public struct FactoryInfo
        {
            public string Name; //Nome della fabbrica           
            public List<string> Descriptions; // Lista nel caso si volesse dividere la descrizione in più parti
            public Sprite IconSprite; // Immagine della fabbrica
        }
    }
}
