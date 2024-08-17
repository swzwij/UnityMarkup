using System;
using System.Collections.Generic;
using UnityEngine;

public class StyleDefaults : MonoBehaviour
{
    [Serializable]
    public struct FontSize
    {
        public string name;
        public int size;
    }

    [SerializeField] private Font _font;

    [SerializeField] private FontSize[] _fontSizes;
    private readonly Dictionary<string, int> _fontSizeDictionary = new();

    private void Awake()
    {
        foreach (FontSize fontSize in _fontSizes)
        {
            _fontSizeDictionary.Add(fontSize.name, fontSize.size);
        }     
    }

    public int GetFontSize(string name)
    {
        return _fontSizeDictionary[name];
    }

    public Font GetFont()
    {
        return _font;
    }
}
