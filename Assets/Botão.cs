using UnityEngine;

using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UIDocument))]
public class TrocarCenaBotao : MonoBehaviour
{
    [SerializeField] private string nomeDoBotao = "BotaoJogar"; // o "name" do botão no UXML
    [SerializeField] private string scena = "Fase1";       // a cena que vai abrir

    private Button botao;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        botao = root.Q<Button>(nomeDoBotao);

        if (botao == null)
        {
            Debug.LogError($"Botão '{nomeDoBotao}' não encontrado no UXML.");
            return;
        }

        botao.clicked += CarregarCena;
    }

    private void OnDisable()
    {
        if (botao != null)
            botao.clicked -= CarregarCena;
    }

    private void CarregarCena()
    {
        SceneManager.LoadScene(scena);
    }
}
