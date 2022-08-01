using UnityEngine;
using TMPro;
using System.Collections;   // �ޥ� �t�� ���X - ��Ƶ��c�P��P�{��

namespace KID
{
    /// <summary>
    /// ��ܨt�ΡA�H�J��ܮءA��s NPC ��ƦW�١B���e�B���ġA�H�X
    /// </summary>
    /// RequireComponent �n�D����A�b�K�[�}����Ĳ�o
    [RequireComponent(typeof(AudioSource))]
    public class DialogueSystem : MonoBehaviour
    {
        [SerializeField, Header("�e����ܨt��")]
        private CanvasGroup groupDialogue;
        [SerializeField, Header("���ܪ̦W��")]
        private TextMeshProUGUI textName;
        [SerializeField, Header("��ܤ��e")]
        private TextMeshProUGUI textContent;

        private AudioSource aud;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();

            StartCoroutine(Test());
        }

        // ��P�{�ǻݭn��
        // 1. �ޥ� System.Collections
        // 2. �w�q��k �öǦ^ IEunumerator
        // 3. �Ұʨ�{ StartCoroutine
        private IEnumerator Test()
        {
            print("�Ĥ@���r");
            yield return new WaitForSeconds(2);
            print("�ĤG���r");
        }
    }
}
