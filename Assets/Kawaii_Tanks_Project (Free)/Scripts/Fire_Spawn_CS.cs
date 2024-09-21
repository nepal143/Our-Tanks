using UnityEngine;
using System.Collections;

namespace ChobiAssets.KTP
{
    public class Fire_Spawn_CS : MonoBehaviour
    {
        [Header("Firing settings")]
        [Tooltip("Array of bullet prefabs.")]
        public GameObject[] bulletPrefabs;
        [Tooltip("Prefab of the muzzle fire.")]
        public GameObject firePrefab;
        [Tooltip("Attack force (AP) of the bullet.")]
        public float attackForce = 100.0f;
        [Tooltip("Initial velocity of the bullet. (Meter per Second)")]
        public float bulletVelocity = 250.0f;
        [Tooltip("Offset distance for spawning the bullet. (Meter)")]
        public float spawnOffset = 1.0f;

        private Transform thisTransform;
        private int currentBulletIndex = 0; // Keep track of the current bullet prefab index.

        void Start()
        {
            thisTransform = transform;
        }

        public void Fire_Linkage()
        { // Called from "Fire_Control_CS".
            // Generate the bullet and shoot it.
            StartCoroutine("Generate_Bullet");
        }

        IEnumerator Generate_Bullet()
        {
            // Instantiate the muzzle fire prefab.
            if (firePrefab)
            {
                Instantiate(firePrefab, thisTransform.position, thisTransform.rotation, thisTransform);
            }

            // Instantiate the bullet prefab.
            var bulletObject = Instantiate(bulletPrefabs[currentBulletIndex], thisTransform.position + thisTransform.forward * spawnOffset, thisTransform.rotation) as GameObject;
             Debug.Log("Bullet Name: " + bulletObject.name);
            // Setup "Bullet_Nav_CS" in the bullet.
            var bulletScript = bulletObject.GetComponent<Bullet_Nav_CS>();
            bulletScript.attackForce = attackForce;

            // Set the tag.
            bulletObject.tag = "Finish"; // (Note.) The object with "Finish" tag cannot be locked on.

            // Set the layer.
            bulletObject.layer = Layer_Settings_CS.Bullet_Layer;

            // Shoot.
            yield return new WaitForFixedUpdate();
            var rigidbody = bulletObject.GetComponent<Rigidbody>();
            var currentVelocity = bulletObject.transform.forward * bulletVelocity;
            rigidbody.velocity = currentVelocity;
        }

        void Update()
        {
            // Check for input to change the bullet prefab.
            if (Input.GetKeyDown(KeyCode.F))
            {
                ChangeBulletPrefab();
            }
        }

        void ChangeBulletPrefab()
        {
            // Increment the bullet prefab index.
            currentBulletIndex++;
            // Wrap around to the beginning if we reach the end of the array.
            if (currentBulletIndex >= bulletPrefabs.Length)
            {
                currentBulletIndex = 0;
            }
        }
    }
}
