using UnityEngine;

namespace GameKit.TextMeshPro.Localizers
{
    public class TMPLocalizerTextWithPrefix: TMPLocalizerText
    {
        [SerializeField] private string prefix;
        [SerializeField] private string postfix;
        
        public override void Bind(string text, bool rtl)
        {
            base.Bind(prefix + text + postfix, rtl);
        }
    }
}