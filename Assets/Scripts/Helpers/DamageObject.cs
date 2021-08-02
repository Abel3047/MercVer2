using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    public class DamageObject
    {

        public enum DamageVersion
        {
            True,Physical,Magical,Balanced
        }
        public int DamageValue;
        public object DamageTrait;
    }
}
