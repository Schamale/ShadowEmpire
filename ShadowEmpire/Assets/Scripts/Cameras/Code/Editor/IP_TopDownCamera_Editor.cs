using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ShadowEmpire.Camera
{
    [CustomEditor(typeof(IP_TopDown_Camera))]
    public class IP_TopDownCamera_Editor : Editor
    {
        #region Variables
        private IP_TopDown_Camera targetCamera;
        #endregion


        #region Main Methods
        void OnEnable()
        {
            targetCamera = (IP_TopDown_Camera)target;
            
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        void OnSceneGUI()
        {
            if (!targetCamera.m_Target)
            {
                if (!targetCamera.m_Target)
                {
                    return;
                }
            }
            Handles.DrawSolidDisc(targetCamera.m_Target.position, Vector3.up, targetCamera.m_Distance);
            
        }
        #endregion

    }
}