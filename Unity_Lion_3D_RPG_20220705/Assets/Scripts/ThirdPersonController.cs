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
        private string parRun = "�B�I�ƶ]�B";
        private string parJump = "Ĳ�o���D";
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
            Jump();
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

            // �کԨ� euler Angles 0 - 45 - 90 - 180 - 360
            // �T�w X �P Z ���� ���s
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            #endregion

            direction.z = v;                            // ����e��b�� Z �b�G���w�� v �e�����
            direction.x = h;                            // ���󥪥k�b�� X �b�G���w�� h ���k����

            direction = transform.TransformDirection(direction);    // �N���⪺�ϰ�y���ର�@�ɮy��

            // ���ⱱ�.����(��V * �t��)
            // Time.deltaTime �C�V���ɶ�
            controller.Move(direction * speed * Time.deltaTime);

            // �ʵe��s
            float vAxis = Input.GetAxis("Vertical");
            float hAxis = Input.GetAxis("Horizontal");

            if (Mathf.Abs(vAxis) > 0.1f)
            {
                ani.SetFloat(parRun, Mathf.Abs(vAxis));
            }
            else if (Mathf.Abs(hAxis) > 0.1f)
            {
                ani.SetFloat(parRun, Mathf.Abs(hAxis));
            }
            else
            {
                ani.SetFloat(parRun, 0);
            }

            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        }

        /// <summary>
        /// ���D
        /// </summary>
        private void Jump()
        {
            // �p�G �b�a���W �åB ���U�ť��� �N���D
            if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jump;
                ani.SetTrigger(parJump);
            }

            // �a�ߤޤO -9.81
            direction.y += Physics.gravity.y * 0.8f * Time.deltaTime;
        }
        #endregion
    }
}
