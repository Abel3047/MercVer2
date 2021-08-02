using Assets.Scripts.Interface.CardInterfaces.ICombatant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Character
{
    class TankWarriorTemplate:Persona, IWarriorTraits
    {
        new public static TankWarriorTemplate Instance;
        public TankWarriorTemplate()
        {
            Instance = this;
        }

        #region Character variables
        public override string CharacterName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string CharacterDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BriefDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int Health
        {
            get { return Health; }
            set
            {
                if (Health < 0) Health = 0;
                if (Foe == false)
                {
                    Health = 120;
                }
                else
                {
                    Health = 25;
                }
            }
        }
        public override int dodge
        {
            get { return dodge; }
            set
            {
                if (dodge < 0) dodge = 0;
                if (Foe == false)
                {
                    dodge = 1;
                }
                else
                {
                    dodge = 0;
                }
            }
        }
        public override int Speed
        {
            get { return Speed; }
            set
            {
                if (Speed < 0) Speed = 0;
                if (Foe == false)
                {
                    Speed = 1;
                }
                else
                {
                    Speed = 1;
                }
            }
        }
        public override double CritC
        {
            get { return CritC; }
            set
            {
                if (CritC < 0) CritC = 0;
                if (Foe == false)
                {
                    CritC = 3;
                }
                else
                {
                    CritC = 1;
                }
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
                        Damage = 8;
                    }
                    else
                    {
                        Damage = 13;
                    }
                }
                else
                {
                    if (LowDamage == true)
                    {
                        Damage = 2;
                    }
                    else
                    {
                        Damage = 4;
                    }
                }

            }
        }
        public override int Accuracy
        {
            get { return Accuracy; }
            set
            {
                if (Foe == false)
                {
                    Accuracy = 80;
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
                    MagicRes = 5;
                }
                else
                {
                    MagicRes = 5;
                }
            }
        }
        public override int Armour
        {
            get { return Armour; }
            set
            {
                if (Foe == false)
                {
                    Armour = 3;
                }
                else
                {
                    Armour = 5;
                }
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

        
        public List<string> NaturalAllies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> NaturalEnemies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool PassiveTankTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int HitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool PassiveWarriorTraits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        #endregion
        #region Character Methods

        public void ActiveBuff()
        {
            #region Passive option 1 Tank

            /*
             Passive 1 - each 1% of health lost, you gain 2% more armor and magic resistance

            int percentageHealthLoss =(Instance.HealthLoss(TankWarriorTemplate.Instance.DamageGiven(TankWarriorTemplate.Instance))/ Health);
            //This line above doesn't make sense. damageGiven needs to be passed through ActiveBuff for it to work. We cant use the above parameter in HealthLoss it has to be something past into the activeBuff()
            int CacheArmour = 0;
            int CacheMagicalresistance = 0;
            for (int per = 0; per < percentageHealthLoss; per++)
            {
                Instance.Armour += (int)(Instance.Armour * 0.02);
                CacheArmour += (int)(Instance.Armour * 0.02);
                Instance.MagicRes += (int)(Instance.MagicRes * 0.02);
                CacheMagicalresistance += (int)(Instance.MagicRes * 0.02);
            }
            if (GameOver==true)
            {
                Instance.Armour -= CacheArmour;
                Instance.MagicRes -= CacheMagicalresistance;
                CacheArmour = 0;
                CacheMagicalresistance = 0;
            }

            */

            #endregion
        }
        public void ActiveDeBuff()
        {
            throw new NotImplementedException();
        }
        public override void LevelIncrease()
        {
            Instance.ExperienceLevel++;
            if (Foe == false)
            {

                Instance.Health += 40 * Instance.ExperienceLevel;
                Instance.dodge += 1 * Instance.ExperienceLevel;
                Instance.Speed += 1 * Instance.ExperienceLevel;
                Instance.CritC += 1 * Instance.ExperienceLevel;
                Instance.MagicRes += 1 * Instance.ExperienceLevel;
                Instance.Armour += 2 * Instance.ExperienceLevel;
                Instance.LowDamage = true;
                if (LowDamage == true)
                { Instance.Damage += 2 * Instance.ExperienceLevel; Instance.LowDamage = false; }
                else
                {
                    Instance.Damage += 2 * Instance.ExperienceLevel;
                }
            }
            else
            {
                Instance.Health += 8 * Instance.ExperienceLevel;
                Instance.dodge += 0 * Instance.ExperienceLevel;
                Instance.Speed += 1 * Instance.ExperienceLevel;
                Instance.CritC += 1 * Instance.ExperienceLevel;
                Instance.MagicRes += 1 * Instance.ExperienceLevel;
                Instance.Armour += 2 * Instance.ExperienceLevel;
                Instance.LowDamage = true;
                if (LowDamage == true)
                { Instance.Damage += 1 * Instance.ExperienceLevel; Instance.LowDamage = false; }
                else
                {
                    Instance.Damage += 1 * Instance.ExperienceLevel;
                }
            }
            //fire levelIncrease animation
        }
        public override int DamageGiven()
        {
            int damageGiven = 0;
            if (Foe == false)
            {
                Random r = new Random();
                damageGiven = r.Next(8, 14);
            }
            else
            {
                Random r = new Random();
                damageGiven = r.Next(2, 5);
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
