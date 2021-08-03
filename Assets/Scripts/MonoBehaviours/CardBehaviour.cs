using System.Collections;
using System.Collections.Generic;
using static Assets.Scripts.Entities.Character.Persona;
using UnityEngine;
using System.Threading.Tasks;

public abstract class CardBehaviour : Card
{
    public abstract object Character { get; set; }
    public abstract object Target { get; set; }

    public static List<CardBehaviour> CardBevaTypes;
    public static string spriteNameNO { get; set; }

    public void OnMouseDown()
    {
        //here should be an event that waits for the target instance to come through. And when it does thats when Card Action fires
        /*
         async void WaitForInstances()
        {
            Task<List<object>> task = GetInstances(CharacterInstance, TargetInstance);
            await task;
            CardAction(Character, Target);
        }
         */

    }
    public abstract void CardAction(object CharacterInstance, object TargetInstance);//This is abstract so that each card can have its own version

    List<object> GetInstances(object CharacterInstance, object TargetInstance)
    {
        Character = CharacterInstance; 
        Target = TargetInstance;
        List<object> TwoInstances=null;
        TwoInstances.Add(Character);
        TwoInstances.Add(Target);
        return TwoInstances;
    }
    string getspriteName()
    {
        return spriteNameNO;
    }

}
