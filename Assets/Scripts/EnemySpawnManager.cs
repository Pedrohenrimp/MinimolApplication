using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames
{
    public class EnemySpawnManager : MonoBehaviour
    {
        #region Members
        [SerializeField]
        private PoolManager mEnemyPoolManager;

        [SerializeField]
        [Range(Constants.MinEnemySpawnInterval, Constants.MaxEnemySpawnInterval)]
        private float mSpawnInterval = Constants.MinEnemySpawnInterval;

        [SerializeField]
        [Range(Constants.MinEnemySpawnRadius, Constants.MaxEnemySpawnRadius)]
        private int mSpawnRadius = Constants.MinEnemySpawnRadius;

        [SerializeField]
        [Range(1, Constants.MaxPoolSize)]
        private int mMaxAliveEnemies = Constants.MaxAliveEnemies;


        private int mAliveEnemiesCount = 0;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            Bullet.OnEnemyDied += RemoveEnemy;
            PlayerController.OnPlayerDied += StopSpawn;

            InvokeRepeating(nameof(SpawnEnemy), mSpawnInterval, mSpawnInterval);
        }

        private void OnDestroy()
        {
            Bullet.OnEnemyDied -= RemoveEnemy;
            PlayerController.OnPlayerDied -= StopSpawn;
        }
        #endregion

        #region Private Methods
        private void SpawnEnemy()
        {
            if(mAliveEnemiesCount < mMaxAliveEnemies)
            {
                var newEnemy = mEnemyPoolManager.GetPooledObject();
                if(newEnemy != null)
                {
                    mAliveEnemiesCount++;
                    newEnemy.transform.position = GetSpawnPosition();
                }
            }
        }

        private Vector3 GetSpawnPosition()
        {
            var randomDirection = Random.Range(0.0f, 360f) * Mathf.Deg2Rad;
            var posX = mSpawnRadius * Mathf.Cos(randomDirection);
            var posZ = mSpawnRadius * Mathf.Sin(randomDirection);

            var playerPosition = ServiceLocator.Instance.PlayerController.transform.position;
            var spawnPosition = new Vector3(posX, 0.0f,posZ) + playerPosition;

            return spawnPosition;
        }

        private void RemoveEnemy(GameObject aEnemyObject)
        {
            mEnemyPoolManager.ReturnObjectToPool(aEnemyObject);
            mAliveEnemiesCount--;
        }

        private void StopSpawn()
        {
            CancelInvoke(nameof(SpawnEnemy));
        }
        #endregion
    }
}
