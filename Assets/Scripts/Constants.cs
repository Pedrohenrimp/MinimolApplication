using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames
{
    public class Constants
    {
        #region Limit Values
        public const int MaxAliveEnemies = 100;

        public const float MinEnemySpawnInterval = 0.1f;
        public const float MaxEnemySpawnInterval = 60.0f;

        public const int MinEnemySpawnRadius = 10;
        public const int MaxEnemySpawnRadius = 100;

        public const int MaxPoolSize = 100;

        public const float MinBulletSpeed = 1.0f;
        public const float MaxBulletSpeed = 10.0f;

        public const int MaxBulletSpawn = 30;

        public const int MaxPlayerLifeValue = 5;
        #endregion

        #region Tags
        public const string PlayerTag = "Player";
        public const string EnemyTag = "Enemy";
        #endregion
    }
}
