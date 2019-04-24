using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowEmpire
{
    public class KnockBack : MonoBehaviour
    {

        #region Variables
        public float m_thrust;
        #endregion

        #region MyRegion
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Helper Methods
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("enemy"))
            {
                Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
                if (enemy != null)
                {
                    enemy.isKinematic = false;
                    Vector2 different = enemy.transform.position - transform.position;
                    different = different.normalized * m_thrust;
                    enemy.AddForce(different, ForceMode2D.Impulse);
                    enemy.isKinematic = true;
                }
            }
        }
        #endregion
    }
}
