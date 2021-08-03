using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardBehaviour : Card
{

    public abstract void CardAction();//This is abstract so that each card can have its own version

}
