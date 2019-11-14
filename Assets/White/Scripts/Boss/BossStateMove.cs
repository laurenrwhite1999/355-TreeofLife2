using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    /// <summary>
    /// This class defines what the boss does while it is moving.
    /// </summary>
    public class BossStateMove : BossState
    {
        /// <summary>
        /// This function updates the boss every frame.
        /// </summary>
        /// <param name="boss"> The boss that this state applies to. </param>
        /// <returns> A new state. </returns>
        public override BossState Update(WhiteBossController boss)
        {
            // switch to idle

            // switch to pursue

            // switch to dead

            return null;
        } // ends the Update() function
    } // ends the BossStateMove class
} // ends the White namespace