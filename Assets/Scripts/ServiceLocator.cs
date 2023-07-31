using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames
{
    public class ServiceLocator : Singleton<ServiceLocator>
    {
        #region Object References

        [SerializeField]
        private PlayerController mPlayerController;
        public PlayerController PlayerController => mPlayerController;
        
        #endregion
    }
}
