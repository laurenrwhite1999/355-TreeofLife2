using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    /// <summary>
    /// This class defines what the boss does when it is in attack mode.
    /// </summary>
    public class BossStateAttack : BossState
    {
        /// <summary>
        /// The delay between each projectile being shot.
        /// </summary>
        float timeBetweenShots = 0.5f;

        /// <summary>
        /// The time left until the next projectile is fired.
        /// </summary>
        float timeUntilNextShot = 0;

        /// <summary>
        /// This function updates the boss each frame.
        /// </summary>
        /// <param name="boss"> The boss that this state applies to. </param>
        /// <returns> A new state. </returns>
        public override BossState Update(WhiteBossController boss)
        {
            Debug.Log("attack");

            Vector3 vectorToPlayer = boss.VectorToAttackTarget();

            timeUntilNextShot -= Time.deltaTime;
            if(timeUntilNextShot <=0)
            {
                boss.ShootProjectile();
                timeUntilNextShot = timeBetweenShots;
            } // ends the if statement

            boss.ShootProjectile();

            if (!boss.CanSeeAttackTarget()) return new BossStateIdle(); // if the player gets too far away from the enemy return the enemy to idle

            // switch to retreat state
            // once the boss has finished its attack, it retreats a short distance away from the player

            // switch to dead state

            return null;
        } // ends the Update() function
    } // ends the BossStateAttack class
} // ends the White namespace