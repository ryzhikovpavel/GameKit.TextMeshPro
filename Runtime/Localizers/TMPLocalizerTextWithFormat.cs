#pragma warning disable 649
using UnityEngine;

namespace GameKit.TextMeshPro.Localizers
{
    public class TMPLocalizerTextWithFormat: TMPLocalizerText
    {
        [SerializeField] private string[] values;
        
        public override void Bind(string text, bool rtl)
        {
            base.Bind(string.Format(text, values), rtl);
        }
    }
}