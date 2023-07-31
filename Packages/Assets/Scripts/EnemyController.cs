using System;
using UnityEngine;

namespace MinimolGames
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 3f;
        void Update()
        {
            var player = FindObjectOfType<PlayerController>();
            if (player == null) return;
            MoveTowards(player.transform);
        }

        void MoveTowards(Transform target)
        {
            var direction = (target.position - transform.position).normalized;
            transform.Translate(moveSpeed * Time.deltaTime * direction, Space.World);
        }

        void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag("Player"))
            {
                var player = other.gameObject.GetComponent<PlayerController>();
                Destroy(player.gameObject);
            }
        }
    }
}