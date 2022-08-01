using UnityEngine;

namespace KID
{
    /// <summary>
    /// NPC ��ơG�W�١B��ܤ��e�P����
    /// ScriptableObject �}���ƪ���
    /// �N�{�����e�x�s�������b Project ��
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data NPC", fileName = "Data NPC")]
    public class DataNPC : ScriptableObject
    {
        [Header("NPC �W��")]
        public string nameNPC;
        // NonReorderable �ѨM�}�C�b�ݩʭ��O�W��ܿ��~���D
        [Header("�Ҧ����"), NonReorderable]
        public DataDialogue[] dataDialogue;
    }

    // ���O�ǦC��
    [System.Serializable]
    public class DataDialogue
    {
        [Header("��ܤ��e")]
        public string content;
        [Header("��ܭ���")]
        public AudioClip sound;
    }
}

