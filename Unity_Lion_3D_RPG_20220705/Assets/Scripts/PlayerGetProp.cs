using TMPro;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// ���a���o�D��
    /// </summary>
    public class PlayerGetProp : MonoBehaviour
    {
        private ObjectPoolRock objectPoolRock;
        private string propRock = "���Y�H��";
        private int countRock = 0;
        private int countRockMax = 50;
        private TextMeshProUGUI textCount;

        private NPCSystem npcSystem;
        
        [SerializeField, Header("�������Ȫ����")]
        private DataNPC dataNPC;

        private void Awake()
        {
            // objectPoolRock = FindObjectOfType<ObjectPoolRock>();
            objectPoolRock = GameObject.Find("������H��").GetComponent<ObjectPoolRock>();

            textCount = GameObject.Find("�H���ƶq����").GetComponent<TextMeshProUGUI>();
            npcSystem = GameObject.Find("NPC �p��").GetComponent<NPCSystem>();
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.name.Contains(propRock))
            {
                objectPoolRock.ReleasePoolObject(hit.gameObject);
                UpdateUI();
            }
        }

        /// <summary>
        /// ��s����
        /// </summary>
        private void UpdateUI()
        {
            textCount.text = "�H�� " + (++countRock) + " / " + countRockMax;

            if (countRock >= countRockMax) npcSystem.dataNPC = dataNPC;
        }
    }
}
