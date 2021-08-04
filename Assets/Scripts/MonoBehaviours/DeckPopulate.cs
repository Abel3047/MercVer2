using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Entities.Character.Persona;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviours
{
    public class DeckPopulate : MonoBehaviour
    {
        public static DeckPopulate Instance { get; set; }
        public List<Sprite> cardsLion = new List<Sprite>();
        public List<Sprite> cardsCrocodile = new List<Sprite>();
        public List<Sprite> cardsFish = new List<Sprite>();
        public List<Sprite> cardsSalamander = new List<Sprite>();
        public List<Sprite> cardsFrog = new List<Sprite>();
        public List<Sprite> cardsTriton = new List<Sprite>();
        public List<List<Sprite>> cards = new List<List<Sprite>>();
        public List<Sprite> cardsBack = new List<Sprite>();

        public bool showingDeck;
        private void Awake()
        {
            Instance = this;
            cards.Add(cardsLion);
            cards.Add(cardsCrocodile);
            cards.Add(cardsFish);
            cards.Add(cardsSalamander);
            cards.Add(cardsFrog);
            cards.Add(cardsTriton);
        }
        public void OnClick(GameObject button)
        {
            SpeciesType type = button.GetComponent<SpeciesHolder>().type;

            SpeciesType[] array = (SpeciesType[])(SpeciesType.GetValues(typeof(SpeciesType)));
            for (int i = 0; i < array.Length; i++)
            {
                if (type == array[i] && !showingDeck)
                {
                    Populate(cards[i]);
                }
                else if (type == array[i] && showingDeck)
                {
                    HideDeck();
                }
            }
        }
        List<Sprite> currentlyActive = new List<Sprite>();
        public void HideDeck()
        {
            for (int i = 0; i < GameObject.Find("Cards").transform.childCount; i++)
            {
                Destroy(GameObject.Find("Cards").transform.GetChild(i).gameObject);
            }
            showingDeck = false;
        }
        private void Populate(List<Sprite> sprites)
        {
            for (int i = 0; i < currentlyActive.Count; i++)
            {
                Destroy(currentlyActive[i]);
            }

            Vector2 location = new Vector2(-6f, -3.8f);
            Vector2 scale = new Vector2(.25f, .25f);

            for (int i = 0; i < sprites.Count; i++)
            {
                GameObject spawnObject = new GameObject();
                GameObject _object = Instantiate(spawnObject, location, Quaternion.identity, GameObject.Find("Cards").transform);
                _object.transform.localScale = scale;
                CreateCard(_object, sprites[i]);
                Destroy(spawnObject);

                location += new Vector2(1.6f, 0);
            }

            showingDeck = true;
        }

        private void CreateCard(GameObject _object, Sprite sprite)
        {
            _object.AddComponent<CardBehaviour>(); 
            SpriteRenderer renderer = _object.AddComponent<SpriteRenderer>();
            renderer.sprite = sprite;
        }
    }
}
