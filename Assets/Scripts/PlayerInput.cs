using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class PlayerInput : MonoBehaviour
    {

        public bool DetectInput { get; set; }

        private Camera _camera;

        private void Start()
        {
            Initialization();
        }

        private void Initialization()
        {
            _camera = Camera.main;
            DetectInput = true;
        }

        public void Update()
        {
            if (!DetectInput)
                return;

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction);

            if (Input.GetMouseButtonDown(0))
            {
                if (raycastHit2D.collider != null)
                {
                    if (raycastHit2D.transform.GetComponent<FieldSlot>())
                    {
                        FieldSlot fieldSlot = raycastHit2D.transform.GetComponent<FieldSlot>();
                        fieldSlot.OnClickSlot();
                    }
                }
            }
        }
    }
}
