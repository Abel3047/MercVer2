using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interface.CardInterfaces.ICombatant
{
    interface IWarriorTraits
    {
        string BriefDescription { get; set; }
        List<string> NaturalAllies { get; set; }
        List<string> NaturalEnemies { get; set; }
        bool PassiveWarriorTraits { get; set; }

        #region PassiveWarriorTraits
        void ActiveBuff();
        void ActiveDeBuff();
        #endregion
    }
}
