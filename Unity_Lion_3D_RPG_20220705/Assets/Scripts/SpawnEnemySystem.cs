using UnityEngine;

namespace KID
{
    /// <summary>
    /// �ͦ��ĤH�t��
    /// </summary>
    [DefaultExecutionOrder(200)]
    public class SpawnEnemySystem : MonoBehaviour
    {
        [SerializeField, Header("���s�ͦ��ɶ��d��")]
        private Vector2 rangeRespawn = new Vector2(2, 5);

        private ObjectPoolGolem objectPoolGolem;
        private GameObject enemyObject;

        private void Awake()
        {
            objectPoolGolem = GameObject.Find("��������[").GetComponent<ObjectPoolGolem>();

            Spawn();
        }

        /// <summary>
        /// �ͦ�
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
