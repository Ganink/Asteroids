using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InstantiatorHelper : MonoBehaviour
{
    public static GameObject CreateHero () {
        var playerExist = GameObject.FindObjectOfType<CharacterSystem>();
        if (playerExist == null) {
            Debug.Log($"Trying to load LevelPrefab from file {Constants.CHARACTER_PATH_RESOURCE}...");
            var loadedObject = Resources.Load(Constants.CHARACTER_PATH_RESOURCE);
            if (loadedObject == null)
                throw new FileNotFoundException($"Object not found in path: {Constants.CHARACTER_PATH_RESOURCE}");

            var newTransform = new Vector2(0, 0);
            var newGo = (GameObject)Instantiate(loadedObject, newTransform, Quaternion.identity);

            CreateCamera();

            return newGo;
        }
        return playerExist.gameObject;
    }  
    
    public static void CreateExplosionFVX (Transform transformHelper) {
        Debug.Log($"Trying to load LevelPrefab from file {Constants.ANIMATION_FVX_PATH_RESOURCE}...");
        var loadedObject = Resources.Load(Constants.ANIMATION_FVX_PATH_RESOURCE);
        if (loadedObject == null)
            throw new FileNotFoundException($"Object not found in path: {Constants.ANIMATION_FVX_PATH_RESOURCE}");

        var newTransform = new Vector2(0, 0);
        var newGo = (GameObject)Instantiate(loadedObject, transformHelper.position, Quaternion.identity);

        Destroy(newGo, Constants.BULLET_TIME_DESTROY);
    }

    public static void CreateCamera () {
        if (Camera.main == null) {
            var cam = new GameObject();
            cam.name = "mainCamera";
            cam.tag = "MainCamera";
            cam.AddComponent<Camera>();
            var _cam = cam.GetComponent<Camera>();
            _cam.clearFlags = CameraClearFlags.Skybox;
            _cam.orthographic = true;
            _cam.orthographicSize = 15;
            _cam.backgroundColor = Color.black;
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -10);
            cam.AddComponent<AudioListener>();
        }
    }

    public static GameObject CreateMap () {
        Debug.Log($"Trying to load LevelPrefab from file {Constants.MAP_PATH_RESOURCE}...");
        var loadedObject = Resources.Load(Constants.MAP_PATH_RESOURCE);
        if (loadedObject == null)
            throw new FileNotFoundException($"Object not found in path: {Constants.MAP_PATH_RESOURCE}");

        var newTransform = new Vector2(0, 0);
        var newGo = (GameObject)Instantiate(loadedObject, newTransform, Quaternion.identity);

        return newGo;
    }

    public static GameObject CreateLivesPrefab () {
        Debug.Log($"Trying to load LevelPrefab from file {Constants.LIVES_PATH_RESOURCE}...");
        var loadedObject = Resources.Load(Constants.LIVES_PATH_RESOURCE);
        if (loadedObject == null)
            throw new FileNotFoundException($"Object not found in path: {Constants.LIVES_PATH_RESOURCE}");

        var newTransform = new Vector2(0, 0);
        var newGo = (GameObject)Instantiate(loadedObject, newTransform, Quaternion.identity);

        return newGo;
    }
}
