using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class HTMLParser : MonoBehaviour
{
    [SerializeField] private TextAsset _htmlFile;
    [SerializeField] private DOMParser _domParser;

    private const string TAG_PATTERN = @"<(\w+)[^>]*>([^<]*)<\/\1>";

    private readonly List<ElementNode> _elementNodes = new();

    private void Start()
    {
        ParseHTML(_htmlFile.text);

        DOM dom = new(_elementNodes);

        _domParser.Parse(dom);
    }

    private List<ElementNode> ParseHTML(string htmlContent)
    {
        MatchCollection matches = Regex.Matches(htmlContent, TAG_PATTERN);

        foreach (Match match in matches)
        {
            string tag = match.Groups[1].Value;
            string content = match.Groups[2].Value.Trim();

            if (!string.IsNullOrEmpty(content))
            {
                _elementNodes.Add(new ElementNode(tag, content));
            }
        }

        return _elementNodes;
    }
}
