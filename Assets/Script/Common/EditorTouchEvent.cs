using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyFactory.Common
{
    public class EditorTouchEvent : TouchEvent 
    {
        private const float TOUCH_SENSETIVE = 1.0f;
        private bool m_bIsPressed = false;
        private Vector3 m_vCurrentTouchPosition;
        private Vector3 m_vPrevTouchPosition;

        public override void OnTouch()
        {
            if(Input.GetMouseButtonDown(0))
            {
                m_vCurrentTouchPosition = Input.mousePosition;
                m_vPrevTouchPosition = Input.mousePosition;
                m_bIsPressed = true;

                if(onPressAction != null)
                {
                    onPressAction(m_vCurrentTouchPosition);
                }
            }
            else if(Input.GetMouseButtonUp(0))
            {
                m_bIsPressed = false;
                m_vCurrentTouchPosition = Input.mousePosition;
                m_vPrevTouchPosition = Input.mousePosition;

                if(onReleaseAction != null)
                {
                    onReleaseAction(m_vCurrentTouchPosition);
                }

                TouchPositionInit();
            }
            else if(Input.GetMouseButton(0) && m_bIsPressed)
            {
                m_vPrevTouchPosition = m_vCurrentTouchPosition;
                m_vCurrentTouchPosition = Input.mousePosition;

                float distance = Vector3.Distance(m_vCurrentTouchPosition, m_vPrevTouchPosition);

                if(distance > TOUCH_SENSETIVE)
                {
                    if(onMoveAction != null)
                    {
                        onMoveAction(m_vCurrentTouchPosition, m_vPrevTouchPosition);
                    }
                }
                else
                {
                    if(onStationaryAction != null)
                    {
                        onStationaryAction(m_vCurrentTouchPosition);
                    }
                }
            }
        }

        private void TouchPositionInit()
        {
            m_vCurrentTouchPosition = Vector3.zero;
            m_vPrevTouchPosition = Vector3.zero;
        }
    }
}