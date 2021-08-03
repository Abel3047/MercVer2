using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individual : MonoBehaviour
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
    protected int IndividualId { get; set; }
    protected string IndividualType { get; set; }


    public void passiveTraits()
    {
        throw new System.NotImplementedException();
    }
}
