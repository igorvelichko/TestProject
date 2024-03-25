using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    [CreateAssetMenu(fileName = "QuizTypePreset", menuName = "TestProject/Quiz Type Preset")]
    public class QuizTypePreset : ScriptableObject
    {
        [SerializeField] private Quiz[] QuizTypeArray;

        public Quiz[] GetQuizTypeArray()
        {
            return QuizTypeArray;
        }
    }

    [System.Serializable]
    public class Quiz
    {
        public string QuizID = "";
        public Sprite QuizIcon;
    }
}
