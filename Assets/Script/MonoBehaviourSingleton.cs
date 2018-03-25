using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T>
{
    public int InstanceID;
    public new Transform transform { get; private set; }
    public new GameObject gameObject { get; private set; }
    static bool canCreate = true;

    protected static T m_Instance = null;
    public static T instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = GameObject.FindObjectOfType(typeof(T)) as T;

                if (m_Instance == null)
                {
                    if (canCreate)
                        m_Instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();

                    if (m_Instance == null)
                    {
                        Debug.LogError("MonoBehaviourSingleton Instance Init ERROR - " + typeof(T).ToString());
                    }
                }
                else
                    m_Instance.Init();
            }
            return m_Instance;
        }
    }


    public static bool isEnable
    {
        get
        {
            return m_Instance != null;
        }
    }

    private void Awake()
    {
        Debug.Log("#### singleton TEST");
        Init();
    }

    private void Init()
    {
        if (m_Instance == null)
        {
            //base.Awake();
            transform = base.transform;
            gameObject = base.gameObject;
            InstanceID = GetInstanceID();

            //Debug.Log( "Instance Set : " + +GetInstanceID() );
            m_Instance = this as T;
            OnInit();
        }
        else
        {
            if (m_Instance != this)
                //Debug.Log( "Instance Already : " + GetInstanceID() );
                DestroyImmediate(base.gameObject);
        }
    }

    protected virtual void OnInit()
    {
    }

    //private void OnDestroy()
    //{
    //    OnDelete();
    //    if (m_Instance == this)
    //        m_Instance = null;
    //}

    //protected virtual void OnDelete()
    //{

    //}

    private void OnApplicationQuit()
    {
        canCreate = false;
        m_Instance = null;
    }
}