using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneFader sceneFader;

    private int sceneIndex;

    private void Awake()
    {
        StartCoroutine(sceneFader.FadeIn()); 
    }

    public void LoadNextLevel()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (sceneIndex > PlayerPrefs.GetInt("levelReached"))
            PlayerPrefs.SetInt("levelReached", sceneIndex);

        LoadLevel(sceneIndex);
    }

    public void LoadLevel(int sceneIndex)
    {
        if (sceneIndex > 4)
            SceneManager.LoadScene(0);

        sceneFader.FadeOut();
        SceneManager.LoadScene(sceneIndex);
    }

    public void RestartLevel()
    {
        sceneFader.FadeOut();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        sceneFader.FadeOut();
        SceneManager.LoadScene(0);
    }
}
