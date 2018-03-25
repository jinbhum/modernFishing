using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TinyFactory.Game
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        [SerializeField] private GameObject go_managerGroup;
        [SerializeField] private DataManager manager_data;
        [SerializeField] private StageManager manager_stage;
        [SerializeField] private ResourceManager manager_resource;
        [SerializeField] private UIManager manager_UI;

        private int countFish;
        public int CountFish { get { return countFish; } set { countFish = value; } }
        private int score;
        public int Score { get { return score; } set { score = value; } }
        private double playTime;
        public double PlayTime { get { return playTime; } set { playTime = value; } }
        private int currentStage;
        public int CurrentStage { get { return currentStage; } set { currentStage = value; } }

        //[SerializeField] private SoundManager manager_sound;

        void Awake()
        {
            OnInitilalize();
        }


        void OnInitilalize()
        {
            DontDestroyOnLoad(go_managerGroup);


            Debug.Log("### 게임을 시작합니다");
        }

        public void GameStart()
        {
            SceneManager.LoadScene("game");
        }

        public void OpenOption()
        {

        }
    }
}


