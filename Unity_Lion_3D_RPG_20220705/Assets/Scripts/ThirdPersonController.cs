using UnityEngine;

namespace KID
{
    /// <summary>
    /// �ĤT�H�ٱ��
    /// ���ʻP���D�򥻱���B�ʵe��s
    /// </summary>
    public class ThirdPersonController : MonoBehaviour
    {
        #region ���
        [SerializeField, Header("���ʳt��"), Range(0, 50)]
        private float speed = 3.5f;
        [SerializeField, Header("����t��"), Range(0, 50)]
        private float turn = 5f;
        [SerializeField, Header("���D�t��"), Range(0, 50)]
        private float jump = 7f;

        private Animator ani;
        private CharacterController controller;
        #endregion

        #region �ƥ�
        private void Awake()
        {
            ani = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();
        }
        #endregion

        #region ��k
        /// <summary>
        /// ����
        /// </summary>
        private void Move()
        {

        }

        /// <summary>
        /// ���D
        /// </summary>
        private void Jump()
        {

        }
        #endregion
    }
}

