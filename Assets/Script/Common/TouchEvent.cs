using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TinyFactory.Common
{
    public abstract class TouchEvent : MonoBehaviour 
    {
        protected Action<Vector3> onPressAction;
        public event Action<Vector3> OnPressEvent
        {
            add
            {
                if(onPressAction == null)
                {
                    onPressAction = value;
                }
                else
                {
                    if(!onPressAction.GetInvocationList().Contains(value))
                    {
                        onPressAction += value;
                    }
                }
            }

            remove
            {
                    if(onPressAction.GetInvocationList().Contains(value))
                    {
                        onPressAction -= value;
                    }
            }
        }

        protected Action<Vector3> onReleaseAction;
        public event Action<Vector3> OnReleaseEvent
        {
            add
            {
                if(onReleaseAction == null)
                {
                    onReleaseAction = value;
                }
                else
                {
                    if(!onReleaseAction.GetInvocationList().Contains(value))
                    {
                        onReleaseAction += value;
                    }
                }
            }

            remove
            {
                    if(onReleaseAction.GetInvocationList().Contains(value))
                    {
                        onReleaseAction -= value;
                    }
            }
        }

        protected Action<Vector3, Vector3> onMoveAction;
        public event Action<Vector3, Vector3> OnMoveEvent
        {
            add
            {
                if(onMoveAction == null)
                {
                    onMoveAction = value;
                }
                else
                {
                    if(!onMoveAction.GetInvocationList().Contains(value))
                    {
                        onMoveAction += value;
                    }
                }
            }

            remove
            {
                    if(onMoveAction.GetInvocationList().Contains(value))
                    {
                        onMoveAction -= value;
                    }
            }
        }

        protected Action<Vector3> onStationaryAction;
        public event Action<Vector3> OnStationaryEvent
        {
            add
            {
                if(onStationaryAction == null)
                {
                    onStationaryAction = value;
                }
                else
                {
                    if(!onStationaryAction.GetInvocationList().Contains(value))
                    {
                        onStationaryAction += value;
                    }
                }
            }

            remove
            {
                    if(onStationaryAction.GetInvocationList().Contains(value))
                    {
                        onStationaryAction -= value;
                    }
            }
        }

        public abstract void OnTouch();
    }
}
