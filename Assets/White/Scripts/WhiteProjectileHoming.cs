using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    /// <summary>
    /// This class enables the enemies to fire homing projectiles.
    /// </summary>
    public class WhiteProjectileHoming : WhiteProjectile
    {
        /// <summary>
        /// The target that the enemy will attempt to fire at.
        /// </summary>
        Transform target;

        /// <summary>
        /// The force of each projectile.
        /// </summary>
        private float homingForce = 10000;

        /// <summary>
        /// The max amount of force that a projectile can have.
        /// </summary>
        float maxForce = 1000;

        /// <summary>
        /// This function makes the enemies shoot the homing projectiles.
        /// </summary>
        /// <param name="owner"> The object that fired the homing projectile. </param>
        /// <param name="target"> The target that the enemy is shooting a projectile
        /// at. </param>
        /// <param name="direction"> The direction that the enemy is firing the
        /// projectile in. </param>
        public void Shoot(GameObject owner, Transform target, Vector3 direction)
        {
            this.target = target;

            Shoot(owner, direction);
        } // ends the Shoot() function

        /// <summary>
        /// This function updates the projectile every frame.
        /// </summary>
        void Update()
        {
            GetOlderAndDie();

            Homing();

            transform.rotation = Quaternion.FromToRotation(Vector3.up, body.velocity.normalized);
        } // ends the Update() function

        /// <summary>
        /// This function causes the homing projectiles to arc toward the player.
        /// </summary>
        private void Homing()
        {            
            Vector3 dir = (target.position - transform.position).normalized;

            Vector3 steer = dir * homingForce - body.velocity;
            steer = steer.normalized * maxForce;

            body.AddForce(steer * Time.deltaTime);
        } // ends the Homing() function
    } // ends the WhiteProjectileHoming class
} //ends the White namespace