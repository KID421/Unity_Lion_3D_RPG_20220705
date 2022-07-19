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
        private Vector3 direction;
        private Transform traCamera;
        #endregion

        #region �ƥ�
        private void Awake()
        {
            ani = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();

            // �z�L�W�ٷj�M����A��ĳ��b Awake�BStart �Ϊ̰���@�����[�c��
            // traCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
            traCamera = GameObject.Find("Main Camera").transform;
        }

        private void Update()
        {
            Move();
        }
        #endregion

        #region ��k
        /// <summary>
        /// ����
        /// </summary>
        private void Move()
        {
            float v = Input.GetAxisRaw("Vertical");     // ���o�e�����ȡGWS�B����
            float h = Input.GetAxisRaw("Horizontal");   // ���o���k����ȡGAD�B����

            // print("<color=yellow>�����b�V�G" + v + "</color>");

            #region ����
            // transform.rotation = traCamera.rotation; // �S���L��

            // ���a���� = �|����.����(���a���סA��v�����סA�t�� * �C�V�ɶ�)
            transform.rotation = Quaternion.Lerp(transform.rotation, traCamera.rotation, turn * Time.deltaTime);
            #endregion

            direction.z = v;                            // ����e��b�� Z �b�G���w�� v �e�����
            direction.x = h;                            // ���󥪥k�b�� X �b�G���w�� h ���k����

            // ���ⱱ�.����(��V * �t��)
            // Time.deltaTime �C�V���ɶ�
            controller.Move(direction * speed * Time.deltaTime);
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

