using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {
        /// <summary>
        /// Important Variables
        /// </summary>

        //Health

        public int currentHealth;
        public int maxHealth;
        public int baseHealth;

        //Stamina

        public int currentStamina;
        public int maxStamina;
        public int baseStamina;

        //Magic

        public int currentMana;
        public int maxMana;
        public int baseMana;

        //Experience

        public int currentXp;
        public int levelXp;
        public int baseXp;
        public int level;
        public int upgradePoints;

        //Stats

        public int strength; /*Physical attack and stamina increase modifier*/
        public int vitality; /*Health and defence*/
        public int intelligence; /*magic effectiveness and the mana amount*/
        public int luck; /*hidden stat to increase dodge rate*/

        /// <summary>
        /// Updates the maximum health value we can have.
        /// </summary>
        public void UpdateMaxHealth()
        {
            maxHealth = baseHealth + (level * 10) + (vitality * 100) + (GetArmourVitality() * 20);
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        /// <summary>
        /// The outfit a person wears will have a buff to their health.
        /// </summary>
        /// <returns></returns>
        public int GetArmourVitality()
        {
            return 1;
        }

        /// <summary>
        /// Updates the maximum stamina value of a person.
        /// </summary>
        public void UpdateMaxStamina()
        {
            maxStamina = baseStamina + (level * 10) + (strength * 100) + (GetArmourStrength() * 20);
            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
        }

        /// <summary>
        /// The outfit of a person will have an effect on their stamina.
        /// </summary>
        /// <returns></returns>
        public int GetArmourStrength()
        {
            return 1;
        }

        /// <summary>
        /// What will we need for the next level?
        /// </summary>
        public void UpdateNextXp()
        {
            int baseEffect;
            if (level <= 10)
            {
                baseEffect = baseXp - (level * 10);
            }
            else
            {
                baseEffect = 0;
            }

            levelXp = baseEffect + (level * level * 1000);
        }

        public void levelUp()
        {
            if (currentXp >= levelXp)
            {
                upgradePoints++;
                level++;
                currentXp -= levelXp;
                UpdateNextXp();
                UpdateMaxHealth();
                UpdateMaxStamina();
                UpdateMaxMana();
                currentHealth = maxHealth;
                currentMana = maxMana;
                currentStamina = maxStamina;
                Debug.Log("Level Up Successful! Level: " + level);
            }
        }

        private void UpdateMaxMana()
        {
            maxMana = baseMana + (level * 10) + (intelligence * 100) + (GetArmourMana() * 20);
            if (currentMana > maxMana)
            {
                currentMana = maxMana;
            }
        }

        private int GetArmourMana()
        {
            return 1;
        }
    }
}