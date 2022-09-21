using UnityEngine;

namespace KID
{
    /// <summary>
    /// ���a���o�D��
    /// </summary>
    public class PlayerGetProp : MonoBehaviour
    {
        private ObjectPoolRock objectPoolRock;
        private string propRock = "���Y�H��";

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
