using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyFactory.Game.GamePlay;
using TinyFactory.Game.Data;


public class Fish : MonoBehaviour, ILife
{
    public enum MOVESTATE
    {
        GOLEFT,
        GORIGHT,
    }

    [SerializeField] private int fishID;
    [SerializeField] private float moveSpeed;

    public int FishID { get; set; }
    public float MoveSpeed { get; set; }

    private MOVESTATE moveState;
    public MOVESTATE MoveState { get; set; }
    
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        moveState = MOVESTATE.GORIGHT;
    }


    private void MakeFish()
    {

    }

    void LateUpdate()
    {
        Move();
    }

    public void Move()
    {
        if(moveState == MOVESTATE.GORIGHT)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + moveSpeed, transform.localPosition.y);

            if(transform.localPosition.x > 3.8f)
                moveState = MOVESTATE.GOLEFT;
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x - moveSpeed, transform.localPosition.y);

            if (transform.localPosition.x < -3.8f)
                moveState = MOVESTATE.GORIGHT;
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("#### test collider");

        if(col.gameObject.tag == "Bait")
        {
            Death();
        }
    }
}

