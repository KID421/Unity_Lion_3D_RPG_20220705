using UnityEngine;

namespace KID
{
    /// <summary>
    /// �������a�O�_�i��ϰ줺�A��ܴ��ܵe���A���䰻���ñҰʹ�ܨt��
    /// </summary>
    public class NPCSystem : MonoBehaviour
    {
        [SerializeField, Header("NPC ��ܸ��")]
        private DataNPC dataNPC;

        /// <summary>
        /// ���ܩ���
        /// </summary>
        private Animator aniTip;
        private string parTipFade = "Ĳ�o�H�J�H�X";

        private void Awake()
        {
            aniTip = GameObject.Find("���ܩ���").GetComponent<Animator>();
        }

        // �I���ƥ�
        // 1. ��Ӫ���ܤ֨䤤�@�Ӧ� Rigidbody
        // 2. ���Ŀ� Trigger �ϥ� OnTrigger �ƥ� Enter�BExit�BStay
        private void OnTriggerEnter(Collider other)
        {
            CheckPlayerAndAnimation(other.name);
        }

        private void OnTriggerExit(Collider other)
        {
            CheckPlayerAndAnimation(other.name);
        }

        /// <summary>
        /// �ˬd���a�O�_�i�J�����}�ç�s�ʵe
        /// </summary>
        /// <param name="nameHit">�I�����󪺦W��</param>
        private void CheckPlayerAndAnimation(string nameHit)
        {
            if (nameHit == "�u������")
            {
                aniTip.SetTrigger(parTipFade);
            }
        }
    }
}

