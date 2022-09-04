﻿using UnityEngine;
using TMPro;
using System.Collections;   // 引用 系統 集合 - 資料結構與協同程序

namespace KID
{
    // 委派簽名 無傳回與無參數
    public delegate void DelegateFinishDialogue();

    /// <summary>
    /// 對話系統，淡入對話框，更新 NPC 資料名稱、內容、音效，淡出
    /// </summary>
    /// RequireComponent 要求元件，在添加腳本時觸發
    [RequireComponent(typeof(AudioSource))]
    public class DialogueSystem : MonoBehaviour
    {
        #region 封裝內容

        #region 資料
        [SerializeField, Header("畫布對話系統")]
        private CanvasGroup groupDialogue;
        [SerializeField, Header("說話者名稱")]
        private TextMeshProUGUI textName;
        [SerializeField, Header("對話內容")]
        private TextMeshProUGUI textContent;
        [SerializeField, Header("三角形")]
        private GameObject goTriangle;
        [SerializeField, Header("淡入間隔"), Range(0, 0.5f)]
        private float intervalFadeIn = 0.1f;
        [SerializeField, Header("打字間隔"), Range(0, 0.2f)]
        private float intervalType = 0.05f;

        private AudioSource aud;
        private DataNPC dataNPC;
        #endregion

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }

        #region 協同程序教學
        // 協同程序需要的
        // 1. 引用 System.Collections
        // 2. 定義方法 並傳回 IEunumerator
        // 3. 啟動協程 StartCoroutine
        private IEnumerator Test()
        {
            print("第一行文字");
            yield return new WaitForSeconds(2);
            print("第二行文字");
            yield return new WaitForSeconds(5);
            print("第三行文字");
        }
        #endregion

        /// <summary>
        /// 淡入或淡出效果
        /// </summary>
        private IEnumerator Fade(bool fadeIn = true)
        {
            // 三元運算子
            // 布林值 ? 布林值為 true : 布林值為 false
            float increase = fadeIn ? 0.1f : -0.1f;

            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(intervalFadeIn);
            }
        }

        /// <summary>
        /// 打字效果、播放對話音效與顯示三角形
        /// </summary>
        private IEnumerator TypeEffect(int indexDialogue)
        {
            textContent.text = "";
            goTriangle.SetActive(false);
            aud.PlayOneShot(dataNPC.dataDialogue[indexDialogue].sound);

            string content = dataNPC.dataDialogue[indexDialogue].content;

            for (int i = 0; i < content.Length; i++)
            {
                textContent.text += content[i];
                yield return new WaitForSeconds(intervalType);
            }

            goTriangle.SetActive(true);
        }
        #endregion

        #region 公開資料與方法
        /// <summary>
        /// 是否在對話中
        /// </summary>
        public bool isDialogue;

        /// <summary>
        /// 開始對話，協同程序
        /// </summary>
        public IEnumerator StartDialogue(DataNPC _dataNPC, DelegateFinishDialogue callback)
        {
            isDialogue = true;

            dataNPC = _dataNPC;

            textName.text = dataNPC.nameNPC;
            textContent.text = "";

            yield return StartCoroutine(Fade());

            for (int i = 0; i < dataNPC.dataDialogue.Length; i++)
            {
                yield return StartCoroutine(TypeEffect(i));

                // 如果 還沒按 指定按鍵 就持續等待
                while (!Input.GetKeyDown(KeyCode.E))
                {
                    yield return null;
                }
            }

            StartCoroutine(Fade(false));

            isDialogue = false;
            
            callback(); // 執行回呼函式
        }
        #endregion
    }
}
