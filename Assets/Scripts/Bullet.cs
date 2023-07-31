using System;
using System.Collections;
using UnityEngine;

namespace MinimolGames
{
    public class Bullet : MonoBehaviour
    {
        #region Members
        public static event Action<GameObject> OnEnemyDied;
        public static event Action<GameObject> OnMovementEnded;

        [SerializeField]
        [Range(Constants.MinBulletSpeed, Constants.MaxBulletSpeed)]
        private float mBulletSpeed = Constants.MaxBulletSpeed;
        #endregion

        #region Unity Methods

        private void OnEnable()
        {
            StartMovement();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constants.EnemyTag))
            {
                OnEnemyDied?.Invoke(other.gameObject);
                OnMovementEnded?.Invoke(this.gameObject);
            }
        }
        #endregion

        #region Private Methods
        private void StartMovement()
        {
            StartCoroutine(MoveObject());
        }

        private IEnumerator MoveObject()
        {
            while (!IsOutOfCameraView())
            {
                transform.Translate(mBulletSpeed * Time.deltaTime * transform.forward, Space.World);

                yield return null;

            }

            OnMovementEnded?.Invoke(this.gameObject);
        }

        private bool IsOutOfCameraView()
        {
            var viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

            return viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1;
        }
        #endregion
    }
}