using UnityEngine;

namespace KID
{
    /// <summary>
    /// 血量系統
    /// </summary>
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField, Header("血量資料")]
        private DataHealth dataHealth;

        private float hp;
        private Animator ani;
        private string parHurt = "觸發受傷";
        private string parDead = "開關死亡";

        private void Awake()
        {
            ani = GetComponent<Animator>();
            hp = dataHealth.hp;
        }

        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">收到的傷害值</param>
        public void Hurt(float damage)
        {
            hp -= damage;
            ani.SetTrigger(parHurt);

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// 死亡
        /// </summary>
        private void Dead()
        {
            hp = 0;
            ani.SetBool(parDead, true);
        }
    }
}
