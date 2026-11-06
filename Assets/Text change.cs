using UnityEngine;
using UnityEngine.UIElements;

public class LabelChanger : MonoBehaviour
{
    private Label label;
    private Button questButton;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        label = root.Q<Label>("Label");
        questButton = root.Q<Button>("Quest");

        questButton.clicked += OnQuestClicked;
    }

    void OnDisable()
    {
        if (questButton != null)
            questButton.clicked -= OnQuestClicked;
    }

    void OnQuestClicked()
    {
        label.text = "Silver Snow Ch.21";
    }
}
