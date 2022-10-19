using UnityEngine;
using System.Collections;

namespace KID
{
    /// <summary>
    /// 血量系統
    /// </summary>
    public class EnemyHealth : HealthSystem
    {
        private EnemySystem enemySystem;
        private Material matDissolve;
        private string nameDissolve = "DissolveValue";
        private float maxDissolve = 2.5f;
        private float minDissolve = -2.6f;

        private ObjectPoolRock objectPoolRock;

        public delegate void delegateDead();
        /// <summary>
        /// 死亡事件
        /// </summary>
        public delegateDead onDead;

        protected override void Awake()
        {
            base.Awake();
            enemySystem = GetComponent<EnemySystem>();

            // Renderer 為 Skinned Mesh Renderer 與 Mesh Renderer 的父類別
            // 取得 Renderer 可以適用於模型套用不同元件的狀況
            // GetComponentsInChildren 取得子物件們的原件，傳回陣列
            matDissolve = GetComponentsInChildren<Renderer>()[0].material;

            // objectPoolRock = FindObjectOfType<ObjectPoolRock>();
            objectPoolRock = GameObject.Find("物件池碎片").GetComponent<ObjectPoolRock>();
        }

        // 遊戲物件被隱藏時執行一次
        private void OnDisable()
        {
            
        }

        // 遊戲物件被顯示時執行一次
        private void OnEnable()
        {
            hp = dataHealth.hp;
            imgHealth.fillAmount = 1;
            enemySystem.enabled = true;
            matDissolve.SetFloat(nameDissolve, 2.5f);
            maxDissolve = 2.5f;
        }

        protected override void Dead()
        {
            base.Dead();
            enemySystem.enabled = false;
            DropProp();
            StartCoroutine(Dissolve());
        }

        /// <summary>
        /// 溶解效果
        /// </summary>
        private IEnumerator Dissolve()
        {
            while (maxDissolve > minDissolve)
            {
                maxDissolve -= 0.1f;
                matDissolve.SetFloat(nameDissolve, maxDissolve);
                yield return new WaitForSeconds(0.03f);
            }

            onDead();
        }

        /// <summary>
        /// 掉落道具
        /// </summary>
        private void DropProp()
        {
            float value = Random.value;

            if (value <= dataHealth.propProbability)
            {
                //Instantiate(
                //    dataHealth.goProp,
                //    transform.position + Vector3.up * 3,
                //    Quaternion.identity);

                GameObject tempObject = objectPoolRock.GetPoolObject();
                tempObject.transform.position = transform.position + Vector3.up * 3;
            }
        }
    }
}
