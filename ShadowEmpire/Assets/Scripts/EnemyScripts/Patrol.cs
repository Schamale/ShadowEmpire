using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowEmpire;

namespace ShadowEmpire.EnemyScripts
{
    #region MyRegion
    public class Patrol : MonoBehaviour
    {
        #region Variables
        public float speed;
        public float startWaitTime;
        public Transform[] moveSpots;
        //public Transform moveSpots;
        //public float minX;
        //public float minY;
        //public float maxX;
        //public float maxY;

        private Animator m_animator;
        private Rigidbody2D m_rg2d;
        private float waitTime;
        private int randomSpot;
        #endregion

        // Use this for initialization
        void Start()
        {
            waitTime = startWaitTime;
            m_animator = GetComponent<Animator>();
            m_rg2d = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {

            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
            m_animator.SetBool("isPatrolling", true);
            //if (Vector2.Distance(transform.position, moveSpots.position) < 0.2f)
            //{
            //    if (waitTime <= 0)
            //    {
            //        waitTime = startWaitTime;

            //    }
            //    else
            //    {
            //        m_animator.SetBool("isPatrolling", false);
            //        waitTime -= Time.deltaTime;
            //    }
            //}

            //move with wayPoints
            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;

                }
                else
                {
                    m_animator.SetBool("isPatrolling", false);
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }
    #endregion

    #region Helper Methods

    #endregion
}
