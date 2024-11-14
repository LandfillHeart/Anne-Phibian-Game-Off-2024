using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class DialogueBox : MonoBehaviour
    {
        public TextMeshProUGUI content;

        public TextMeshProUGUI characterName;
        
        public Image icon;
        
        
        public void SetContent(string newText, CharacterData character)
        {
            content.text = newText;
            characterName.text = character.name;
            icon.sprite = character.icon;
        }
        
    }
}