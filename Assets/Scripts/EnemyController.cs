using System;
using UnityEngine;
using UnityEngine.AI;

namespace MinimolGames
{
    public class EnemyController : MonoBehaviour
    {
        #region Members
        [SerializeField]
        private float mMoveSpeed = 3f;

        [SerializeField]
        private NavMeshAgent mNavMeshAgent;
        
        private PlayerController mPlayerController;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            mPlayerController = ServiceLocator.Instance.PlayerController;

            if(mNavMeshAgent != null)
                mNavMeshAgent.speed = mMoveSpeed;
        }

        private void OnEnable()
        {
            MoveTowards(mPlayerController.transform.position);
            PlayerController.OnPlayerMoved += MoveTowards;
        }

        private void OnDisable()
        {
            PlayerController.OnPlayerMoved -= MoveTowards;
        }
        #endregion

        #region Private Methods
        private void MoveTowards(Vector3 aTargetPosition)
        {
            mNavMeshAgent.SetDestination(aTargetPosition);
        }
        #endregion


    }
}