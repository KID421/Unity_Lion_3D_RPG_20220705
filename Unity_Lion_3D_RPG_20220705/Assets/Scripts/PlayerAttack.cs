using UnityEngine;

namespace KID
{
    /// <summary>
    /// ���a�����G�z�L��J�覡��������ʵe�P�����P�w
    /// </summary>
    public class PlayerAttack : AttackSystem
    {
        private Animator ani;
        private string parAttack = "Ĳ�o����";

        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            AttackInput();
        }

        /// <summary>
        /// ������J�P�w
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
