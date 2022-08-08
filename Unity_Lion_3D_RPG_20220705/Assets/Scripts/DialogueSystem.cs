using UnityEngine;
using TMPro;
using System.Collections;   // �ޥ� �t�� ���X - ��Ƶ��c�P��P�{��

namespace KID
{
    // �e��ñ�W �L�Ǧ^�P�L�Ѽ�
    public delegate void DelegateFinishDialogue();

    /// <summary>
    /// ��ܨt�ΡA�H�J��ܮءA��s NPC ��ƦW�١B���e�B���ġA�H�X
    /// </summary>
    /// RequireComponent �n�D����A�b�K�[�}����Ĳ�o
    [RequireComponent(typeof(AudioSource))]
    public class DialogueSystem : MonoBehaviour
    {
        #region �ʸˤ��e

        #region ���
        [SerializeField, Header("�e����ܨt��")]
        private CanvasGroup groupDialogue;
        [SerializeField, Header("���ܪ̦W��")]
        private TextMeshProUGUI textName;
        [SerializeField, Header("��ܤ��e")]
        private TextMeshProUGUI textContent;
        [SerializeField, Header("�T����")]
        private GameObject goTriangle;
        [SerializeField, Header("�H�J���j"), Range(0, 0.5f)]
        private float intervalFadeIn = 0.1f;
        [SerializeField, Header("���r���j"), Range(0, 0.2f)]
        private float intervalType = 0.05f;

        private AudioSource aud;
        private DataNPC dataNPC;
        #endregion

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
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
        /// �H�J�βH�X�ĪG
        /// </summary>
        private IEnumerator Fade(bool fadeIn = true)
        {
            // �T���B��l
            // ���L�� ? ���L�Ȭ� true : ���L�Ȭ� false
            float increase = fadeIn ? 0.1f : -0.1f;

            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(intervalFadeIn);
            }
        }

        /// <summary>
        /// ���r�ĪG�B�����ܭ��ĻP��ܤT����
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

        #region ���}��ƻP��k
        /// <summary>
        /// �O�_�b��ܤ�
        /// </summary>
        public bool isDialogue;

        /// <summary>
        /// �}�l��ܡA��P�{��
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

                // �p�G �٨S�� ���w���� �N���򵥫�
                while (!Input.GetKeyDown(KeyCode.E))
                {
                    yield return null;
                }
            }

            StartCoroutine(Fade(false));

            isDialogue = false;
            
            callback(); // ����^�I�禡
        }
        #endregion
    }
}
