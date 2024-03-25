using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace TestProject
{
    public class FindWordDisplay : MonoBehaviour
    {

        [SerializeField] private QuizController _quizController;
        [SerializeField] private TMP_Text _findWordDisplay;

        private void Start()
        {
            Initialization();
            FadeDisplay();
        }

        private void FadeDisplay()
        {
            _findWordDisplay.color = new Color(1, 1, 1, 0);
            _findWordDisplay.DOColor(Color.white, 3f);
        }

        private void Initialization()
        {
            _quizController.OnQuizChanged.AddListener(RefreshDisplay);
        }

        private void RefreshDisplay()
        {
            _findWordDisplay.text = "Find: " + _quizController.FindQuiz.QuizID;
        }
    }
}
