using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boot : MonoBehaviour {
    [Header("UISettings")]
    [SerializeField] private GameObject lifesContent;
    [SerializeField] private Text currentScore;
    [SerializeField] private Text highScore;
    [SerializeField] private GameObject buttonsUI;
    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject tutorialUI;

    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> clip;

    //[Header("Map")]
    private GameObject _map;

    private BootManager manager;
    private bool isMusicEnable = false;
    private bool isUIEnable = false;

    private void Start () {
        InstantiatorHelper.CreateCamera();
        manager = new BootManager();
        manager.SetGameState(GameState.Pause);
        isUIEnable = true;
        UpdateElementsUI(isUIEnable);
    }

    private void Update () {
        Flow();
        if (manager.gameState == GameState.Play) {
            if (Input.GetKeyDown(KeyCode.P)) {
                isUIEnable = !isUIEnable;
                Time.timeScale = isUIEnable ? 0 : 1;
                isMusicEnable = true;
            }
        }
    }

    private void LateUpdate () {
        if (BootManager.Getinstance().gameState == GameState.Play) {
            if (LivesManager.IsDead) {
                if (LivesManager.currentLifes == 0) {
                    Destroy(_map);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    private void Flow () {
        if (manager.gameState == GameState.Play) {
            UpdateElementsUI(isUIEnable);
            if (LivesManager.IsDead) {
                audioSource.clip = clip [0]; // dead
                audioSource.Play();
                manager.Flow();
            }
        }

        UpdateUI();
    }

    public void NewGame () {
        if (manager.gameState == GameState.Play) {
            Debug.LogError("there is an active game going on right now");
            return;
        }

        SetLives();
        UpdateScore();
        _map = InstantiatorHelper.CreateMap();
        manager.CreateGame();
        isUIEnable = false;
    }

    public void QuitGame () {
        manager.QuitGame();
    }

    private void SetLives () {
        manager.SetLives(lifesContent.transform);
    }

    public void UpdateUI () {
        var lifesIcon = lifesContent.GetComponentsInChildren<Image>();

        if (lifesIcon.Length > LivesManager.currentLifes) {
            Destroy(lifesIcon [lifesIcon.Length - 1].gameObject);
        }

        UpdateScore();
    }

    private void UpdateScore () {
        currentScore.text = $"SCORE: {PlayerPrefsData.GetScore()}";
        highScore.text = $"BEST: {PlayerPrefsData.GetBestScore()}";
    }

    void UpdateElementsUI (bool isActive) {
        if (isActive) {
            buttonsUI.SetActive(true);
            titleUI.SetActive(true);
            tutorialUI.SetActive(true);

            if (!isMusicEnable) {
                audioSource.clip = clip [1]; // enviroment
                audioSource.Play();
                audioSource.loop = true;
                isMusicEnable = true;
            }
        } 
        else {
            buttonsUI.SetActive(false);
            titleUI.SetActive(false);
            tutorialUI.SetActive(false);
            isMusicEnable = false;
            audioSource.Stop();
        }
    }

}

public enum GameState {
    Stop = 0,
    Play = 1,
    Pause = 2
}