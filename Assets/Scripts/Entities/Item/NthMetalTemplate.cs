using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities.Item
{
    class NthMetalTemplate : ItemTemplate
    {
        public static NthMetalTemplate Instance { get; set; }
        public NthMetalTemplate()
        {
            Instance = this;
        }
        public override string ItemName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string ItemDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override object Ownertype { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool Relic { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool BeingUsed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #region ItemActions
        public override bool ActivationRequireMent(object CharacterInstance)
        {
            throw new NotImplementedException();
        }

        public override void Equip()
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }

        public override void UniqueActiveBuff()
        {
            throw new NotImplementedException();
        }

        public override void UniqueActiveDeBuff()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
