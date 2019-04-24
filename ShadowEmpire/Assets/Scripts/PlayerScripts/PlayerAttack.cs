using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowEmpire.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables
        private float timeBtwAttack;
        public float startTimeBtwAttack;
        public Transform attackPos;
        public float attackRange;
        public LayerMask whaIsEnemies;
        public int m_Damage;
        #endregion

        #region MyRegion
        // Update is called once per frame
        void Update()
        {
            if (timeBtwAttack <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whaIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<EnemyScripts.Enemy>().TakeDamage(m_Damage);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whaIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<EnemyScripts.Enemy>().TakeDamage(m_Damage);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whaIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<EnemyScripts.Enemy>().TakeDamage(m_Damage);
                    }
                }
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }


        }
        #endregion

        #region Helper Methods
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
        #endregion
    }


}
