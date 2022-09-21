using UnityEngine;
using UnityEngine.Pool;

namespace KID
{
    /// <summary>
    /// 物件池：碎片
    /// </summary>
    public class ObjectPoolRock : MonoBehaviour
    {
        [SerializeField, Header("碎片")]
        private GameObject prefabRock;
        [SerializeField, Header("碎片最大數量"), Range(1, 1000)]
        private int countMaxRock = 30;

        /// <summary>
        /// 碎片物件池
        /// </summary>
        private ObjectPool<GameObject> poolRock;

        private int count;

        private void Awake()
        {
            poolRock = new ObjectPool<GameObject>(
                CreatePool, GetRock, ReleaseRock, DestroyRock, false, countMaxRock);
        }

        /// <summary>
        /// 建立物件池實作的處理
        /// </summary>
        private GameObject CreatePool()
        {
            count++;
            GameObject temp = Instantiate(prefabRock);
            temp.name = prefabRock.name + " " + count;
            return temp;
        }

        /// <summary>
        /// 取得物件池物件時處理的行為
        /// </summary>
        private void GetRock(GameObject rock)
        {
            rock.SetActive(true);
        }

        /// <summary>
        /// 將物件還給物件池時處理的行為
        /// </summary>
        /// <param name="rock"></param>
        private void ReleaseRock(GameObject rock)
        {
            rock.SetActive(false);
        }

        /// <summary>
        /// 數量超出物件池容量實作的處理
        /// </summary>
        /// <param name="rock"></param>
        private void DestroyRock(GameObject rock)
        {
            Destroy(rock);
        }

        /// <summary>
        /// 取得物件池內的物件
        /// </summary>
        public GameObject GetPoolObject()
        {
            return poolRock.Get();
        }

        /// <summary>
        /// 將物件還到物件池內
        /// </summary>
        /// <param name="rock"></param>
        public void ReleasePoolObject(GameObject rock)
        {
            poolRock.Release(rock);
        }
    }
}
