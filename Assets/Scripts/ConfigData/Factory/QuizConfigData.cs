using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bado_City
{/// <summary>
/// Classe per creare domande a risposta multipla
/// </summary>
    [CreateAssetMenu(fileName = "NewQuizConfigData", menuName = "Factory/NewQuiz", order = 1)]
    public class QuizConfigData : ScriptableObject
    {
        public string Question;
        public List<string> Answers = new List<string>();
        public List<int> CorrectAnswerListIndex = new List<int>(); // Prima avevo messo solo int, alla fine ho optato per una lista nel caso si volessero formulare domande con più risposte corrette
    }
}
