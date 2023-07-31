using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MinimolGames
{
    public class PlayerLifeComponetHandler : MonoBehaviour
    {

        #region Members
        [SerializeField]
        private GameObject mLifeObjectReference;

        private List<Image> mLifeObjects;

        private int mMaxPlayerLife;
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            mMaxPlayerLife = ServiceLocator.Instance.PlayerController.PlayerLife;
            InitView();

            PlayerController.OnDamageReceived += SetupView;
        }

        private void OnDisable()
        {
            PlayerController.OnDamageReceived -= SetupView;
        }
        #endregion

        #region Private Methods
        private void SetupView(int aCurrentLife)
        {
            for(int i = 0; i < mLifeObjects.Count; i++)
            {
                mLifeObjects[i].enabled = i < aCurrentLife;
            }
        }

        private void InitView()
        {
            mLifeObjects = new List<Image>();
            for(int i = 0; i < mMaxPlayerLife; i++)
            {
                var newLife = Instantiate(mLifeObjectReference, this.transform);

                var newLifeImage = newLife.GetComponent<Image>();
                newLifeImage.enabled = true;
                mLifeObjects.Add(newLifeImage);
            }
        }
        #endregion
    }
}
