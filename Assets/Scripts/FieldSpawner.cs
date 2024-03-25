using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class FieldSpawner : MonoBehaviour
    {
        [SerializeField] private FieldSlot _fieldSlotPrefab;
        [SerializeField] private Transform _quizParent;
        [SerializeField] private Vector2   _fieldSpace;

        public List<FieldSlot> SpawnQuizField(FieldBoundPreset fieldBound, Quiz [] quiz)
        {
            ClearQuizField();

            int index = 0;

            List<FieldSlot> quizzeSlots = new List<FieldSlot>();

            for (int a = 0; a < fieldBound.Height; a++)
            {
                for (int i = 0; i < fieldBound.Width; i++)
                {
                    FieldSlot fieldSlot = Instantiate(_fieldSlotPrefab);
                    fieldSlot.transform.SetParent(_quizParent);
                    fieldSlot.transform.localPosition = new Vector3(_fieldSpace.x * i, _fieldSpace.y * a);
                    fieldSlot.SetQuiz(quiz[index]);

                    quizzeSlots.Add(fieldSlot);

                    index++;
                }
            }

     
            return quizzeSlots;
        }

        private void ClearQuizField()
        {
            foreach(Transform transform in _quizParent)
            {
                Destroy(transform.gameObject);
            }
        }
    }
}
