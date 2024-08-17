using System.Collections.Generic;
using UnityEngine;

public readonly struct DOM
{
    private readonly List<ElementNode> _elementNodes;

    public readonly List<ElementNode> ElementNodes => _elementNodes;

    public DOM(List<ElementNode> elementNodes)
    {
        _elementNodes = elementNodes;
    }

    public void Print()
    {
        foreach (ElementNode tag in _elementNodes)
            Debug.Log(tag);
    }
}
