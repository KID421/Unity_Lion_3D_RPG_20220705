using UnityEngine;

namespace KID
{
    /// <summary>
    /// ²yÅé
    /// </summary>
    public class Ball : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name.Contains("¦aªO"))
            {
                Destroy(gameObject);
            }
        }
    }
}
