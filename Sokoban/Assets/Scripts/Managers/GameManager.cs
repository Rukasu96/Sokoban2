using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int[] tresholds;
    [SerializeField] private GameObject finishPanel;

    public Player _Player;

    private void FinishLevel()
    {
        finishPanel.SetActive(true);
        finishPanel.GetComponent<FinishLevelPanel>().PlayFinishPanel();
    }
   
    public int ReturnRating()
    {
        for (int i = 0; i < tresholds.Length; i++)
        {
            if (_Player.MovesCount >= tresholds[2])
                return 1;
            else if (_Player.MovesCount >= tresholds[1])
                return 2;
        }

        return 3;
    }

    private void OnEnable()
    {
        ExitButton.StageFinished += FinishLevel;
    }
    private void OnDestroy()
    {
        ExitButton.StageFinished -= FinishLevel;
    }
}
