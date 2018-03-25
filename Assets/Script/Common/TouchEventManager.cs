using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyFactory.Common
{
    public class TouchEventManager : MonoBehaviour 
    {
        private TouchEvent m_touchEvent;

        public static TouchEventManager _instance;
        public static TouchEventManager In
        {
            get
            {
                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;

#if UNITY_EDITOR    
            m_touchEvent = new EditorTouchEvent(); 
#else   
            m_touchEvent = new DeviceTouchEvent();
#endif
        }

        private void Update()
        {
            m_touchEvent.OnTouch();
        }

        public void AddPressListener(Action<Vector3> pressAction)
        {
            m_touchEvent.OnPressEvent += pressAction;
        }

        public void RemovePressListener(Action<Vector3> pressAction)
        {
            m_touchEvent.OnPressEvent -= pressAction;
        }

        public void AddReleaseListener(Action<Vector3> releaseAction)
        {
            m_touchEvent.OnReleaseEvent += releaseAction;
        }

        public void RemoveReleaseListener(Action<Vector3> releaseAction)
        {
            m_touchEvent.OnReleaseEvent -= releaseAction;
        }

        public void AddMoveListener(Action<Vector3, Vector3> moveAction)
        {
            m_touchEvent.OnMoveEvent += moveAction;
        }

        public void RemoveMoveListener(Action<Vector3, Vector3> moveAction)
        {
            m_touchEvent.OnMoveEvent -= moveAction;
        }

        public void AddStationaryListener(Action<Vector3> stationaryAction)
        {
            m_touchEvent.OnStationaryEvent += stationaryAction;
        }

        public void RemoveStationaryListener(Action<Vector3> stationaryAction)
        {
            m_touchEvent.OnStationaryEvent -= stationaryAction;
        }
    }
}
