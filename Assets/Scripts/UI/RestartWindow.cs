using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace TestProject
{
    public class RestartWindow : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private PlayerInput _playerInput;


        public void ActiveRestartWindow(bool value)
        {
            gameObject.SetActive(value);

            if (value)
            {
                FadeBackground();
                _playerInput.DetectInput = false;
            }
        }
 
        private void FadeBackground()
        {
            _background.color = new Color(0, 0, 0, 0);
            _background.DOColor(new Color(0, 0, 0, 0.6f), 2f);
        }
    }
}
