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

        protected override void Awake()
        {
            base.Awake();
            enemySystem = GetComponent<EnemySystem>();

            // Renderer 為 Skinned Mesh Renderer 與 Mesh Renderer 的父類別
            // 取得 Renderer 可以適用於模型套用不同元件的狀況
            // GetComponentsInChildren 取得子物件們的原件，傳回陣列
            matDissolve = GetComponentsInChildren<Renderer>()[0].material;

            objectPoolRock = FindObjectOfType<ObjectPoolRock>();
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
