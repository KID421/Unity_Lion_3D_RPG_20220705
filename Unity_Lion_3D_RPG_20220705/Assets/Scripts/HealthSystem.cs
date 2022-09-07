using UnityEngine;

namespace KID
{
    /// <summary>
    /// ��q�t��
    /// </summary>
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField, Header("��q���")]
        private DataHealth dataHealth;

        private float hp;
        private Animator ani;
        private string parHurt = "Ĳ�o����";
        private string parDead = "�}�����`";

        private void Awake()
        {
            ani = GetComponent<Animator>();
            hp = dataHealth.hp;
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="damage">���쪺�ˮ`��</param>
        public void Hurt(float damage)
        {
            hp -= damage;
            ani.SetTrigger(parHurt);

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// ���`
        /// </summary>
        private void Dead()
        {
            hp = 0;
            ani.SetBool(parDead, true);
        }
    }
}
