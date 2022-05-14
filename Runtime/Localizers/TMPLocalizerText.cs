using TMPro;
using UnityEngine;

namespace GameKit.TextMeshPro.Localizers
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TMPLocalizerText : LocalizerText
    {
        [SerializeField] private TMP_Text label;
        
        protected override void UpdateText(string text, bool rtl)
        {
            label.text = text;
            label.isRightToLeftText = rtl;
#if UNITY_EDITOR
            if (Application.isPlaying == false)
            {
                label.enabled = false;
                label.enabled = true;
            }
#endif
        }
        
        private void Awake()
        {
            if (label is null) label = GetComponent<TMP_Text>();
        }
        
        protected virtual void Reset()
        {
            label = GetComponent<TMP_Text>();
        }
    }
}