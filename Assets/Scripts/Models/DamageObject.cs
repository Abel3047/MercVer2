using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class DamageObject
    {

        public enum DamageVersion
        {
            True,Physical,Magical,Balanced
        }
        public int DamageValue { get { return DamageValue;} set { DamageValue = 0; if (DamageValue < 0) DamageValue = 0; } }
        public object DamageTrait;
    }
}
