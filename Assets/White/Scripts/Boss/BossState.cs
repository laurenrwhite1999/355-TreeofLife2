using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    /// <summary>
    /// This class is an abstract class that all of the other state classes pull from.
    /// </summary>
    public abstract class BossState
    {
        /// <summary>
        /// This function updates the boss on every frame.
        /// </summary>
        /// <param name="boss"> The boss that the state applies to. </param>
        /// <returns> A new scene. </returns>
        public abstract BossState Update(WhiteBossController boss);

        /// <summary>
        /// This function defines what happens upon the state's start.
        /// </summary>
        /// <param name="boss"> The boss that the state applies to. </param>
        public virtual void OnStart(WhiteBossController boss)
        {

        } // ends the OnStart() function

        /// <summary>
        /// This function defines what happens upon the state's end.
        /// </summary>
        /// <param name="boss"> The boss that the state applies to. </param>
        public virtual void OnEnd(WhiteBossController boss)
        {

        } // ends the OnEnd() function
    } // ends the BossState class
} // ends the White namespace