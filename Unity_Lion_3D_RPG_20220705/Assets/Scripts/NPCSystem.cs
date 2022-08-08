using UnityEngine;

namespace KID
{
    /// <summary>
    /// 偵測玩家是否進到區域內，顯示提示畫面，按鍵偵測並啟動對話系統
    /// </summary>
    public class NPCSystem : MonoBehaviour
    {
        [SerializeField, Header("NPC 對話資料")]
        private DataNPC dataNPC;

        /// <summary>
        /// 提示底圖
        /// </summary>
        private Animator aniTip;
        private string parTipFade = "觸發淡入淡出";

        private void Awake()
        {
            aniTip = GameObject.Find("提示底圖").GetComponent<Animator>();
        }

        // 碰撞事件
        // 1. 兩個物件至少其中一個有 Rigidbody
        // 2. 有勾選 Trigger 使用 OnTrigger 事件 Enter、Exit、Stay
        private void OnTriggerEnter(Collider other)
        {
            CheckPlayerAndAnimation(other.name);
        }

        private void OnTriggerExit(Collider other)
        {
            CheckPlayerAndAnimation(other.name);
        }

        /// <summary>
        /// 檢查玩家是否進入或離開並更新動畫
        /// </summary>
        /// <param name="nameHit">碰撞物件的名稱</param>
        private void CheckPlayerAndAnimation(string nameHit)
        {
            if (nameHit == "線條先生")
            {
                aniTip.SetTrigger(parTipFade);
            }
        }
    }
}

