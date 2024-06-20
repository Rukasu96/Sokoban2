using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private Button[] buttons;

    private bool activePanel = true;
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 1> levelReached)
                buttons[i].interactable = false;
        }
    }

    public void SwitchMenuLevelsPanel()
    {
        menuPanel.SetActive(!activePanel);
        levelsPanel.SetActive(activePanel);
        activePanel = !activePanel;

    }



}
