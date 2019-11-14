using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    /// <summary>
    /// This class defines the boss's behavior when it is retreating after
    /// an attack.
    /// </summary>
    public class BossStateRetreat : BossState
    {
        /// <summary>
        /// This function updates the boss every frame.
        /// </summary>
        /// <param name="boss"> The boss that this state applies to. </param>
        /// <returns> A new state. </returns>
        public override BossState Update(WhiteBossController boss)
        {
            // switch to idle

            // switch to move around level

            // switch to dead

            return null;
        } // ends the Update() function
    } // ends the BossStateRetreat class
} // ends the White namespace