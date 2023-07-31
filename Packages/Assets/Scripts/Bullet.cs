using System;
using UnityEngine;

namespace MinimolGames
{
    public class Bullet : MonoBehaviour
    {
        void Start()
        {
            Destroy(gameObject, 10f);
        }

        void Update()
        {
            transform.Translate(10f * Time.deltaTime * transform.forward, Space.World);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}