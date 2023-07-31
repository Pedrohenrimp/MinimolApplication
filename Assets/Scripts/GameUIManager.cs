using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MinimolGames
{
    public class GameUIManager : Singleton<GameUIManager>
    {
        #region Members
        [SerializeField]
        private GameObject mGameOverObject;

        [SerializeField]
        private TextMeshProUGUI mScoreValueLabel;


        private int mCurrentScore;
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            mGameOverObject.SetActive(false);
            mCurrentScore = 0;

            PlayerController.OnPlayerDied += OnGameOver;
            Bullet.OnEnemyDied += OnEnemyDied;
        }

        private void OnDisable()
        {
            PlayerController.OnPlayerDied -= OnGameOver;
            Bullet.OnEnemyDied -= OnEnemyDied;
        }
        #endregion

        #region Public Methods
        public void OnPlayAgainButtonClicked()
        {
            ReloadScene();
        }
        #endregion

        #region Private Methods
        private void OnGameOver()
        {
            mGameOverObject.SetActive(true);
        }

        private void ReloadScene()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        private void OnEnemyDied(GameObject aEnemy)
        {
            mCurrentScore++;
            UpdateScore(mCurrentScore);
        }

        private void UpdateScore(int aValue)
        {
            mScoreValueLabel.text = $"{aValue}";
        }
        #endregion
    }
}
