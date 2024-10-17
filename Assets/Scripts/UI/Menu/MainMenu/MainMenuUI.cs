using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private TextMeshProUGUI date;

    private void Start()
    {
        newGameButton.OnClickAsObservable().Subscribe(_ =>
        {
            SceneManager.LoadScene(1);
        }).AddTo(this);

        exitButton.OnClickAsObservable().Subscribe(_ => 
        { 
            Application.Quit(); 
        }).AddTo(this);
        
    }

    private void Update()
    {
        date.text = System.DateTime.UtcNow.ToLocalTime().ToString();
    }
}
