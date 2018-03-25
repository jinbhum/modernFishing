using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyFactory.Common
{
    public class DeviceTouchEvent : TouchEvent 
    {
        public override void OnTouch()
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if(onPressAction != null)
                {
                    onPressAction(Input.GetTouch(0).position);
                }
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if(onReleaseAction != null)
                {
                    onReleaseAction(Input.GetTouch(0).position);
                }
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if(onMoveAction != null)
                {
                    Vector3 currentTouchPosition = Input.GetTouch(0).position;
                    Vector3 prevTouchPosition = Input.GetTouch(0).position + Input.GetTouch(0).deltaPosition;
                    onMoveAction(currentTouchPosition, prevTouchPosition);
                }
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                if(onStationaryAction != null)
                {
                    onStationaryAction(Input.GetTouch(0).position);
                }
            }
        }
    }
}
