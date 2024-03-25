using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{

    [CreateAssetMenu(fileName = "FieldBoundPreset", menuName = "TestProject/Field Bound")]
    public class FieldBoundPreset : ScriptableObject
    {
        [Range(1, 12)] public int Width = 2;
        [Range(1, 12)] public int Height = 2;
    }
}
