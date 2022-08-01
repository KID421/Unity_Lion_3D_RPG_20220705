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
        #region ���
        [SerializeField, Header("�e����ܨt��")]
        private CanvasGroup groupDialogue;
        [SerializeField, Header("���ܪ̦W��")]
        private TextMeshProUGUI textName;
        [SerializeField, Header("��ܤ��e")]
        private TextMeshProUGUI textContent;
        [SerializeField, Header("�T����")]
        private GameObject goTriangle;

        private AudioSource aud;
        #endregion

        public DataNPC dataNpc;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();

            StartCoroutine(FadeIn());

            textName.text = dataNpc.nameNPC;
            textContent.text = "";
        }

        #region ��P�{�Ǳо�
        // ��P�{�ǻݭn��
        // 1. �ޥ� System.Collections
        // 2. �w�q��k �öǦ^ IEunumerator
        // 3. �Ұʨ�{ StartCoroutine
        private IEnumerator Test()
        {
            print("�Ĥ@���r");
            yield return new WaitForSeconds(2);
            print("�ĤG���r");
            yield return new WaitForSeconds(5);
            print("�ĤT���r");
        }
        #endregion

        /// <summary>
        /// �H�J�ĪG
        /// </summary>
        private IEnumerator FadeIn()
        {
            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }

            StartCoroutine(TypeEffect());
        }

        /// <summary>
        /// ���r�ĪG�B�����ܭ��ĻP��ܤT����
        /// </summary>
        private IEnumerator TypeEffect()
        {
            aud.PlayOneShot(dataNpc.dataDialogue[0].sound);

            string content = dataNpc.dataDialogue[0].content;

            for (int i = 0; i < content.Length; i++)
            {
                textContent.text += content[i];
                yield return new WaitForSeconds(0.05f);
            }

            goTriangle.SetActive(true);
        }
    }
}
