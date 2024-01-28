using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel, endPanel, startButton, playAgainButton;

    public void ShowStart()
    {
        startPanel.SetActive(true);
        StartCoroutine(ActivateEventSystem(startButton));
    }

    IEnumerator ActivateEventSystem(GameObject go)
    {
        yield return new WaitForSeconds(0.5f);
        EventSystem.current.SetSelectedGameObject(go);
    }

    public void CloseStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void ShowEndPanel()
    {
        StartCoroutine(DelayedEndPanel());
    }

    private IEnumerator DelayedEndPanel()
    {
        yield return new WaitForSeconds(5);
        endPanel.SetActive(true);
        StartCoroutine(ActivateEventSystem(playAgainButton));
    }
}
