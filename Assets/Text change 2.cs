using UnityEngine;
using UnityEngine.UIElements;

public class Label2Changer : MonoBehaviour
{
    private Label label2;
    private Button questButton;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        label2 = root.Q<Label>("Label2");
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
        label2.text = "Following a Dream";
    }
}

