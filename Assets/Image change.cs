using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class ImageCycler : MonoBehaviour
{
    [Tooltip("The four images to cycle through")]
    [SerializeField] private Sprite[] images = new Sprite[4];

    [SerializeField] private string buttonName = "cycle-button";
    [SerializeField] private string imageName = "display-image";

    private Button cycleButton;
    private VisualElement displayImage;
    private int currentIndex = 0;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        cycleButton = root.Q<Button>(buttonName);
        displayImage = root.Q<VisualElement>(imageName);

        if (cycleButton == null || displayImage == null)
        {
            Debug.LogError("ImageCycler: Button or image element not found in UXML.");
            return;
        }

        cycleButton.clicked += OnButtonClicked;
        ShowImage(currentIndex);
    }

    private void OnDisable()
    {
        if (cycleButton != null)
            cycleButton.clicked -= OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        if (images == null || images.Length == 0) return;

        currentIndex = (currentIndex + 1) % images.Length;
        ShowImage(currentIndex);
    }

    private void ShowImage(int index)
    {
        if (images[index] == null) return;

        if (displayImage is Image img)
            img.sprite = images[index];
        else
            displayImage.style.backgroundImage = new StyleBackground(images[index]);
    }
}
