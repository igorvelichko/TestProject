using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TestProject
{
    public class FieldSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _slotIconRenderer;
        [SerializeField] private ParticleSystem _starParticle;

        private Quiz _currentQuiz;
        private QuizController _quizController;

        private bool _playFindAnimation = false;

        public void Initialization(QuizController controller)
        {
            _quizController = controller;
        }

        public void SetQuiz(Quiz quiz)
        {
            _currentQuiz = quiz;
            _slotIconRenderer.sprite = quiz.QuizIcon;
        }

        public void OnClickSlot()
        {
            Debug.Log("Click slot");

            if (_currentQuiz.QuizID == _quizController.FindQuiz.QuizID)
            {
                FindQuiz();
            }
            else
            {
                DenyQuiz();
            }
        }

        private void FindQuiz()
        {
            if (_playFindAnimation)
                return;

            _playFindAnimation = true;

            _starParticle.Play();

            _slotIconRenderer.transform.DOKill();
            _slotIconRenderer.transform.localScale = Vector3.one;
           _slotIconRenderer.transform.DOPunchScale(new Vector3(1.05f, 1.05f), 1, 1).OnComplete(delegate { _quizController.NextQuiz(); }); ;
        }

        private void DenyQuiz()
        {
            _slotIconRenderer.transform.DOKill();
            _slotIconRenderer.transform.localPosition = Vector3.zero;
            _slotIconRenderer.transform.DOShakePosition(0.5f, 0.2f);
        }
    }
}
