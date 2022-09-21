using UnityEngine;
using UnityEngine.Pool;

namespace KID
{
    /// <summary>
    /// ������G�H��
    /// </summary>
    public class ObjectPoolRock : MonoBehaviour
    {
        [SerializeField, Header("�H��")]
        private GameObject prefabRock;
        [SerializeField, Header("�H���̤j�ƶq"), Range(1, 1000)]
        private int countMaxRock = 30;

        /// <summary>
        /// �H�������
        /// </summary>
        private ObjectPool<GameObject> poolRock;

        private int count;

        private void Awake()
        {
            poolRock = new ObjectPool<GameObject>(
                CreatePool, GetRock, ReleaseRock, DestroyRock, false, countMaxRock);
        }

        /// <summary>
        /// �إߪ������@���B�z
        /// </summary>
        private GameObject CreatePool()
        {
            count++;
            GameObject temp = Instantiate(prefabRock);
            temp.name = prefabRock.name + " " + count;
            return temp;
        }

        /// <summary>
        /// ���o���������ɳB�z���欰
        /// </summary>
        private void GetRock(GameObject rock)
        {
            rock.SetActive(true);
        }

        /// <summary>
        /// �N�����ٵ�������ɳB�z���欰
        /// </summary>
        /// <param name="rock"></param>
        private void ReleaseRock(GameObject rock)
        {
            rock.SetActive(false);
        }

        /// <summary>
        /// �ƶq�W�X������e�q��@���B�z
        /// </summary>
        /// <param name="rock"></param>
        private void DestroyRock(GameObject rock)
        {
            Destroy(rock);
        }

        /// <summary>
        /// ���o�������������
        /// </summary>
        public GameObject GetPoolObject()
        {
            return poolRock.Get();
        }

        /// <summary>
        /// �N�����٨쪫�����
        /// </summary>
        /// <param name="rock"></param>
        public void ReleasePoolObject(GameObject rock)
        {
            poolRock.Release(rock);
        }
    }
}
