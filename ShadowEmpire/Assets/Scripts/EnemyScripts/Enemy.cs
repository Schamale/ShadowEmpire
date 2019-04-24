using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowEmpire;

namespace ShadowEmpire.EnemyScripts
{
    public class Enemy : MonoBehaviour
    {
        #region Variables
        public int m_health;
        //public float m_speed;
        public int baseAttack;

        private Animator anim;
        #endregion
        
        #region MyRegion 
        // Use this for initialization
        void Start()
        {
            //anim = GetComponent<Animator>();
            //anim.SetBool("isRunning", true);
        }

        // Update is called once per frame
        void Update()
        {
            //transform.Translate(Vector2.left * m_speed * Time.deltaTime);
            if (m_health <= 0)
            {
                Destroy(gameObject);
            }
        }
        #endregion

        #region Helper Methods
        public void TakeDamage(int damage)
        {
            m_health -= damage;
            Debug.Log("damage Taken");
        }
        #endregion
    }
}
