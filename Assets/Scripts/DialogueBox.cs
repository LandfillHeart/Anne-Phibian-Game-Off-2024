using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class DialogueBox : MonoBehaviour
    {
        public TextMeshProUGUI content;

        public void SetContent(string newText)
        {
            content.text = newText;
        }
        
    }
}