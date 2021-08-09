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
using System;

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
                int lionBalls = Target.Health;
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                if (Target.Health < lionBalls) lionBalls -= Target.Health;
                CharacterInstance.ShieldUp(CharacterInstance, (int)(lionBalls * 0.3));
                foreach (var item in CharacterInstance.Allies)
                {
                    CharacterInstance.ShieldUp(item, (int)(lionBalls * 0.05));
                }
                break;
            case cardName.lionSecondCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target); CharacterInstance.PowerBuffPercent = 0.3;
                CharacterInstance.PolishWeapon();
                break;
            case cardName.lionThirdCard:
                int lionBalls2 = Target.Health;
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                if (Target.Health < lionBalls2) lionBalls2 -= Target.Health;
                CharacterInstance.MagicRes += (int)(lionBalls2 * 0.1); CharacterInstance.Armour+= (int)(lionBalls2 * 0.1);
                break;
            case cardName.lionFourthCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                bool done = false; int heaCache=0; int dog=0; int spit = 0; int crrr = 0; int Maga = 0; int Love = 0; int bass = 0; int acc = 0;

                Timer Nexttime;
                Nexttime = new Timer();
                // Tell the timer what to do when it elapses
                Nexttime.Elapsed += new ElapsedEventHandler(totaldramaIsland);
                // Set it to go off every one seconds
                Nexttime.Interval = 1000;
                // And start it        
                Nexttime.Enabled = true;
                foreach (var item in CharacterInstance.Allies)
                {
                    Persona fried = (Persona)item;
                    heaCache = (int)(fried.Health * 0.05); fried.Health += heaCache;
                    fried.dodge += dog=(int)(fried.dodge * 0.05);
                    fried.Speed += spit=(int)(fried.Speed * 0.05);
                    fried.CritC += crrr=(int)(fried.CritC * 0.05);
                    fried.MagicRes += Maga=(int)(fried.MagicRes * 0.05);
                    fried.Armour += Love=(int)(fried.Armour * 0.05);
                    fried.shield += bass=(int)(fried.shield * 0.05);
                    fried.Accuracy += acc=(int)(fried.Accuracy * 0.05);
                }
                void totaldramaIsland(object source2, ElapsedEventArgs e)
                {
                    if (RoundInfo.RoundDone == true)
                    { done = true;  Nexttime.Close(); }
                    if(done==true)
                    {
                        foreach (var item in CharacterInstance.Allies)
                        {
                            Persona fried = (Persona)item;
                            fried.Health -= heaCache;
                            fried.dodge -= dog;
                            fried.Speed -= spit;
                            fried.CritC -= crrr;
                            fried.MagicRes -= Maga;
                            fried.Armour -= Love;
                            fried.shield -= bass;
                            fried.Accuracy -= acc;
                        }
                    }
                }
                break;
            case cardName.lionFifthCard:
                break;
            case cardName.lionSixthCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                int stunnedNumber = 0;
                if ((Target.Health / CharacterInstance.Health) < 0.80) CharacterInstance.Stun(CharacterInstance, Target);
                if((Target.Health / CharacterInstance.Health) < 0.5)
                {
                    foreach (var item in CharacterInstance.Enemies)
                    {
                        CharacterInstance.Stun(CharacterInstance, item);
                        if (true/*Item.stunned==true*/) stunnedNumber++; //we dont know if the person is stunned or not
                    }
                    CharacterInstance.shield += (int)(CharacterInstance.shield * 0.1 * stunnedNumber);
                }
                break;
            case cardName.lionSeventhCard:
                int heaCache2 = 0; int dog2 = 0; int spit2= 0; int crrr2 = 0; int Maga2 = 0; int Lov2e = 0; int bass2 = 0; int acc2 = 0;
                foreach (var item in CharacterInstance.Enemies)
                {
                    Persona fried = (Persona)item;
                    fried.Health -= heaCache2= (int)(fried.Health * 0.05);
                    fried.dodge -= dog2 = (int)(fried.dodge * 0.05);
                    fried.Speed -= spit2 = (int)(fried.Speed * 0.05);
                    fried.CritC -= crrr2 = (int)(fried.CritC * 0.05);
                    fried.MagicRes -= Maga2 = (int)(fried.MagicRes * 0.05);
                    fried.Armour -= Lov2e = (int)(fried.Armour * 0.05);
                    fried.shield -= bass2 = (int)(fried.shield * 0.05);
                    fried.Accuracy -= acc2 = (int)(fried.Accuracy * 0.05);
                    CharacterInstance.PowerBuffPercent = 0.1;
                    CharacterInstance.PolishWeapon();
                }
                break;
            case cardName.lionEighthCard:
                break;
            case cardName.lionNinthCard:
                break;
            case cardName.crocodileFirstCard:
                int ver = Target.Health;
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                int beryt = ver - Target.Health;
                if (beryt > 0) CharacterInstance.Health += beryt;
                break;
            case cardName.crocodileSecondCard:
                int enemyindexCount = CharacterInstance.Enemies.Count;
                damageObject.DamageValue = CharacterInstance.DamageGiven();
                int tea = UnityEngine.Random.Range(1, enemyindexCount);
                int butter = UnityEngine.Random.Range(1, enemyindexCount);
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
                damageObject.DamageValue = CharacterInstance.DamageGiven();
                CharacterInstance.TrueDamage(Target, damageObject);
                break;
            case cardName.crocodileFifthCard:
                
                break;
            case cardName.crocodileSixthCard:
                CharacterInstance.Bleed(CharacterInstance, Target);
                break;
            case cardName.crocodileSeventhCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                if(Target.Health==0)
                {
                    int enemyindexCount2 = CharacterInstance.Enemies.Count;
                    int bread = UnityEngine.Random.Range(1, enemyindexCount2);
                    CharacterInstance.Bleed(CharacterInstance, CharacterInstance.Enemies[bread]);
                }
                break;
            case cardName.crocodileEighthCard:
                damageObject.DamageValue = (int)(CharacterInstance.DamageGiven() * 0.4);
                int heCache = 0;
                foreach (var item in CharacterInstance.Enemies)
                {
                    CharacterInstance.TrueDamage(item, damageObject);
                    heCache += damageObject.DamageValue;
                }
                CharacterInstance.Health += heCache;
                break;
            case cardName.crocodileNinthCard:
                CharacterInstance.Speed += CharacterInstance.Speed;
                if(RoundInfo.RoundDone==true) CharacterInstance.Speed -= CharacterInstance.Speed;
                break;
            case cardName.fishFirstCard:
                break;
            case cardName.fishSecondCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                break;
            case cardName.fishThirdCard:
                if ((Target.Health/ CharacterInstance.Health) <=0.85)
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
                    int guut= CharacterInstance.DamageGiven()/2;
                    damageObject.DamageValue = guut;
                    CharacterInstance.PhysicalDamage(CharacterInstance, TargetInstance, damageObject);
                }
                break;
            case cardName.fishSeventhCard:
                break;
            case cardName.fishEighthCard:
                CharacterInstance.AgileBUffPercent = 0.2; CharacterInstance.Agile(CharacterInstance);
                break;
            case cardName.fishNinthCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                float egg= UnityEngine.Random.Range(1, 101);
                if(egg>=50) CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                break;
            case cardName.salamanderFirstCard:
                break;
            case cardName.salamanderSecondCard:

                break;
            case cardName.salamanderThirdCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                CharacterInstance.PowerBuffPercent = 0.3;
                CharacterInstance.PolishWeapon();
                break;
            case cardName.salamanderFourthCard:
                int enemyindexCount3 = CharacterInstance.Enemies.Count;
                int breadTRA = UnityEngine.Random.Range(1, enemyindexCount3); int cond = UnityEngine.Random.Range(1, enemyindexCount3);
                object fiaas = CharacterInstance.Enemies[breadTRA];
                object aallss = CharacterInstance.Enemies[cond];
                CharacterInstance.PhysicalDamage(CharacterInstance, fiaas); CharacterInstance.WeakGrip(CharacterInstance, fiaas);
                CharacterInstance.PhysicalDamage(CharacterInstance, aallss); CharacterInstance.WeakGrip(CharacterInstance, aallss);
                WarriorTemplate reee = new();
                CharacterInstance.Health -= (int)(reee.Health * 0.5); //cause apparently it costs 5% of the max health which i assume is the health of a warrior
                break;
            case cardName.salamanderFifthCard:
                break;
            case cardName.salamanderSixthCard:
                break;
            case cardName.salamanderSeventhCard:
                int roundcount = RoundInfo.RoundsPassed;

                Timer my;
                my = new Timer();
                // Tell the timer what to do when it elapses
                my.Elapsed += new ElapsedEventHandler(myEvent12);
                // Set it to go off every one seconds
                my.Interval = 1000;
                // And start it        
                my.Enabled = true;
               
                void myEvent12(object source2, ElapsedEventArgs e)
                {
                    if (RoundInfo.RoundsPassed ==roundcount+1)
                    {
                        CharacterInstance.Health -= (int)(CharacterInstance.Health * 0.1);
                        CharacterInstance.Armour += (int)(CharacterInstance.Armour * 0.1) * 2;
                    }
                    if (RoundInfo.RoundsPassed == roundcount + 2)
                    {
                        CharacterInstance.Health -= (int)(CharacterInstance.Health * 0.1);
                        CharacterInstance.Armour += (int)(CharacterInstance.Armour * 0.1) * 2;
                        my.Close();
                    }
                }
                break;
            case cardName.salamanderEighthCard:
                break;
            case cardName.salamanderNinthCard:
                damageObject.DamageValue = CharacterInstance.DamageGiven() / 2;
                int eCount3 = CharacterInstance.Enemies.Count;
                int digaoogaoo = UnityEngine.Random.Range(1, eCount3); int diguyy = UnityEngine.Random.Range(1, eCount3); //random index of the enemy
                Persona firthealth = (Persona)CharacterInstance.Enemies[digaoogaoo]; Persona sechealths= (Persona)CharacterInstance.Enemies[diguyy];
                CharacterInstance.PhysicalDamage(CharacterInstance, firthealth, damageObject); CharacterInstance.PhysicalDamage(CharacterInstance, sechealths, damageObject);
                CharacterInstance.WeakGrip(CharacterInstance, firthealth); CharacterInstance.WeakGrip(CharacterInstance, sechealths);
                break;
            case cardName.frogFirstCard:
                float bacon = UnityEngine.Random.Range(1, 101);
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
                            myTimer2.Close();
                        }
                    }
                }
                break;
            case cardName.frogFourthCard:
                CharacterInstance.Blight(CharacterInstance, TargetInstance, 4, CharacterInstance.DamageGiven());
                break;
            case cardName.frogFifthCard:
                object firstgrudge = CharacterInstance.RevengeDa.IndexOf(3);
                object Secondgrudge = CharacterInstance.RevengeDa.IndexOf(4);
                CharacterInstance.Stun(CharacterInstance, firstgrudge); CharacterInstance.MagicalDamage(CharacterInstance, firstgrudge);
                CharacterInstance.Stun(CharacterInstance, Secondgrudge); CharacterInstance.MagicalDamage(CharacterInstance, Secondgrudge);
                break;
            case cardName.frogSixthCard:
                break;
            case cardName.frogSeventhCard:
                object fgrudge = CharacterInstance.RevengeDa.IndexOf(0);
                object Sgrudge = CharacterInstance.RevengeDa.IndexOf(1);
                CharacterInstance.Stun(CharacterInstance, fgrudge);
                CharacterInstance.Stun(CharacterInstance, Sgrudge);
                CharacterInstance.PutArmour(CharacterInstance, (int)(CharacterInstance.Armour * 0.1));
                CharacterInstance.Blight(CharacterInstance, Target, 2, CharacterInstance.DamageGiven());
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
                CharacterInstance.Blight(CharacterInstance, lowestenemy, 3,totalEnemyHealth);
                break;
            case cardName.tritonFirstCard:
                int war=0;
                Action<object> getwarriors(object warrs)
                {
                    if ((warrs.GetType() == typeof(WarriorTemplate)) || (warrs.GetType() == typeof(TankWarriorTemplate))) war++;
                    return (Action<object>)warrs;
                }
                foreach (var item in CharacterInstance.Allies) getwarriors(item);
                foreach (var item in CharacterInstance.Enemies) getwarriors(item);
                CharacterInstance.ShieldUp(CharacterInstance, (int)(CharacterInstance.shield*0.1)*war);
                break;
            case cardName.tritonSecondCard:
                TankWarriorTemplate tank = new();
                int gethee= (int)(tank.Health * 0.1);
                foreach (var item in CharacterInstance.Allies) CharacterInstance.ShieldUp(item, gethee);
                break;
            case cardName.tritonThirdCard:
                if (CharacterInstance.shield > 0)
                {
                    CharacterInstance.PowerBuffPercent = 2; CharacterInstance.PolishWeapon();
                    CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                }
                else { CharacterInstance.PhysicalDamage(CharacterInstance, Target); }
                break;
            case cardName.tritonFourthCard:
                CharacterInstance.ShieldUp(CharacterInstance,CharacterInstance.shield * 2);
                CharacterInstance.Provoking(CharacterInstance);
                break;
            case cardName.tritonFifthCard:
                if (CharacterInstance.shield <= 0) CharacterInstance.ShieldUp(CharacterInstance,(int)(CharacterInstance.Health*0.15));
                else { CharacterInstance.PhysicalDamage(CharacterInstance, Target); }
                break;
            case cardName.tritonSixthCard:
                CharacterInstance.PhysicalDamage(CharacterInstance, Target);
                if (CharacterInstance.shield > 0) CharacterInstance.BreakArmour(Target, CharacterInstance.DamageGiven());
                break;
            case cardName.tritonSeventhCard:
                int nextRoundmaybe = 0; nextRoundmaybe = RoundInfo.RoundsPassed;
                int collectiveesscence = 0; collectiveesscence = CharacterInstance.Health + CharacterInstance.shield + CharacterInstance.Armour;

                Timer myr2;
                myr2 = new Timer();
                // Tell the timer what to do when it elapses
                myr2.Elapsed += new ElapsedEventHandler(myEt);
                // Set it to go off every one seconds
                myr2.Interval = 1000;
                // And start it        
                myr2.Enabled = true;
                void myEt(object source2, ElapsedEventArgs e)
                {
                    if (RoundInfo.RoundsPassed == (nextRoundmaybe + 1))//basically checks if the round has passed
                    {
                        collectiveesscence -= CharacterInstance.Health + CharacterInstance.shield + CharacterInstance.Armour;
                        damageObject.DamageValue = collectiveesscence;
                        CharacterInstance.PhysicalDamage(CharacterInstance, CharacterInstance.AttackSponser, damageObject);
                        myr2.Close();
                    }
                    else { }
                }
               
                break;
            case cardName.tritonEighthCard:
                TankWarriorTemplate trr = new();
                if (CharacterInstance.shield <= 0) CharacterInstance.ShieldUp(CharacterInstance, (int)(trr.shield * 0.2));
                if(CharacterInstance.shield >0)
                {
                    int geeer = CharacterInstance.shield;
                    CharacterInstance.shield -= geeer; //removes all shield
                    damageObject.DamageValue = geeer;
                    CharacterInstance.PhysicalDamage(CharacterInstance, Target, damageObject);
                }
                break;
            case cardName.tritonNinthCard:
                CharacterInstance.shield += CharacterInstance.shield;
                int enemycount = 0;
                foreach (var item in CharacterInstance.Enemies)
                {
                    Persona i = (Persona)item;
                    if (i.Health > 0) enemycount++;
                }
                CharacterInstance.shield += (int)(CharacterInstance.shield*0.1*enemycount);
                break;
            default:
                break;
        }
    }

}
