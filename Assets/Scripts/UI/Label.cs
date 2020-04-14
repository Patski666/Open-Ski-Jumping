using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Label : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text text;
        [SerializeField]
        private Image background;

        public TMP_Text Text { get => text; set => text = value; }
        public Image Background { get => background; set => background = value; }
    }
}