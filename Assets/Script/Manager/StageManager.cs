using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TinyFactory.Game
{
    public class StageManager : MonoBehaviourSingleton<StageManager>
    {
        [SerializeField] private GameObject go_player;
        [SerializeField] private GameObject go_fish;
        [SerializeField] private GameObject go_stageObject;

        private Player makePlayer;
        

        void Start()
        {
            Init();
        }

        private void Init()
        {
            Debug.Log("stage manager init");
            GameObject go = Instantiate(go_player, go_stageObject.transform) as GameObject;
            go.transform.position = new Vector3(0.12f, 3.48f);
            makePlayer = go.GetComponent<Player>();
        }

        public void MoveLeft()
        {
            makePlayer.PlayerMoveLeft();
        }

        public void MoveRight()
        {
            makePlayer.PlayerMoveRight();
        }

        public void Fishing()
        {
            makePlayer.PlayFishing();
        }


        public void ReturnMainMenu()
        {
            SceneManager.LoadScene("main");
        }
    }
}

