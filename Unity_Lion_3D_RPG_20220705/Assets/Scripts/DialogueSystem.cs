using UnityEngine;
using TMPro;
using System.Collections;   // 引用 系統 集合 - 資料結構與協同程序

namespace KID
{
    /// <summary>
    /// 對話系統，淡入對話框，更新 NPC 資料名稱、內容、音效，淡出
    /// </summary>
    /// RequireComponent 要求元件，在添加腳本時觸發
    [RequireComponent(typeof(AudioSource))]
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField, Header("畫布對話系統")]
        private CanvasGroup groupDialogue;
        [SerializeField, Header("說話者名稱")]
        private TextMeshProUGUI textName;
        [SerializeField, Header("對話內容")]
        private TextMeshProUGUI textContent;

        private AudioSource aud;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();

            StartCoroutine(Test());
        }

        // 協同程序需要的
        // 1. 引用 System.Collections
        // 2. 定義方法 並傳回 IEunumerator
        // 3. 啟動協程 StartCoroutine
        private IEnumerator Test()
        {
            print("第一行文字");
            yield return new WaitForSeconds(2);
            print("第二行文字");
        }
    }
}
