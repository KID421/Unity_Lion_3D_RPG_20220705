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
        [Header("�_���w�s��")]
        public GameObject goProp;
        [Header("�_���������v"), Range(0f, 1f)]
        public float propProbability;
    }
}
