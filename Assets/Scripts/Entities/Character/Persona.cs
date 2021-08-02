using Assets.Scripts.Entities.Item;
using Assets.Scripts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Character
{
    class Persona:Card,IPersona,ICombatAction
    {
        //We aren't making persona abstract cause we need to use it as a template in some logic
        //Anything here thats not virtual will be the same for all characters

        public static Persona Instance;
        public Persona()
        {
            Instance = this;
        }

        #region GivenCharacterTraits

        public enum Kingdom { FarWest, MiddleEarth, DarkSyde };

        public enum MasterCharacterList
        {
            //Here a list of strings of every individual character will be defined.Then they will be accessed with their indexes as needed in below lists eg List<>Allies
            #region Heros
            Peter, Mister_Glubglub, Mister_Froggo, Mister_Salaboned, Mister_Lizzacorn, Mister_Liodin, Mister_Lacrox, Mister_Birbarcher, Mister_PirateParrot,
            Mister_SilverSkull, Mister_Mantis, Mister_Hippo,
            #endregion
            #region Foes
            HammerHead, GreatWhite, SpiderCrustacean, NecroBoar, ElderStag, DevilBird, DragonSloth
            #endregion
        }
        public List<object> Master { get; set; }
        public List<object> Allies { get; set; }
        public List<object> Enemies { get; set; }

        public enum SpeciesType
        {
            Lion,
            Crocodile,
            Fish,
            Salamander,
            Frog,
            Triton
        };
        public static bool RoundOver { get; set; }
        bool RemoveDebuffEffects { get; set; }

        #endregion
        #region Character Traits

        public virtual string CharacterName { get { return CharacterName; } set { CharacterName = "UnKnown"; } }
        public virtual string CharacterDescription { get { return CharacterDescription; } set { CharacterDescription = "UnKnown"; } } //Here the personality and backstory of a unique character will be defined
        public virtual bool Foe { get { return Foe; } set { Foe = false; } }
        public virtual int Health 
        {
            get { return Health; }
            set
            {
                if (Health < 0) Health = 0;
                if (Foe == false)
                {
                    Health = 0;
                }
                else
                {
                    Health = 0;
                }
            }
        }
        public virtual int dodge
        {
            get { return dodge; }
            set
            {
                if (Foe == false)
                {
                    dodge = 0;
                }
                else
                {
                    dodge = 0;
                }
                if (dodge < 0) dodge = 0;

            }
        }
        public virtual int Speed
        {
            get { return Speed; }
            set
            {
                if (Foe == false)
                {
                    Speed = 0;
                }
                else
                {
                    Speed = 0;
                }
                if (Speed < 0) Speed = 0;

            }
        }
        public virtual double CritC
        {
            get { return CritC; }
            set
            {
                if (Foe == false)
                {
                    CritC = 0;
                }
                else
                {
                    CritC = 0;
                }
                if (CritC < 0) CritC = 0;

            }
        }
        public virtual int MagicRes
        {
            get { return MagicRes; }
            set
            {
                if (Foe == false)
                {
                    MagicRes = 0;
                }
                else
                {
                    MagicRes = 0;
                }
                if (MagicRes < 0) MagicRes = 0;

            }
        }
        public virtual int Armour
        {
            get { return Armour; }
            set
            {
                if (Foe == false)
                {
                    Armour = 0;
                }
                else
                {
                    Armour = 0;
                }
                if (Armour < 0) Armour = 0;

            }
        }
        public virtual int shield
        {
            get { return shield; }
            set
            {
                if (Foe == false)
                {
                    shield = 0;
                }
                else
                {
                    shield = 0;
                }
                if (shield < 0) shield = 0;
            }
        }
        public virtual int Damage { get; set; }
        public virtual int HitCount { get; set; }
        public virtual int Accuracy { get; set; }
        public bool LowDamage { get; set; }

        /*
          int Mana
        {
            get; set;
            // We never discussed if Mana was going to be used so I just put it cause, I mean RPG right, we have to nerf the characters somehow right.
            //Pluss in my head the cards that a character will be able to use from the many cards on deck will be dependant on the amount of mana the individual 
            //character has currently
        }
        int Stamina { get; set; }//I assume the hunger method will affect this trait
         */
        //Above is the mana and stamina int


        public double PowerBuffPercent { get; set; }
        public double EvadeBuffPercent { get; set; }
        public double AgileBUffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double HealBuffPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double counterAttackPercent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object ProtectionSponser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int ExpPoints
        {
            get { return ExpPoints; }
            set
            {
                if (RoundOver == true/*This means characters can level up durning battle*/)
                {
                    Instance.ExpPoints += NewEarnedXp;
                }
                if (Instance.ExpPoints > 1000)
                {
                    Instance.LevelIncrease();
                    Instance.ExpPoints -= 1000;
                }
            }
        }
        public int NewEarnedXp
        {
            get { return NewEarnedXp; }
            set
            {
                if (NewEarnedXp < 0) NewEarnedXp = 0;
                if (EarnedXp == true)
                {
                    Instance.NewEarnedXp = NewEarnedXp;
                }
                else
                {
                    Instance.NewEarnedXp = 0;
                }
            }
        }
        public bool EarnedXp
        {
            get { return EarnedXp; }
            set
            {
                if (RoundOver == false/*This means characters can level up durning battle*/)
                {
                    EarnedXp = false;
                }
            }
        } //This bool is made true when XPIncrease is fired and should be made of when sessionOver is true
        internal int ExperienceLevel { get { return ExperienceLevel; } set { if (ExperienceLevel < 0) ExperienceLevel = 0; } }

        #endregion
        #region Character Methods

        public virtual int DamageGiven(object CharacterInstance)
        {
            int damageGiven = 0;
            if (Foe == false)
            {
                Random r = new Random();
                damageGiven = r.Next(0, 0);
            }
            else
            {
                Random r = new Random();
                damageGiven = r.Next(0, 0);
            }
            return damageGiven;
        }
        public virtual int HealthLoss(int damageGiven)
        {
            Instance.Health -= damageGiven;
            return damageGiven;
        }
        public virtual void LevelIncrease()
        {
            Instance.ExperienceLevel++;
            if (Foe == false)
            {
                Instance.Health += 0 * Instance.ExperienceLevel;
                Instance.dodge += 0 * Instance.ExperienceLevel;
                Instance.Speed += 0 * Instance.ExperienceLevel;
                Instance.CritC += 0 * Instance.ExperienceLevel;
                Instance.MagicRes += 0 * Instance.ExperienceLevel;
                Instance.Armour += 0 * Instance.ExperienceLevel;
                if (LowDamage == true) Instance.Damage += 0 * Instance.ExperienceLevel;
                else
                {
                    Instance.Damage += 2 * Instance.ExperienceLevel;
                }
            }
            else
            {
                Instance.Health += 0 * Instance.ExperienceLevel;
                Instance.dodge += 0 * Instance.ExperienceLevel;
                Instance.Speed += 0 * Instance.ExperienceLevel;
                Instance.CritC += 0 * Instance.ExperienceLevel;
                Instance.MagicRes += 0;
                Instance.Armour += 0;
                if (LowDamage == true) Instance.Damage += 1 * Instance.ExperienceLevel;
                else
                {
                    Instance.Damage += 0 * Instance.ExperienceLevel;
                }
            }
            //fire levelIncrease animation
        }

        public void TraitLevelUpActivation(int experienceLevel, List<ItemTemplate> Items)
        {
            throw new NotImplementedException();
        }

        public void XPIncrease(bool earnXp, int newEarnedXp)
        {
            EarnedXp = earnXp;
            NewEarnedXp = newEarnedXp;
        }


        #endregion
        #region Combat Actions

        #region Attack

        public object TrueDamage(object CharacterInstance, object TargetInstance)
        {
            object DamageObject = 0;
            return DamageObject;
        }

        public void PhysicalDamage(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void MagicalDamage(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void Drain(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void Ignite(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void Bleed(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void Blight(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void BalancedDamage(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void Curse(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Feign(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Defend

        public void PutArmour(object CharacterInstance, bool state, int amount)
        {
            throw new NotImplementedException();
        }

        public void IncreaseMagicalResistance(object CharacterInstance, bool state, int amount)
        {
            throw new NotImplementedException();
        }

        public void ShieldUp(object CharacterInstance, bool state, int amount)
        {
            throw new NotImplementedException();
        }

        public void Purified(object CharacterInstance, bool state)
        {
            throw new NotImplementedException();
        }

        public void Block(object CharacterInstance, bool state)
        {
            throw new NotImplementedException();
        }
        public void Immune(object CharacterInstance, bool state)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Buff

        public void Agile(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public bool PolishWeapon()
        {
            throw new NotImplementedException();
        }

        public bool Chosen()
        {
            throw new NotImplementedException();
        }

        public bool Aware()
        {
            throw new NotImplementedException();
        }

        public void OnGuard(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void Provoking(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public void Protector(object OwnerInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public object Protected(object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void Revigorate(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void HealVictim(object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void GodsBlessing(object CharacterInstance, List<string> Allies)
        {
            throw new NotImplementedException();
        }

        public bool Slow(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Debuff

        public bool Rooted(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool WeakGrip(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Exiled(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Marked(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Calm(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool BrokenGuard(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Burnt(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Stun(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Freeze(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Cold(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Blinded(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Tainted(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Sleep(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Hungry(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool Unhealthy(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public bool GodsAnger(object CharacterInstance, List<string> Allies)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region UniqueActons
        public void UniqueSkill(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void UniqueActiveBuff(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        public void UniqueActiveDeBuff(object CharacterInstance, object TargetInstance)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion


    }
}
