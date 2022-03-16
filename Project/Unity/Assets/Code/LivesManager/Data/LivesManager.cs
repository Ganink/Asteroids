using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour {
    public static int currentLifes;
    public static bool IsDead;

    private void Start () {
        Initialized();
    }

    public LivesManager () {
        if (Getinstance() == null) {
            Setinstance(this);
        }
    }

    private LivesManager instance;

    public LivesManager Getinstance () {
        return instance;
    }

    public void Setinstance (LivesManager value) {
        instance = value;
    }

    private void Initialized () {
        currentLifes = Constants.MAX_LIVES_PLAYER;
        Debug.Log($"Current lifes {currentLifes}");
    }

    public static void AddNewLife () {
        currentLifes++;
        Debug.Log($"Current lifes {currentLifes}");
    }

    public static void ConsumeLife () {
        currentLifes--;
        Debug.Log($"Consume life. Current lifes {currentLifes}");
        IsDead = true;
    }
}
