using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyFactory.Game
{
    public class Player : MonoBehaviour
    {
        public enum PLAYERSTATE
        {
            IDLE,
            FISHING,
        }

        [SerializeField] private GameObject go_bait;
        private PLAYERSTATE playerState;
        public PLAYERSTATE PlayerState { get { return playerState; } set { playerState = value; } }
        
        private bool bFishing = false;

        private const float MAX_LEFTPOS = -2.28f;
        private const float MAX_RIGHTPOS = 2.2f;
        private const float SHIP_MOVEVALUE = 0.3f;

        private IEnumerator co_fishing;
        private IEnumerator co_returnBait;
        private Coroutine co_bait;

        public void OnInit()
        {

        }
        
        public void PlayerMoveLeft()
        {
            if (playerState == PLAYERSTATE.IDLE && transform.position.x > MAX_LEFTPOS)
            {
                transform.position = new Vector3(transform.position.x - SHIP_MOVEVALUE, transform.position.y);
            }
        }

        public void PlayerMoveRight()
        {
            if (PlayerState == PLAYERSTATE.IDLE && transform.position.x < MAX_RIGHTPOS)
            {
                transform.position = new Vector3(transform.position.x + SHIP_MOVEVALUE, transform.position.y);
            }
        }

        private IEnumerator Fishing()
        {
            bool bStop = true;


            while (bStop)
            {
                if (go_bait.transform.localPosition.y >= -6.5f)
                {
                    go_bait.transform.localPosition = new Vector3(go_bait.transform.localPosition.x, go_bait.transform.localPosition.y - 0.2f);
                    yield return new WaitForSecondsRealtime(0.05f);
                }
                else
                {
                    bStop = false;
                    StopCoroutine(co_fishing);
                    StartCoroutine(ReturnBait());
                }
            }
        }

        private IEnumerator ReturnBait()
        {
            bool bStop = true;

            while(bStop)
            {
                if (go_bait.transform.localPosition.y <= -0.35f)
                {
                    go_bait.transform.localPosition = new Vector3(go_bait.transform.localPosition.x, go_bait.transform.localPosition.y + 0.2f);
                    yield return new WaitForSecondsRealtime(0.05f);
                }
                else
                {
                    bStop = false;
                    go_bait.transform.localPosition = new Vector3(go_bait.transform.localPosition.x, -0.35f);
                    playerState = PLAYERSTATE.IDLE;
                }
            }
        }


        public void PlayFishing()
        {
            playerState = PLAYERSTATE.FISHING;
            co_fishing = Fishing();
            StartCoroutine(co_fishing);
        }
        


        public void GetFish()
        {

        }

        public void LostFish()
        {

        }

        public void UpdatePlayerInfo()
        {

        }
    }
}

