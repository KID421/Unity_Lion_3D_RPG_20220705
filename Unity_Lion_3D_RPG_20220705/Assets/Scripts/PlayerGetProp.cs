using TMPro;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// 玩家取得道具
    /// </summary>
    public class PlayerGetProp : MonoBehaviour
    {
        private ObjectPoolRock objectPoolRock;
        private string propRock = "石頭碎片";
        private int countRock = 0;
        private int countRockMax = 50;
        private TextMeshProUGUI textCount;

        private NPCSystem npcSystem;
        
        [SerializeField, Header("完成任務的對話")]
        private DataNPC dataNPC;

        private void Awake()
        {
            // objectPoolRock = FindObjectOfType<ObjectPoolRock>();
            objectPoolRock = GameObject.Find("物件池碎片").GetComponent<ObjectPoolRock>();

            textCount = GameObject.Find("碎片數量介面").GetComponent<TextMeshProUGUI>();
            npcSystem = GameObject.Find("NPC 小美").GetComponent<NPCSystem>();
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
        /// 更新介面
        /// </summary>
        private void UpdateUI()
        {
            textCount.text = "碎片 " + (++countRock) + " / " + countRockMax;

            if (countRock >= countRockMax) npcSystem.dataNPC = dataNPC;
        }
    }
}
