using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowEmpire.PlayerAnimation
{
 
    #region MyRegion
    public class CharacterAnim : MonoBehaviour
    {

        #region Variables
        private Animator m_anim;
        private bool m_FacingRight = true;
        #endregion

        // Use this for initialization
        void Start()
        {
            m_anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                m_anim.SetBool("isRunning", true);
            }
            else
            {
                m_anim.SetBool("isRunning", false);
            }
        }
    }
    #endregion

    #region Helper Methods


    #endregion
}

