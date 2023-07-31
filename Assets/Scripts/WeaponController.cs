using UnityEngine;

namespace MinimolGames
{
    public class WeaponController : MonoBehaviour
    {
        #region Members
        [SerializeField]
        private Transform mSpawnPoint;

        [SerializeField]
        private PoolManager mBulletPoolManager;

        private int mActiveBullets = 0;
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            Bullet.OnMovementEnded += RemoveBullet;
        }

        private void OnDisable()
        {
            Bullet.OnMovementEnded -= RemoveBullet;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Fire();
        }
        #endregion

        #region Private Methods
        private void Fire()
        {
            if(mActiveBullets < Constants.MaxBulletSpawn)
            {
                var newBullet =  mBulletPoolManager.GetPooledObject();
            
                if(newBullet != null)
                {
                    mActiveBullets++;
                    newBullet.transform.position = mSpawnPoint.position;
                    newBullet.transform.rotation = mSpawnPoint.rotation;
                    newBullet.SetActive(true);
                }
            }
        }

        private void RemoveBullet(GameObject aBulletObject)
        {
            mBulletPoolManager.ReturnObjectToPool(aBulletObject);
            mActiveBullets--;
        }
        #endregion
    }
}