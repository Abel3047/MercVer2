using Assets.Scripts.Interface.CardInterfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour,ICard
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected bool PassiveTraitsState { get; set; }
    protected float Cost { get; set; }
    protected int CardId { get; set; }
    protected string CardType { get; set; }//This describes what kind of card it is eg, Item, character, minion 


    public void passiveTraits()
    {
        throw new System.NotImplementedException();
    }
    public void DragAction()
    {
        throw new System.NotImplementedException();
    }
    public void FlipAction()
    {
        throw new System.NotImplementedException();
    }

}
