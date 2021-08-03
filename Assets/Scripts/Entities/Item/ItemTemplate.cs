using Assets.Scripts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Item
{
    public abstract class ItemTemplate : Card
    {
        /*
         Here we declare all the traits expected of anything (Anyone) that can be described as a character (For both playable and NPC)
         */
        //Since it already inherts from cards it has passive traits already declared as well as cost.
        public enum MasterItemList
        {
            //Here a list of every individual item will be defined.Then they will be accessed with their indexes as needed in below lists eg List<>Items
        }

        abstract public string ItemName { get; set; }
        abstract public string ItemDescription { get; set; }//A Brief description of what the item does and what its worth in a desired currency
        abstract public int Owner { get; set; }
        abstract public object Ownertype { get; set; }
        abstract public bool Relic { get; set; } // this will be set true if relic and so will be nonconsumbalable 
        abstract public bool BeingUsed { get; set; }

        abstract public void Equip();
        abstract public void Remove();
        abstract public bool ActivationRequireMent(object CharacterInstance); //Returns if you have all the necessary things to activate the item and if true it equips it

        #region Abilities
        abstract public void UniqueActiveBuff();
        abstract public void UniqueActiveDeBuff();
        #endregion

    }
}
