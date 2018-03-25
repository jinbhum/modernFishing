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
    public int FishID { get { return fishID; } set { fishID = value; } }
    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }

    private bool bGoingRight;
    private MOVESTATE moveState;
    public MOVESTATE MoveState { get { return moveState; } set { moveState = value; } }
    
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        bGoingRight = true;
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

