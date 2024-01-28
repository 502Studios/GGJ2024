using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel, endPanel, startButton, playAgainButton;

    public void ShowStart()
    {
        startPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(startButton);
    }

    public void CloseStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void ShowEndPanel()
    {
        endPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(playAgainButton);
    }
    
}
