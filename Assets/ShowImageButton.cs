using UnityEngine;
using UnityEngine.UIElements;

public class ShowImageButton : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private Texture2D image;
    [SerializeField] private float duration = 4f;

    private VisualElement popup;
    private Button button;
    private IVisualElementScheduledItem hideTask;

    void Start()   // Start instead of OnEnable, so the UI is ready
    {
        var root = uiDocument.rootVisualElement;
        button = root.Q<Button>("roster");
        popup = root.Q<VisualElement>("popup-image");

        if (button == null) { Debug.LogError("Button 'roster' not found"); return; }
        if (popup == null) { Debug.LogError("VisualElement 'popup-image' not found"); return; }

        if (image != null)
            popup.style.backgroundImage = new StyleBackground(image);

        popup.style.display = DisplayStyle.None;   // start hidden
        button.clicked += ShowImage;
        Debug.Log("Setup OK");
    }

    void OnDestroy()
    {
        if (button != null) button.clicked -= ShowImage;
    }

    private void ShowImage()
    {
        Debug.Log("Button clicked");
        popup.style.display = DisplayStyle.Flex;
        popup.BringToFront();   // make sure nothing is covering it

        hideTask?.Pause();
        hideTask = popup.schedule
            .Execute(() => popup.style.display = DisplayStyle.None)
            .StartingIn((long)(duration * 1000));
    }
}
