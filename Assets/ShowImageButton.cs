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

    void Start() 
    {
        var root = uiDocument.rootVisualElement;
        button = root.Q<Button>("roster");
        popup = root.Q<VisualElement>("popup-image");

        if (image != null)
            popup.style.backgroundImage = new StyleBackground(image);

        popup.style.display = DisplayStyle.None;   
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
        popup.BringToFront(); 

        hideTask?.Pause();
        hideTask = popup.schedule
            .Execute(() => popup.style.display = DisplayStyle.None)
            .StartingIn((long)(duration * 1000));
    }
}
