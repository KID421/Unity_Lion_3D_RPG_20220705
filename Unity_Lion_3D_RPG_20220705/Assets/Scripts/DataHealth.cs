using UnityEditor;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// ��q���
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Health", fileName = "Data Health")]
    public class DataHealth : ScriptableObject
    {
        [Header("��q"), Range(0, 10000)]
        public float hp;
        [HideInInspector]
        public float hpMax => hp;
        [Header("�O�_�����_��")]
        public bool isDropProp;
        [HideInInspector]
        [Header("�_���w�s��")]
        public GameObject goProp;
        [HideInInspector]
        [Header("�_���������v"), Range(0f, 1f)]
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
