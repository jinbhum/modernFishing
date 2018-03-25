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
        [SerializeField] private GameObject go_fishGroup;

        private List<Fish> FishList = new List<Fish>();


        private Player createPlayer;
        private const int MAX_FISHCOUNT = 10;

        void Start()
        {
            Init();
        }

        private void Init()
        {
            Debug.Log("stage manager init");
            CreateStage();


        }

        public void MoveLeft()
        {
            createPlayer.PlayerMoveLeft();
        }

        public void MoveRight()
        {
            createPlayer.PlayerMoveRight();
        }

        public void Fishing()
        {
            createPlayer.PlayFishing();
        }

        public void CreateStage()
        {
            CreatePlayer();
            CreateFish();

            if (createPlayer != null && FishList.Count > 1)
                GameStart();
            else
                Debug.Log("stage create error !! - failed created player or fish");
        }

        public void CreatePlayer()
        {
            GameObject go = Instantiate(go_player, go_stageObject.transform) as GameObject;
            go.transform.position = new Vector3(0.12f, 3.48f);
            createPlayer = go.GetComponent<Player>();

        }

        public void CreateFish()
        {
            for(int i = 0; i < MAX_FISHCOUNT; i++)
            {
                GameObject go = Instantiate(go_fish, go_fishGroup.transform) as GameObject;
                go.transform.position = new Vector3(-3.4f, Random.Range(-2.5f, 2.0f));
                FishList.Add(go.GetComponent<Fish>());
            }
        }

        public void GameStart()
        {

        }


        public void ReturnMainMenu()
        {
            SceneManager.LoadScene("main");
        }
    }
}

