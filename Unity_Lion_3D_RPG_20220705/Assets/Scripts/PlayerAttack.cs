using UnityEngine;

namespace KID
{
    /// <summary>
    /// 玩家攻擊：透過輸入方式控制攻擊動畫與攻擊判定
    /// </summary>
    public class PlayerAttack : AttackSystem
    {
        private Animator ani;
        private string parAttack = "觸發攻擊";

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            AttackInput();
        }

        /// <summary>
        /// 攻擊輸入判定
        /// </summary>
        private void AttackInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ani.SetTrigger(parAttack);
                StartAttack();
            }
        }
    }
}
