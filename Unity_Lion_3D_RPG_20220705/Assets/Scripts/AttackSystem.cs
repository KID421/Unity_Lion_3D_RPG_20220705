using UnityEngine;
using System.Collections;

namespace KID
{
    /// <summary>
    /// �����򩳨t��
    /// </summary>
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField, Header("�������")]
        private DataAttack dataAttack;

        private bool canAttack = true;

        private void OnDrawGizmos()
        {
            Gizmos.color = dataAttack.attackAreaColor;

            Gizmos.matrix = Matrix4x4.TRS(
                transform.position +
                transform.TransformDirection(dataAttack.attackAreaOffset),
                transform.rotation, transform.localScale
                );

            Gizmos.DrawCube(
                Vector3.zero,
                dataAttack.attackAreaSize);
        }

        /// <summary>
        /// �}�l����
        /// </summary>
        public void StartAttack()
        {
            if (!canAttack) return;
            StartCoroutine(AttackFlow());
        }

        /// <summary>
        /// �����y�{
        /// </summary>
        private IEnumerator AttackFlow()
        {
            canAttack = false;
            yield return new WaitForSeconds(dataAttack.delayAttack);
            CheckAttackArea();

            yield return new WaitForSeconds(dataAttack.waitAttackEnd);
            canAttack = true;
        }

        /// <summary>
        /// �ˬd�����ϰ�O�_�I����ؼйϼh
        /// </summary>
        private void CheckAttackArea()
        {
            Collider[] hits = Physics.OverlapBox(
                transform.position +
                transform.TransformDirection(dataAttack.attackAreaOffset),
                dataAttack.attackAreaSize / 2,
                transform.rotation, dataAttack.layerTarget);

            if (hits.Length > 0)
            {
                print(hits[0].name);
            }
        }
    }
}
