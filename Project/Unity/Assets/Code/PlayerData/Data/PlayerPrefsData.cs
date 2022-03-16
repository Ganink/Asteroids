using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsData {

    public static void ResetScore () {
        PlayerPrefs.DeleteKey("Score");
    }

    public static int GetScore () {
        var score = PlayerPrefs.GetInt("Score");

        return score;
    }

    public static int GetBestScore () {
        var score = PlayerPrefs.GetInt("BestScore");

        return score;
    }

    public static void SetScore (int newScore) {
        var score = PlayerPrefs.GetInt("Score");

        if (score < newScore) {
            PlayerPrefs.SetInt("Score", newScore);
        }
    }

    public static void SetBestScore (int score) {
        var highScore = PlayerPrefs.GetInt("BestScore");

        if (score > highScore) {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }
}
