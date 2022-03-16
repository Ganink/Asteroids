using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader {

    public SceneReloader () {
    }

    public void ResetLevel () {
        Debug.Log("Reset Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}