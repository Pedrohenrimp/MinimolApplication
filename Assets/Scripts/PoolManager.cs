using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames
{
    public class PoolManager : MonoBehaviour
    {
        #region Members
        [SerializeField]
        private GameObject mObjectPrefab;

        [SerializeField]
        private int mInitialPoolSize = 0;

        [SerializeField]
        private int mMaxPoolSize = Constants.MaxPoolSize;

        [SerializeField]
        private List<PoolObject> mObjectPool;
        #endregion

        #region Unity Methods
        private void Awake()
        {
            mObjectPool = new List<PoolObject>();
            for (int i = 0; i < mInitialPoolSize; i++)
            {
                AddNewObjectToPool();
            }
        }
        #endregion

        #region Public Methods
        public GameObject GetPooledObject()
        {
            for(int i = 0; i < mObjectPool.Count; i++)
            {
                if (!mObjectPool[i].IsUsed)
                {
                    mObjectPool[i].SetUse(true);
                    return mObjectPool[i].GetObject();
                }
            }

            if(mObjectPool.Count < mMaxPoolSize)
            {
                var newPoolObject = AddNewObjectToPool();
                newPoolObject.SetUse(true);
                return newPoolObject.GetObject();
            }

            return null;
        }

        public void ReturnObjectToPool(GameObject aObject)
        {
            for(int i = 0; i < mObjectPool.Count; i++)
            {
                if (mObjectPool[i].GetObject() == aObject)
                {
                    mObjectPool[i].SetUse(false);
                    break;
                }
            }
        }

        public int GetPoolSize()
        {
            return mObjectPool.Count;
        }
        #endregion

        #region Private Methods
        private PoolObject AddNewObjectToPool()
        {
            GameObject obj = Instantiate(mObjectPrefab, transform.position, Quaternion.identity, this.transform);
            PoolObject poolObj = new PoolObject(obj);
            mObjectPool.Add(poolObj);

            return poolObj;
        }
        #endregion
    }
}
