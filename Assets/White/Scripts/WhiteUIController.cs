using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace White
{
    /// <summary>
    /// This class controls all of the UI used in the level.
    /// </summary>
    public class WhiteUIController : MonoBehaviour
    {
        /// <summary>
        /// Stores the text displaying how many hits the player has left before they
        /// die.
        /// </summary>
        Text playerText;

        /// <summary>
        /// Stores the text displaying how many hits the boss has left before it dies.
        /// </summary>
        Text bossText;

        /// <summary>
        /// The amount of hits the player can take before they die.
        /// </summary>
        public int playerHitsLeft = 3;

        /// <summary>
        /// This function sets up the UI upon starting the level.
        /// </summary>
        void Start()
        {
            playerText = GetComponent<Text>();
            bossText = GetComponent<Text>();

            playerText.text = "Player Hits: " + playerHitsLeft;
            bossText.text = "Boss Hits: " + WhiteBossController.bossHitsLeft;
        } // end the Start() function

        /// <summary>
        /// This function updates the UI to reflect the number of hits the player
        /// and the boss has left before they die.
        /// </summary>
        void Update()
        {

        } // ends the Update() function
    } // ends the WhiteUIController class
} // ends the White namespace