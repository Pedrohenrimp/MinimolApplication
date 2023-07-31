using UnityEngine;

namespace MinimolGames
{
    public class PoolObject
    {
        #region Members
        [SerializeField]
        private GameObject mObject;

        [SerializeField]
        private bool mIsUsed;
        public bool IsUsed => mIsUsed;
        #endregion

        #region Public Methods
        public PoolObject(GameObject aObject)
        {
            mObject = aObject;
            mIsUsed = false;
            mObject.SetActive(false);
        }

        public void SetUse(bool aIsUsed)
        {
            mIsUsed = aIsUsed;
            mObject.SetActive(aIsUsed);
        }

        public GameObject GetObject()
        {
            return mObject;
        }
        #endregion
    }
}
