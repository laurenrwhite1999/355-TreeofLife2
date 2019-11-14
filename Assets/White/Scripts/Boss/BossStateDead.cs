using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    /// <summary>
    /// This class defines the boss's behavior when it dies.
    /// </summary>
    public class BossStateDead : BossState
    {
        /// <summary>
        /// This function updates the boss on every frame.
        /// </summary>
        /// <param name="boss"> The boss that this state applies to. </param>
        /// <returns> This state. </returns>
        public override BossState Update(WhiteBossController boss)
        {
            // destroy the boss
            return null;
        } // ends the Update() function
    } // ends the BossStateDead class
} // ends the White namespace