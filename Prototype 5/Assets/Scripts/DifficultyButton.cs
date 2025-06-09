using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class DifficultyButton : MonoBehaviour
    {
        private Button button;
        private GameManager gameManager;
        public int difficulty;

        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(SetDifficulty);
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }

        void SetDifficulty()
        {
            gameManager.StartGame(difficulty);
        }
    }
}