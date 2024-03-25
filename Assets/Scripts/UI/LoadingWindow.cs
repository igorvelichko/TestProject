using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace TestProject
{
    public class LoadingWindow : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private QuizController _quizController;
        [SerializeField] private PlayerInput _playerInput;

        public void LoadAnimation()
        {
            _background.color = new Color(0, 0, 0, 0);

            _background.DOColor(Color.black, 1f).OnComplete(delegate 
            {
                _quizController.SetQuiz(0);
                _background.DOColor(new Color(0, 0, 0, 0), 1f);
                _playerInput.DetectInput = true;
            });
        }
    }
}
