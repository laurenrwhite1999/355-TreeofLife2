using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    /// <summary>
    /// This class enables enemies to fire basic projectiles.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class WhiteProjectile : MonoBehaviour
    {
        /// <summary>
        /// The specific game object that fired the projectile.
        /// </summary>
        protected GameObject owner;

        /// <summary>
        /// The game object that represents the enemy.
        /// </summary>
        protected Rigidbody body;

        /// <summary>
        /// How fast each projectile is moving.
        /// </summary>
        float speed = 10;

        /// <summary>
        /// How many seconds a projectile should live.
        /// </summary>
        float lifetime = 2;

        /// <summary>
        /// How many seconds this projectile has been alive.
        /// </summary>
        float age = 0;

        /// <summary>
        /// This function gets the object that will be firing the projectiles and stores it
        /// in the variable "body".
        /// </summary>
        void Start()
        {
            body = GetComponent<Rigidbody>();
        } // ends the Start() function

        /// <summary>
        /// This function makes the object fire a projectile.
        /// </summary>
        /// <param name="owner"> The object that fired the projectile. </param>
        /// <param name="direction"> The direction that the projectile is being
        /// fired in. </param>
        public void Shoot(GameObject owner, Vector3 direction)
        {
            this.owner = owner;
            body = GetComponent<Rigidbody>();
            body.velocity = direction * speed;
        } // ends the Shoot() function

        /// <summary>
        /// This function updates the projectile every frame.
        /// </summary>
        void Update()
        {
            GetOlderAndDie();
        } // ends the Update() function

        /// <summary>
        /// This function destroys each projectile once it has reached the end of its
        /// lifespan.
        /// </summary>
        protected void GetOlderAndDie()
        {
            age += Time.deltaTime;

            if (age >= lifetime) Destroy(gameObject);
        } // ends the GetOlderAndDie() function

        /// <summary>
        /// This function prevents the projectile from being effected by its shooter and
        /// also destroys the projectile once it has come into contact with the player.
        /// </summary>
        /// <param name="collider"> Determines whether the projectile has hit
        /// something. </param>
        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject == owner) return; // don't hit the shooter of this projectile

            //WhiteProjectile p collider.GetComponent<WhiteProjectile>();
            //if(p != null && dontHitOtherProjectiles)

            print("projectile hit something");
            Destroy(gameObject);
        } // ends the OnTriggerEnter() function
    } // ends the WhiteProjectile class
} // ends the White namespace