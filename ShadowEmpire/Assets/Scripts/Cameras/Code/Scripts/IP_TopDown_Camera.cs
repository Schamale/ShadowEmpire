﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowEmpire.Camera
{
    public class IP_TopDown_Camera : MonoBehaviour
    {
        #region Variables
        public Transform m_Target;
        public float m_Height = 10f;
        public float m_Distance = 20f;

        [SerializeField]
        private float m_Angle = 45f;
        [SerializeField]
        private float m_SmoothSpeed = 0.5f;

        private Vector3 refVelocity;
        #endregion

        #region MyRegion
        // Use this for initialization
        void Start()
        {
            HandleCamera();
        }
        // Update is called once per frame
        void Update()
        {
            HandleCamera();
        }
        #endregion
        #region Helper Methods
        protected virtual void HandleCamera()
        {
            if (!m_Target)
            {
                return;
            }

            //Build World Position Vector
            Vector3 worldPosition = (Vector3.forward * -m_Distance) + (Vector3.up * m_Height);
            Debug.DrawLine(m_Target.position, worldPosition, Color.red);

            //Build Rotated Vector
            Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPosition;
            Debug.DrawLine(m_Target.position, rotatedVector, Color.green);

            //Move Our Position
            Vector3 flatTargetPosition = m_Target.position;
            flatTargetPosition.y = 0f;
            Vector3 finalPosition = flatTargetPosition + rotatedVector;
            Debug.DrawLine(m_Target.position, finalPosition, Color.blue);

            transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, m_SmoothSpeed);
            transform.LookAt(flatTargetPosition);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0f, 1f, 0f, 0.25f);
            if (m_Target)
            {
                Gizmos.DrawLine(transform.position, m_Target.position);
                Gizmos.DrawSphere(m_Target.position, 1.5f);
            }

            Gizmos.DrawSphere(transform.position, 1.5f);
        }
        #endregion

    }
}



