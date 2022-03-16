using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants {

    // Map
    public const string MAP_PATH_RESOURCE = "Map/main-map";

    // Character
    public const int CHARACTER_SPEED = 10;
    public const int CHARACTER_ROTATION_SPEED = 2;
    public const string CHARACTER_PATH_RESOURCE = "Players/Player";

    // Lives
    public const int MAX_LIVES_PLAYER = 3;
    public const string LIVES_PATH_RESOURCE = "System/Heart";

    // Bullets
    public const int BULLET_SPEED = 20;
    public const float BULLET_TIME_DESTROY = 1;

    // Asteroids
    public const int ASTEROID_SPEED = 50;
    public const float ASTEROID_MIN_TIME_DESTROY = 3f;
    public const float ASTEROID_MAX_TIME_DESTROY = 6f;
    public const float ASTEROID_TIME_CREATE = 6f;

    // Settings
    public const string ANIMATION_FVX_PATH_RESOURCE = "Players/Explosion";
    public const float ANIMATION_FVX_TIME_DESTROY = 1;

}
