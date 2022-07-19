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
        private Vector3 direction;
        private Transform traCamera;
        #endregion

        #region 事件
        private void Awake()
        {
            ani = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();

            // 透過名稱搜尋物件，建議放在 Awake、Start 或者執行一次的架構內
            // traCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
            traCamera = GameObject.Find("Main Camera").transform;
        }

        private void Update()
        {
            Move();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            float v = Input.GetAxisRaw("Vertical");     // 取得前後按鍵值：WS、↑↓
            float h = Input.GetAxisRaw("Horizontal");   // 取得左右按鍵值：AD、←→

            // print("<color=yellow>垂直軸向：" + v + "</color>");

            #region 旋轉
            // transform.rotation = traCamera.rotation; // 沒有過渡

            // 玩家角度 = 四元數.插值(玩家角度，攝影機角度，速度 * 每幀時間)
            transform.rotation = Quaternion.Lerp(transform.rotation, traCamera.rotation, turn * Time.deltaTime);
            #endregion

            direction.z = v;                            // 物件前後軸為 Z 軸：指定為 v 前後按鍵
            direction.x = h;                            // 物件左右軸為 X 軸：指定為 h 左右按鍵

            // 角色控制器.移動(方向 * 速度)
            // Time.deltaTime 每幀的時間
            controller.Move(direction * speed * Time.deltaTime);
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

