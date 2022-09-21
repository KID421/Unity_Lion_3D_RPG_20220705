using UnityEngine;

namespace KID
{
    /// <summary>
    /// 玩家取得道具
    /// </summary>
    public class PlayerGetProp : MonoBehaviour
    {
        private ObjectPoolRock objectPoolRock;
        private string propRock = "石頭碎片";

        private void Awake()
        {
            objectPoolRock = FindObjectOfType<ObjectPoolRock>();
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.name.Contains(propRock))
            {
                objectPoolRock.ReleasePoolObject(hit.gameObject);
            }
        }
    }
}
