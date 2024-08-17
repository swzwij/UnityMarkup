using UnityEngine;
using UnityEngine.UI;

public class DOMParser : MonoBehaviour
{
    [SerializeField] private StyleDefaults _styleDefaults;

    public void Parse(DOM dom)
    {
        GameObject container = new GameObject("Container");
        Canvas canvas = container.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        container.AddComponent<CanvasScaler>();
        container.AddComponent<GraphicRaycaster>();

        if (!container.TryGetComponent(out RectTransform containerRectTransform))
            containerRectTransform = container.AddComponent<RectTransform>();
            
        containerRectTransform.anchorMin = new Vector2(0, 1);
        containerRectTransform.anchorMax = new Vector2(0, 1);
        containerRectTransform.pivot = new Vector2(0, 1);
        containerRectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);

        float yOffset = 0f;

        foreach (ElementNode node in dom.ElementNodes)
        {
            GameObject element = new GameObject(node.Tag + " Element");
            element.transform.SetParent(container.transform);

            Text textComponent = element.AddComponent<Text>();
            textComponent.text = node.Content;
            textComponent.font = _styleDefaults.GetFont();

            int fontSize = _styleDefaults.GetFontSize(node.Tag);
            textComponent.fontSize = fontSize;
            textComponent.alignment = TextAnchor.MiddleLeft;

            if (!element.TryGetComponent(out RectTransform rectTransform))
                rectTransform = element.AddComponent<RectTransform>();

            rectTransform.sizeDelta = new Vector2(textComponent.preferredWidth, textComponent.preferredHeight);
            rectTransform.anchorMin = new Vector2(0, 1);
            rectTransform.anchorMax = new Vector2(0, 1);
            rectTransform.anchoredPosition = new Vector2(0, -yOffset);
            rectTransform.pivot = new Vector2(0, 1);

            yOffset += textComponent.preferredHeight;
        }
    }
}