using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    /// <summary>
    /// This class defines the behavior of the boss when it is persuing the
    /// player.
    /// </summary>
    public class BossStatePersue : BossState
    {
        /// <summary>
        /// This function updates the boss every frame.
        /// </summary>
        /// <param name="boss"> The boss that this state applies to. </param>
        /// <returns> A new state. </returns>
        public override BossState Update(WhiteBossController boss)
        {
            // move towards player:
            Vector3 vectorToPlayer = boss.VectorToAttackTarget();
            
            Vector3 dirToPlayer = vectorToPlayer.normalized;
            boss.transform.position += dirToPlayer * boss.speed * Time.deltaTime;

            /////////////////////////// TRANSITIONS:

            if(vectorToPlayer.sqrMagnitude < boss.pursueDistanceThreshold * boss.pursueDistanceThreshold) return new BossStateAttack(); // if dis < threshold transition to attack

            //if (!boss.CanSeeAttackTarget()) return new BossStateIdle(); // if we can't see the player transition to idle

            // switch to attack state

            // switch to dead state
            return null;
        } // ends the Update() function
    } // ends the BossStatePersue class
} // ends the White namespace