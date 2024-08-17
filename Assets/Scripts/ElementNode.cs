public readonly struct ElementNode
{
    private readonly string _tag;
    private readonly string _content;

    public readonly string Tag => _tag;
    public readonly string Content => _content;
    
    public ElementNode(string tag, string content)
    {
        _tag = tag;
        _content = content;
    }

    public override string ToString()
    {
        return $"Tag: {_tag}, Content: {_content}";
    }
}