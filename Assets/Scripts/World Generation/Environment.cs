using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Environment
{
    public static float Width = 12.8f;
    public Sprite BackgroundSprite;
    public Dictionary<int, List<GameObject>> ScoreOfGameObjects;
}
