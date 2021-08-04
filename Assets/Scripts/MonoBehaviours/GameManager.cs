using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MonoBehaviours
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }

        public List<GameObject> characters = new List<GameObject>();
        public RoundInfo roundInfo;
        public CharacterBehaviour activeCharacter;
        private void Awake()
        {
            Instance = this;
        }
    }
}
