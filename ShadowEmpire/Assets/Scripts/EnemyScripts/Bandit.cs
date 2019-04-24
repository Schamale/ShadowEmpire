using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowEmpire;

namespace ShadowEmpire.EnemyScripts
{
    public class Bandit : Enemy
    {
        #region Variables
        public Transform target;
        public float chaseRadius;
        public float attackRaidus;
        public Patrol m_speed;

        private bool m_chase;
        #endregion

        #region MyRegion
        // Use this for initialization
        void Start()
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (m_health <= 0)
            {
                Destroy(gameObject);
            }
            CheckDistance();
        }
        #endregion

        #region Helper Methods
        void CheckDistance()
        {
            if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRaidus)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, m_speed.speed = 8f * Time.deltaTime);
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseRadius);
        }
        #endregion
    }
}
