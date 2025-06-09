using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        private float spawnRate = 1.0f;
        public List<GameObject> targets;
        public TextMeshProUGUI scoreText;
        private int score;
        public TextMeshProUGUI gameOverText;
        public bool isGameActive;
        public Button restartButton;
        private Coroutine spawnCoroutine;
        public GameObject titleScreen;
        
        public void StartGame(int difficulty)
        {
            spawnRate /= difficulty;
            isGameActive = true;
            spawnCoroutine = StartCoroutine(SpawnTarget());
            UpdateScore(0);
            titleScreen.SetActive(false);
        }

        IEnumerator SpawnTarget()
        {
            while (isGameActive)
            {
                yield return new WaitForSeconds(spawnRate);
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
            }
        }

        public void UpdateScore(int scoreToAdd)
        {
            score += scoreToAdd;
            scoreText.text = "Score: " + score;
        }
        
        public void GameOver()
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
            
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }

            TargetBase[] allTargets = FindObjectsOfType<TargetBase>();
            foreach (var target in allTargets)
            {
                Destroy(target.gameObject);
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        

    }
}