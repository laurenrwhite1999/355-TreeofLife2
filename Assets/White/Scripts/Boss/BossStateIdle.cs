using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    /// <summary>
    /// This class defines the boss's behavior while it is idle.
    /// </summary>
    public class BossStateIdle : BossState
    {
        /// <summary>
        /// This function updates the boss every frame.
        /// </summary>
        /// <param name="boss"> The boss that this state applies to. </param>
        /// <returns> A new state. </returns>
        public override BossState Update(WhiteBossController boss)
        {
            // do stuff to the boss...
            Debug.Log("idle");

            // transitions to other states:
            if (boss.CanSeeAttackTarget())
            {
                // transition to persue state...
                return new BossStatePersue();
            } // ends the if statement

            // switch to move around level state

            // switch to dead state

            return null; // stay in current state
        } // ends the Update() function

        /// <summary>
        /// This function determines what the boss does upon entering the idle state.
        /// </summary>
        /// <param name="boss"> The boss that this state applies to. </param>
        public override void OnStart(WhiteBossController boss)
        {
            
        } // ends the OnStart() function

        /// <summary>
        /// This function determines what happens when the boss is hit.
        /// </summary>
        /// <param name="collider"> Allows the boss to be hit. </param>
        void OnTriggerEnter(Collider collider)
        {
            // if the boss was hit, return BossStateMove
            Debug.Log("boss was hit");

            return;
        } // ends the OnTriggerEnter() function
    } // ends the BossStateIdle class
} // ends the White namespace