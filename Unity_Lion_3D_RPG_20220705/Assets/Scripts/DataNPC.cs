using UnityEngine;

namespace KID
{
    /// <summary>
    /// NPC 資料：名稱、對話內容與音效
    /// ScriptableObject 腳本化物件
    /// 將程式內容儲存為物件放在 Project 內
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data NPC", fileName = "Data NPC")]
    public class DataNPC : ScriptableObject
    {
        [Header("NPC 名稱")]
        public string nameNPC;
        // NonReorderable 解決陣列在屬性面板上顯示錯誤問題
        [Header("所有對話"), NonReorderable]
        public DataDialogue[] dataDialogue;
    }

    // 類別序列化
    [System.Serializable]
    public class DataDialogue
    {
        [Header("對話內容")]
        public string content;
        [Header("對話音效")]
        public AudioClip sound;
    }
}

