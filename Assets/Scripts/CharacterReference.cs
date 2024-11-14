using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CharacterReference : MonoBehaviour
    {
        private static CharacterReference instance;

        public static CharacterReference Instance => instance;

        public CharacterData detective;
        public CharacterData assistant;
        
        private void Awake()
        {
            instance = this;
        }


    }
}