using UnityEngine;

namespace MinimolGames
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] Transform spawnPoint;
        
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}