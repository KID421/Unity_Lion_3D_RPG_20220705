using UnityEngine;

namespace KID
{
    /// <summary>
    /// 生成敵人系統
    /// </summary>
    [DefaultExecutionOrder(200)]
    public class SpawnEnemySystem : MonoBehaviour
    {
        [SerializeField, Header("重新生成時間範圍")]
        private Vector2 rangeRespawn = new Vector2(2, 5);

        private ObjectPoolGolem objectPoolGolem;
        private GameObject enemyObject;

        private void Awake()
        {
            objectPoolGolem = GameObject.Find("物件池高崙").GetComponent<ObjectPoolGolem>();

            Spawn();
        }

        /// <summary>
        /// 生成
        /// </summary>
        private void Spawn()
        {
            enemyObject = objectPoolGolem.GetPoolObject();
            enemyObject.transform.position = transform.position;

            enemyObject.GetComponent<EnemyHealth>().onDead = EnemyDead;
        }

        private void EnemyDead()
        {
            objectPoolGolem.ReleasePoolObject(enemyObject);

            float randomTime = Random.Range(rangeRespawn.x, rangeRespawn.y);
            Invoke("Spawn", randomTime);
        }
    }
}
