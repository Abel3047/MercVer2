
using Assets.Scripts.Entities.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface
{
    interface IPersona
    {
        /*
         Here we declare all the traits expected of anything (Anyone) that can be described as a character (For both playable and NPC)

        The reason we did it here instead of just defining it in CharacterPersona is that each class that will implement this interface will have 
        different values of individual properties
         */
        double PowerBuffPercent { get; set; } 
        double EvadeBuffPercent { get; set; } //This is here for aware
        double AgileBUffPercent { get; set; }
        double HealBuffPercent { get; set; }
        double counterAttackPercent { get; set; }
        object ProtectionSponser { get; set; }


        int ExpPoints { get; set; }
        int NewEarnedXp { get; set; }
        bool EarnedXp { get; set; }

        void LevelIncrease();
        void XPIncrease(bool earnXp, int newEarnedXp);

        void TraitLevelUpActivation(int experienceLevel, List<ItemTemplate> Items);

    }
}
