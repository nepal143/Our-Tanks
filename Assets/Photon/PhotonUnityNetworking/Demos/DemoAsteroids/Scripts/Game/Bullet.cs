using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun.Demo.Asteroids
{
    public class Bullet : MonoBehaviour
    {
        public Player Owner { get; private set; }

        private Rigidbody rigidbody;
        private float initialSpeed = 20.0f;
        private float maxSpeedMultiplier = 3.0f; // Adjust this value as needed

        public void Start()
        {
            Destroy(gameObject, 3.0f);
        }

        public void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }

        public void InitializeBullet(Player owner, Vector3 originalDirection, float lag, float pressDuration)
        {
            Owner = owner;

            transform.forward = originalDirection;

            rigidbody = GetComponent<Rigidbody>();
            float speedMultiplier = Mathf.Clamp(pressDuration, 1.0f, maxSpeedMultiplier); // Adjust the minimum and maximum multipliers
            rigidbody.velocity = originalDirection * initialSpeed * speedMultiplier;
            rigidbody.position += rigidbody.velocity * lag;
        }
    }
}
