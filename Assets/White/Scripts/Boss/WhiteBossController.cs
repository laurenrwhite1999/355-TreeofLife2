using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    /// <summary>
    /// This class controls the boss's behavior.
    /// </summary>
    public class WhiteBossController : MonoBehaviour
    {
        /// <summary>
        /// The furthest distance away the boss can see the player.
        /// </summary>
        public float visionDistanceThreshold = 10;

        /// <summary>
        /// The furthest distance away the player can be for the boss to
        /// persue.
        /// </summary>
        public float pursueDistanceThreshold = 7;

        /// <summary>
        /// The speed the boss moves.
        /// </summary>
        public float speed = 10;

        /// <summary>
        /// The prefab that is being used as a basic projectile.
        /// </summary>
        public WhiteProjectile prefabProjectile;

        /// <summary>
        /// The prefab that is being used as a homing projectile.
        /// </summary>
        public WhiteProjectileHoming prefabProjectileHoming;

        /// <summary>
        /// The velocity of the boss.
        /// </summary>
        [HideInInspector]
        public Vector3 velocity = new Vector3();

        /// <summary>
        /// The current state that the boss is in.
        /// </summary>
        BossState currentState;

        /// <summary>
        /// The target that the boss will try to attack.
        /// </summary>
        public Transform attackTarget { get; private set; }

        /// <summary>
        /// This function finds the player and sets it as the boss's attack target.
        /// </summary>
        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player != null) attackTarget = player.transform;
        } // ends the Start() function

        /// <summary>
        /// This function updates the boss every frame.
        /// </summary>
        void Update()
        {
            // if there is no current state, set it to idle
            if (currentState == null) SwitchToState(new BossStateIdle());

            // if there is a current state, update the state
            if (currentState != null) SwitchToState(currentState.Update(this));
        } // ends the Update() function

        /// <summary>
        /// This function handles the switching of states.
        /// </summary>
        /// <param name="newState"> The state that the boss will be switching to. </param>
        private void SwitchToState(BossState newState)
        {
            if (newState != null)
            {
                if(currentState != null) currentState.OnEnd(this);
                currentState = newState;
                currentState.OnStart(this);
            } // ends the if statement
        } // ends the SwitchToState() function

        /// <summary>
        /// This function determines the vector from the boss to the attack target.
        /// </summary>
        /// <returns> The vector from the boss to the attack target. </returns>
        public Vector3 VectorToAttackTarget()
        {
            return attackTarget.position - transform.position;
        } // ends the VectorToAttackTarget() function

        /// <summary>
        /// This function determines the magnitude of the vector from the boss to the
        /// attack target.
        /// </summary>
        /// <returns> The magnitude of the vector from the boss to the attack target. </returns>
        public float DistanceToAttackTarget()
        {
            return VectorToAttackTarget().magnitude;
        } // ends the DistanceToAttackTarget() function
        
        /// <summary>
        /// This function determines whether or not the player is being seen by the boss.
        /// </summary>
        /// <returns> Whether or not the boss can see the player. </returns>
        public bool CanSeeAttackTarget()
        {
            if (attackTarget == null) return false;
            Vector3 vectorBetween = VectorToAttackTarget();

            if (vectorBetween.sqrMagnitude < visionDistanceThreshold * visionDistanceThreshold)
            {
                // player is close enough to boss to activate it
                Ray ray = new Ray(transform.position, vectorBetween.normalized);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform == attackTarget) return true;
                } // ends the nested if statement
            } // ends the if statement
            return false;
        } // ends the CanSeeAttackTarget() function

        /// <summary>
        /// This function creates the basic projectiles and tells the boss to shoot them.
        /// </summary>
        public void ShootProjectile()
        {
            WhiteProjectile newProjectile = Instantiate(prefabProjectile, transform.position, Quaternion.identity);

            Vector3 dir = (VectorToAttackTarget() + Random.insideUnitSphere * 5).normalized;
            newProjectile.Shoot(gameObject, dir);
        } // ends the ShootProjectile() function

        /// <summary>
        /// This function creates the homing projectiles and tells the boss to shoot them.
        /// </summary>
        public void ShootHomingProjectile()
        {
            WhiteProjectileHoming newProjectile = Instantiate(prefabProjectileHoming, transform.position, Quaternion.identity);
            newProjectile.Shoot(gameObject, attackTarget, Vector3.up);
        } // ends the ShootHomingProjectile() function
    } // ends the WhiteBossController class
} // ends the White namespace