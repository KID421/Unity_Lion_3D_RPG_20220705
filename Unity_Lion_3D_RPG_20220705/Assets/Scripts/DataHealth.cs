using UnityEditor;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// 血量資料
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Health", fileName = "Data Health")]
    public class DataHealth : ScriptableObject
    {
        [Header("血量"), Range(0, 10000)]
        public float hp;
        [HideInInspector]
        public float hpMax => hp;
        [Header("是否掉落寶物")]
        public bool isDropProp;
        [HideInInspector]
        [Header("寶物預製物")]
        public GameObject goProp;
        [HideInInspector]
        [Header("寶物掉落機率"), Range(0f, 1f)]
        public float propProbability;
    }

    [CustomEditor(typeof (DataHealth))]
    public class EditorMain : Editor
    {
        SerializedProperty isDropProp;
        SerializedProperty goProp;
        SerializedProperty propProbability;

        private void OnEnable()
        {
            isDropProp = serializedObject.FindProperty(nameof(DataHealth.isDropProp));
            goProp = serializedObject.FindProperty(nameof(DataHealth.goProp));
            propProbability = serializedObject.FindProperty(nameof(DataHealth.propProbability));
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            serializedObject.Update();

            if (isDropProp.boolValue)
            {
                EditorGUILayout.PropertyField(goProp);
                EditorGUILayout.PropertyField(propProbability);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
