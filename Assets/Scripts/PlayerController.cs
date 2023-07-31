using System;
using UnityEngine;

namespace MinimolGames
{
    public class PlayerController : MonoBehaviour
    {
        #region Members
        public static Action<Vector3> OnPlayerMoved;
        public static Action<int> OnDamageReceived;
        public static Action OnPlayerDied;

        [SerializeField]
        private float mMoveSpeed = 5f;

        [SerializeField]
        private float mRotationSpeed = 5f;

        private int mPlayerLife = Constants.MaxPlayerLifeValue;
        public int PlayerLife => mPlayerLife;
        #endregion

        #region Unity Methods
        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Rotate(hit);
            }
            
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (input == Vector3.zero) return;
            Move(input);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constants.EnemyTag))
            {
                mPlayerLife--;
                if(mPlayerLife > 0)
                {
                    OnDamageReceived?.Invoke(mPlayerLife);
                }
                else
                {
                    OnDamageReceived?.Invoke(0);
                    OnPlayerDied?.Invoke();
                    Destroy(this.gameObject);
                }
            }
        }
        #endregion

        #region Private Methods
        private void Move(Vector3 aInput)
        {
            var translation = mMoveSpeed * Time.deltaTime * aInput;
            transform.Translate(translation, Space.World);

            OnPlayerMoved?.Invoke(transform.position);
        }

        private void Rotate(RaycastHit aHit)
        {
            Vector3 direction = aHit.point - transform.position;
            direction.y = 0f; // To prevent tilting up or down

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, mRotationSpeed * Time.deltaTime);
        }
        #endregion
    }
}
