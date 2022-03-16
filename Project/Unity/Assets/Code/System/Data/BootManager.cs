using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootManager {

    public GameState gameState;

    public BootManager () {
        if (Getinstance() == null) {
            Setinstance(this);
        }
    }

    private static BootManager instance;

    public static BootManager Getinstance () {
        return instance;
    }

    public static void Setinstance (BootManager value) {
        instance = value;
    }

    public void Flow () {

        if (LivesManager.currentLifes > 0) {
            InstantiatorHelper.CreateHero();
            LivesManager.IsDead = false;
        }
        if (LivesManager.currentLifes == 0) {
            PlayerPrefsData.SetBestScore(PlayerPrefsData.GetScore());
        }
    }

    public void CreateGame () {
        InstantiatorHelper.CreateHero();
        PlayerPrefsData.ResetScore();
        SetGameState(GameState.Play);
    }

    public void SetLives (Transform lifesContent) {
        for (int i = 0; i < Constants.MAX_LIVES_PLAYER; i++) {
            var heart = InstantiatorHelper.CreateLivesPrefab();
            heart.transform.SetParent(lifesContent);
        }
    }

    public void SetGameState (GameState state) {
        gameState = state;
    }

    public void QuitGame () {
        SetGameState(GameState.Stop);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

}
