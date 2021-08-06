using System.Collections;
using System.Collections.Generic;
using static Assets.Scripts.Entities.Character.Persona;
using UnityEngine;
using System.Threading.Tasks;
using static Assets.Scripts.Models.Enums;
using Assets.Scripts.MonoBehaviours;
using Assets.Scripts.Entities.Character;
using System.Timers;
using Assets.Scripts.Models;

public class CardBehaviour : Card
{
    public SpeciesType species;
    public cardName cardname;

    //Create Card Interact with Target Script
    //Shouldn't we get cardname to equal to the sprite name?
    public void OnAction(object TargetInstance)
    {

        Persona CharacterInstance = null;
        Persona Target = (Persona)TargetInstance;
        DamageObject damageObject = new DamageObject();
        if (GameManager.Instance.activeCharacter.person != null) CharacterInstance = GameManager.Instance.activeCharacter.person;

        switch (cardname)
        {
            case cardName.lionFirstCard:
                break;
            case cardName.lionSecondCard:
                break;
            case cardName.lionThirdCard:
                break;
            case cardName.lionFourthCard:
                break;
            case cardName.lionFifthCard:
                break;
            case cardName.lionSixthCard:
                break;
            case cardName.lionSeventhCard:
                break;
            case cardName.lionEighthCard:
                break;
            case cardName.lionNinthCard:
                break;
            case cardName.crocodileFirstCard:
                CharacterInstance.TrueDamage(Target, damageObject);
                break;
            case cardName.crocodileSecondCard:
                int enemyindexCount = CharacterInstance.Enemies.Count;
                damageObject.DamageValue = CharacterInstance.DamageGiven();
                int tea = Random.Range(1, enemyindexCount);
                int butter = Random.Range(1, enemyindexCount);
                Persona first = (Persona)CharacterInstance.Enemies[tea];
                Persona second = (Persona)CharacterInstance.Enemies[butter];
                CharacterInstance.TrueDamage(Target, damageObject);
                damageObject.DamageValue = CharacterInstance.DamageGiven();
                CharacterInstance.TrueDamage(Target, damageObject);
                break;
            case cardName.crocodileThirdCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                CharacterInstance.BreakArmour(Target, (int)(Target.Armour* 0.5));
                break;
            case cardName.crocodileFourthCard:
                break;
            case cardName.crocodileFifthCard:
                int ver = Target.Health;
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                int beryt = ver - Target.Health;
                if (beryt > 0) CharacterInstance.Health += beryt;
                break;
            case cardName.crocodileSixthCard:
                CharacterInstance.Bleed(CharacterInstance, Target);
                break;
            case cardName.crocodileSeventhCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                if(Target.Health==0)
                {
                    int enemyindexCount2 = CharacterInstance.Enemies.Count;
                    int bread = Random.Range(1, enemyindexCount2);
                    CharacterInstance.Bleed(CharacterInstance, CharacterInstance.Enemies[bread]);
                }
                break;
            case cardName.crocodileEighthCard:
                break;
            case cardName.crocodileNinthCard:
                CharacterInstance.Speed += CharacterInstance.Speed;
                break;
            case cardName.fishFirstCard:
                break;
            case cardName.fishSecondCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                break;
            case cardName.fishThirdCard:
                if (Target.Health<(CharacterInstance.Health*0.85))
                {
                    int stored = Target.Health;
                    CharacterInstance.PhysicalDamage(CharacterInstance, TargetInstance);
                    int final = (stored - Target.Health); if (final <=0) final = 0;
                    CharacterInstance.Health += 2 * final;
                }
                break;
            case cardName.fishFourthCard:
                CharacterInstance.PolishWeapon();
                if (CharacterInstance.Health == 100) CharacterInstance.BreakArmour(Target, 20);
                break;
            case cardName.fishFifthCard:
                break;
            case cardName.fishSixthCard:
                if(Target.Health==100)
                {
                    CharacterInstance.PhysicalDamage(CharacterInstance, TargetInstance);
                    CharacterInstance.PhysicalDamage(CharacterInstance, TargetInstance);
                }
                if(Target.Health<50)
                {
                    CharacterInstance.Weakg = true;
                    CharacterInstance.WeakGripDeBuffPercent = 0.5;
                    CharacterInstance.PhysicalDamage(CharacterInstance, TargetInstance);
                    CharacterInstance.Weakg = false; CharacterInstance.WeakGripDeBuffPercent = 0;
                }
                break;
            case cardName.fishSeventhCard:
                break;
            case cardName.fishEighthCard:
                CharacterInstance.AgileBUffPercent = 0.2; CharacterInstance.Agile(CharacterInstance);
                break;
            case cardName.fishNinthCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                float egg=Random.Range(1, 101);
                if(egg>=50) CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                break;
            case cardName.salamanderFirstCard:
                break;
            case cardName.salamanderSecondCard:
                break;
            case cardName.salamanderThirdCard:
                break;
            case cardName.salamanderFourthCard:
                break;
            case cardName.salamanderFifthCard:
                break;
            case cardName.salamanderSixthCard:
                break;
            case cardName.salamanderSeventhCard:
                break;
            case cardName.salamanderEighthCard:
                break;
            case cardName.salamanderNinthCard:
                break;
            case cardName.frogFirstCard:
                float bacon = Random.Range(1, 101);
                if (bacon >= 50) CharacterInstance.ProtectionSponser = Target;
                break;
            case cardName.frogSecondCard:
                CharacterInstance.AgileBUffPercent = 0.5;
                Target.AgileBUffPercent = 0.5;
                CharacterInstance.Agile(CharacterInstance);Target.Agile(Target);
                break;
            case cardName.frogThirdCard:
                int stored1 = Target.Health;
                int final1 = 0;
                Timer myTimer2;
                myTimer2 = new Timer();
                // Tell the timer what to do when it elapses
                myTimer2.Elapsed += new ElapsedEventHandler(myEvent);
                // Set it to go off every one seconds
                myTimer2.Interval = 1000;
                // And start it        
                myTimer2.Enabled = true;

                //this is supposed to add to a list up to 5, of the last person to cause you damage. Its called in the constructor and hopefully runs the whole time. 

                void myEvent(object source2, ElapsedEventArgs e)
                {
                    if (final1 == 0)
                    {
                        if (Target.Health <= stored1)
                        {
                            final1 = (stored1 - Target.Health);
                            CharacterInstance.HealBuffPercent = (double)0.2 * final1;
                            CharacterInstance.HealVictim(Target);
                            stored1 = Target.Health;
                        }
                    }
                }
                break;
            case cardName.frogFourthCard:
                CharacterInstance.Blight(CharacterInstance, TargetInstance, CharacterInstance.DamageGiven()); //has to be discussed with yewo
                break;
            case cardName.frogFifthCard:
                object firstgrudge = CharacterInstance.RevengeDa.IndexOf(3);
                object Secondgrudge = CharacterInstance.RevengeDa.IndexOf(4);
                CharacterInstance.Stun(CharacterInstance, firstgrudge); CharacterInstance.MagicalDamage(CharacterInstance, firstgrudge,CharacterInstance.DamageGiven());
                CharacterInstance.Stun(CharacterInstance, Secondgrudge); CharacterInstance.MagicalDamage(CharacterInstance, Secondgrudge, CharacterInstance.DamageGiven());
                break;
            case cardName.frogSixthCard:
                break;
            case cardName.frogSeventhCard:
                object fgrudge = CharacterInstance.RevengeDa.IndexOf(0);
                object Sgrudge = CharacterInstance.RevengeDa.IndexOf(1);
                CharacterInstance.Stun(CharacterInstance, fgrudge);
                CharacterInstance.Stun(CharacterInstance, Sgrudge);
                CharacterInstance.PutArmour(CharacterInstance, (int)(CharacterInstance.Armour * 0.1));
                break;
            case cardName.frogEighthCard:
                break;
            case cardName.frogNinthCard:
                int totalEnemyHealth = 0;
                int indienemyhealth;
                int count = 0;
                Persona lowestenemy = new();
                foreach (var item in CharacterInstance.Enemies)
                {
                    Persona enemy= (Persona)item;
                    indienemyhealth = enemy.Health;
                    if(count==0)lowestenemy = enemy;  count++;
                    if (indienemyhealth < lowestenemy.Health) lowestenemy = enemy;
                    totalEnemyHealth += enemy.Health;
                }
                totalEnemyHealth = (int)(totalEnemyHealth * 0.1);
                CharacterInstance.Blight(CharacterInstance, lowestenemy, totalEnemyHealth);
                break;
            case cardName.tritonFirstCard:
                break;
            case cardName.tritonSecondCard:
                break;
            case cardName.tritonThirdCard:
                break;
            case cardName.tritonFourthCard:
                break;
            case cardName.tritonFifthCard:
                break;
            case cardName.tritonSixthCard:
                break;
            case cardName.tritonSeventhCard:
                break;
            case cardName.tritonEighthCard:
                break;
            case cardName.tritonNinthCard:
                break;
            default:
                break;
        }
    }

}
