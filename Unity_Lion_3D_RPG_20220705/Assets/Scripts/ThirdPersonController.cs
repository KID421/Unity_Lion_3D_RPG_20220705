using UnityEngine;

namespace KID
{
    /// <summary>
    /// 第三人稱控制器
    /// 移動與跳躍基本控制、動畫更新
    /// </summary>
    public class ThirdPersonController : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("移動速度"), Range(0, 50)]
        private float speed = 3.5f;
        [SerializeField, Header("旋轉速度"), Range(0, 50)]
        private float turn = 5f;
        [SerializeField, Header("跳躍速度"), Range(0, 50)]
        private float jump = 7f;

        private Animator ani;
        private CharacterController controller;
        #endregion

        #region 事件
        private void Awake()
        {
            ani = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {

        }

        /// <summary>
        /// 跳躍
        /// </summary>
        private void Jump()
        {

        }
        #endregion
    }
}

