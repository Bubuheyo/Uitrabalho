using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    public GameObject nextMenu; // drag the UI you want to open here

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("Continue").clicked += () =>
        {
            nextMenu.SetActive(true);   // open the other UI
            gameObject.SetActive(false); // close Main Menu
        };
    }
}
