using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Entities.Character.Persona;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Entities.Character;

namespace Assets.Scripts.MonoBehaviours
{
    public class CharacterBehaviour : MonoBehaviour
    {
        public Vector3[] positions = { new Vector3(-7.0f, -1.6f, 1.0f), new Vector3(-5.0f, -1.6f, 1.0f), new Vector3(-3.0f, -1.6f, 1.0f), new Vector3(-1.0f, -1.6f, 1.0f) };
        public GameObject parent;
        public Vector3 Goto;
        public SpeciesType species;
        public Image Deck;

        public Persona person;

        void Awake()
        {
            parent = transform.parent.gameObject;
            Goto = transform.position;
            Deck = GameObject.Find("Deck").GetComponent<Image>();
        }

        public void OnMouseDown()
        {
            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = GameManager.Instance.characters[i].transform.GetChild(0).localPosition;
            }

            for (int i = 0; i < parent.transform.childCount; i++)
            {
                if (parent.transform.GetChild(i).transform.localPosition == positions[3])
                {
                    parent.transform.GetChild(i).GetComponent<CharacterBehaviour>().Goto = transform.position;
                    Goto = positions[3];
                }
            }

            SpeciesType[] array = (SpeciesType[])(SpeciesType.GetValues(typeof(SpeciesType)));
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == species)
                    Deck.sprite = DeckPopulate.Instance.cardsBack[i];

                if (array[i] == species)
                    Deck.gameObject.GetComponent<SpeciesHolder>().type = array[i];
            }

            DeckPopulate.Instance.HideDeck();
        }
        public void Update()
        {
            transform.position = Vector3.Lerp(Goto, transform.position, .125f);
            //IdleAnimation();
        }
        Vector3 scale = new Vector3(0.25f, 0.2407f, 0.25f);
        Vector3 initial = new Vector3();
        Vector3 desired = new Vector3();
        Vector3 position = new Vector3();
        public Vector3 GotoS;
        public Vector3 GotoP;
        public void IdleAnimation()
        {
            initial = new Vector3(transform.parent.position.x, -1.4f, 1f);
            desired = new Vector3(transform.parent.position.x, -1.463f, 1f);

            if (transform.parent.localScale == new Vector3(.25f, .25f, .25f))
            {
                GotoS = scale;
                GotoP = desired;
            }

            if (transform.parent.localScale == scale)
                GotoS = new Vector3(.25f, .25f, .25f);

            if (GotoS != scale)
                GotoP = initial;

            transform.parent.localScale = Vector3.Lerp(GotoS, transform.parent.localScale, .1f);
            transform.parent.position = Vector3.Lerp(GotoP, transform.parent.position, .1f);
        }
    }
}
