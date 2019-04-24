using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShadowEmpire;

namespace ShadowEmpire.Player
{
    public enum PlayerState
    {
        walk,
        attack,
        interact
    }
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables
        public float speed;
        public bool facingRight = true;
        public PlayerState currentState;

        private bool m_attack;
        private bool m_attack2;
        private bool m_slide;
        private Rigidbody2D m_rigidbody;
        private Vector3 change;
        private Animator m_animator;
        private bool m_attack3;
        #endregion

        #region MyRegion
        // Use this for initialization
        void Start()
        {
            m_animator = GetComponent<Animator>();
            m_rigidbody = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
            change = Vector3.zero;
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            //if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
            //{
            //    StartCoroutine(AttackCo());
            //}
            if (change != Vector3.zero)
            {
                MoveCharacter();
            }
        }

        //private IEnumerator AttackCo()
        //{
        //    m_animator.SetBool("attacking", true);
        //    currentState = PlayerState.attack;
        //    yield return null;
        //    m_animator.SetBool("attacking", false);
        //    yield return new WaitForSeconds(.66f);
        //    currentState = PlayerState.walk;
        //}
        private void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            if (h > 0 && !facingRight)
                Flip();
            else if (h < 0 && facingRight)
                Flip();
            HandleAttack();
            ResetValues();
        }
        #endregion

        #region HelperMethods
        void MoveCharacter()
        {
            if (!m_animator.GetBool("slide") && !this.m_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && !this.m_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack01") && !this.m_animator.GetCurrentAnimatorStateInfo(0).IsTag("attack02"))
            {
                m_rigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
            }
            if (m_slide && !this.m_animator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
            {
                m_animator.SetBool("slide", true);
            }
            else if (!this.m_animator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
            {
                m_animator.SetBool("slide", false);
            }
            
        }
        void Flip()
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        private void HandleAttack()
        {
            if (m_attack && !this.m_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                m_animator.SetTrigger("attack");
            }
            if (m_attack2 && !this.m_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack01"))
            {
                m_animator.SetTrigger("attack2");
            }
            if (m_attack3 && !this.m_animator.GetCurrentAnimatorStateInfo(0).IsTag("attack02"))
            {
                m_animator.SetTrigger("attack3");
            }
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                m_attack = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                m_attack2 = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                m_attack3 = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_slide = true;
            }
            
        }
        private void ResetValues()
        {
            m_attack = false;
            m_slide = false;
            m_attack2 = false;
            m_attack3 = false;
        }
        #endregion

    }
}


