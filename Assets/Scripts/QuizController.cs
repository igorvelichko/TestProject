using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace TestProject
{
    public class QuizController : MonoBehaviour
    {

        public Quiz FindQuiz { get; private set; }

        [SerializeField] private FieldBoundPreset[] quizLevelList;
        [SerializeField] private QuizTypePreset[] quizRandomTypes;

        [SerializeField] private RestartWindow _restartWindow;

        [SerializeField] private FieldSpawner _fieldSpawner;

 
        [HideInInspector] public UnityEvent OnQuizChanged;

        private List<string> _usedQuizID = new List<string>();

        private int _currentQuiz = 0;

        private void Start()
        {
            SetQuiz(0);
        }

        public void NextQuiz()
        {
            _currentQuiz++;

            if (_currentQuiz >= quizLevelList.Length)
            {
                _restartWindow.ActiveRestartWindow(true);
            }
            else
            {
                SetQuiz(_currentQuiz);
            }
        }

        public void SetQuiz(int quizIndex)
        {
            _currentQuiz = quizIndex;
            CreateQuiz(quizLevelList[quizIndex], quizRandomTypes[Random.Range(0, quizRandomTypes.Length)]);
        }

        public void CreateQuiz(FieldBoundPreset fieldBound, QuizTypePreset quizType)
        {
            List<Quiz> quizAviable = quizType.GetQuizTypeArray().Where(v => !_usedQuizID.Contains(v.QuizID)).ToList();

            if (quizAviable.Count > 0)
            {
                int quizSlotsCount = fieldBound.Height * fieldBound.Width;
                Quiz findQuiz = quizAviable[Random.Range(0, quizAviable.Count)];

                FindQuiz = findQuiz;

                _usedQuizID.Add(findQuiz.QuizID);

                List<Quiz> spawnQuiz = quizType.GetQuizTypeArray().Where(v => v != findQuiz).ToList();
                spawnQuiz = spawnQuiz.Take<Quiz>(quizSlotsCount - 1).ToList();
                spawnQuiz.Add(findQuiz);

                Utility.Shuffle<Quiz>(spawnQuiz);

                List<FieldSlot> spawnSlots = _fieldSpawner.SpawnQuizField(fieldBound, spawnQuiz.ToArray());

                foreach (FieldSlot slot in spawnSlots)
                {
                    slot.Initialization(this);
                }

                OnQuizChanged?.Invoke();
            }
            else
            {
                //если у нас больше нет правильных ответов, которые не повторялись в рамках сессии для данного пресета

                Debug.LogError("Доступные в этой сессии уникальные id для " + quizType.ToString() + " закончились, нужно перезапустить сессию");
            }
        }
    }
}