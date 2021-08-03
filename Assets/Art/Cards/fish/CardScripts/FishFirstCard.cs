using System.Collections;
using System.Collections.Generic;
using static Assets.Scripts.Entities.Character.Persona;
using UnityEngine;

public class FishFirstCard : CardBehaviour
{
    public FishFirstCard()
    {
        CardBevaTypes.Add(this);
    }
    public override object Character { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public override object Target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public override string spriteNameNO { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public override void CardAction(object CharacterInstance, object TargetInstance)
    {
        throw new System.NotImplementedException();
    }
}
