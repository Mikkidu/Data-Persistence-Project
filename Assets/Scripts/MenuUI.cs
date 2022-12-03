using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private TMP_InputField _playerNameInput;
    // Start is called before the first frame update
    void Start()
    {
        SaveData.Instance.LoadScore();
        _bestScoreText.text = $"Best Score: {SaveData.Instance.bestScore.bestPlayerName}: {SaveData.Instance.bestScore.bestScore}";
        _playerNameInput.text = SaveData.Instance.bestScore.lastPlayer;
    }

    public void StartGame()
    {
        SaveData.Instance.SaveScore();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        SaveData.Instance.SaveScore();
    }

    public void EnterName(string playerName)
    {
        SaveData.Instance.bestScore.lastPlayer = playerName;
    }

}
