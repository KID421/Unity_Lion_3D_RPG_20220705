using UnityEngine;

namespace KID
{
    /// <summary>
    /// �ͦ��y��G���ϥΪ����
    /// </summary>
    public class SpawnBall : MonoBehaviour
    {
        [SerializeField, Header("�y��")]
        private GameObject prefabBall;

        private void Awake()
        {
            InvokeRepeating("Spawn", 0, 0.1f);
        }

        private int count;

        /// <summary>
        /// �ͦ��y��
        /// </summary>
        private void Spawn()
        {
            Vector3 pos;
            pos.x = Random.Range(-15f, 15f);
            pos.y = Random.Range(5f, 7f);
            pos.z = Random.Range(-15f, 15f);
            count++;
            Instantiate(prefabBall, pos, Quaternion.identity).name = prefabBall.name + count;
        }
    }
}
