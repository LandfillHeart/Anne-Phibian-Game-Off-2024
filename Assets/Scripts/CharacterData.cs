using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Data/Character", fileName = "Character Data", order = 1)]
    public class CharacterData : ScriptableObject
    {
        public string name;
        public Sprite icon;
    }
}