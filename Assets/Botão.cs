using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    public GameObject nextMenu;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("Continue").clicked += () =>
        {
            nextMenu.SetActive(true);   
            gameObject.SetActive(false); 
        };
    }
}
