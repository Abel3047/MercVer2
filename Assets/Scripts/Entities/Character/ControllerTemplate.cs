using Assets.Scripts.Interface.CardInterfaces.ICombatant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Assets.Scripts.Entities.Character
{
    class ControllerTemplate : Persona, IMageWarrior
    {
        new public static ControllerTemplate Instance;
        public ControllerTemplate()
        {
            Instance = this;
        }
        #region Character variables
        public override string CharacterName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BriefDescription { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override int Health
        {
            get { return Health; }
            set
            {
                if (Health < 0) Health = 0;
                if (Foe == false)
                {
                    Health = 68;
                }
                else
                {
                    Health = 10;
                }
            }
        }
        public override int dodge
        {
            get { return dodge; }
            set
            {
                if (Foe == false)
                {
                    dodge = 10;
                }
                else
                {
                    dodge = 5;
                }
                if (dodge < 0) dodge = 0;

            }
        }
        public override int Speed
        {
            get { return Speed; }
            set
            {
                if (Foe == false)
                {
                    Speed = 10;
                }
                else
                {
                    Speed = 6;
                }
                if (Speed < 0) Speed = 0;

            }
        }
        public override double CritC
        {
            get { return CritC; }
            set
            {
                if (Foe == false)
                {
                    CritC = 1;
                }
                else
                {
                    CritC = 0;
                }
                if (CritC < 0) CritC = 0;

            }
        }
        public override int Damage
        {
            get { return Damage; }
            set
            {
                if (Foe == false)
                {
                    if (LowDamage == true)
                    {
                        Damage = 5;
                    }
                    else
                    {
                        Damage = 10;
                    }
                }
                else
                {
                    if (LowDamage == true)
                    {
                        Damage = 1;
                    }
                    else
                    {
                        Damage = 2;
                    }
                }
                if (Damage < 0) Damage = 0;

            }
        }
        public override int Accuracy
        {
            get { return Accuracy; }
            set
            {
                if (Foe == false)
                {
                    Accuracy = 90;
                }
                else
                {
                    Accuracy = 0;
                }
                if (Accuracy < 0) Accuracy = 0;
            }
        }
        public override int MagicRes
        {
            get { return MagicRes; }
            set
            {
                if (Foe == false)
                {
                    MagicRes = 1;
                }
                else
                {
                    MagicRes = 3;
                }
                if (MagicRes < 0) MagicRes = 0;

            }
        }
        public override int Armour
        {
            get { return Armour; }
            set
            {
                if (Foe == false)
                {
                    Armour = 1;
                }
                else
                {
                    Armour = 3;
                }
                if (Armour < 0) Armour = 0;

            }
        }
        public override int shield
        {
            get { return shield; }
            set
            {
                if (Foe == false)
                {
                    shield = 2;
                }
                else
                {
                    shield = 0;
                }
                if (shield < 0) shield = 0;
            }
        }

        /* Mana & Stamina
         public int Mana { get { return Mana; } set { if (DefaultValue == true) { if (Mana > 100) Mana = 100; if (Mana < 0) Mana = 0; } } }
        public int Stamina
        {
            get { return Stamina; }
            set { if (DefaultValue == true) { if (Stamina > 100) Stamina = 100; if (Stamina < 0) Stamina = 0; } }

        }
         */


        public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool Foe { get { return Foe; } set { Foe = false; } }
        public bool PassiveWarriorTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool PassiveMageTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool SupportMage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion
        #region Character Methods

        //Here are the passive traits of the card themselves
        new public void passiveTraits()
        {
            //Instance.EquipItem(HolyCrossItem, Instance); I dont expect this to be used at all here. It would be clled some place else, I wrrote it here to see if it would work
            Instance.ActiveBuff();
        }

        //string CitizenOf = (string)WarriorTemplate.Kingdom.DarkSyde; // Here I was just experimenting to see how the citizenship can be set
        //After We figure out how to set the respective variables to the specific enum value I want to use peter as a reference for other characters so we
        //forget to include the correct and necesary info

        public void ActiveBuff()
        {
            throw new System.NotImplementedException();
        }
        public void ActiveDeBuff()
        {
            throw new System.NotImplementedException();
        }
        //Experince methods
        public override void LevelIncrease()
        {
            Instance.ExperienceLevel++;
            if (Foe == false)
            {
                Instance.Health += 15 * Instance.ExperienceLevel;
                Instance.dodge += 5 * Instance.ExperienceLevel;
                Instance.Speed += 6 * Instance.ExperienceLevel;
                Instance.CritC += 1 * Instance.ExperienceLevel;
                Instance.MagicRes += 1 * Instance.ExperienceLevel;
                Instance.Armour += 1 * Instance.ExperienceLevel;
                Instance.LowDamage = true;
                if (LowDamage == true)
                { Instance.Damage += 3 * Instance.ExperienceLevel; Instance.LowDamage = false; }
                if (LowDamage == false)
                {
                    Instance.Damage += 4 * Instance.ExperienceLevel;
                }
                //fire levelIncrease animation
            }
            else
            {
                Instance.Health += 3;
                Instance.dodge += 5;
                Instance.Speed += 3;
                Instance.CritC += 1;
                if (ExperienceLevel > 3)
                {
                    Instance.MagicRes += 1;
                    Instance.Armour += 1;
                }
                Instance.LowDamage = true;
                if (LowDamage == true)
                { Instance.Damage += 1; Instance.LowDamage = false; }
                if (LowDamage == false)
                {
                    Instance.Damage += 2;
                }
                //fire levelIncrease animation
            }
            //fire levelIncrease animation
        }
        public override int DamageGiven()
        {
            int damageGiven = 0;
            if (Foe == false)
            {
                Random r = new Random();
                damageGiven = r.Next(5, 11);
            }
            else
            {
                Random r = new Random();
                damageGiven = r.Next(1, 3);
            }
            return damageGiven;
        }
        public override int HealthLoss(int damageGiven)
        {
            Instance.Health -= damageGiven;
            return damageGiven;
        }


        #endregion
    }
}
