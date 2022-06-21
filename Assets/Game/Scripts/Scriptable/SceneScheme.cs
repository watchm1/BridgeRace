using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneFlow", menuName = "Scheme")]
public class SceneScheme : ScriptableObject
{
    public Scene[] scenes;
    public int CurrentScene { get; set; }
    public void LoadScene()
    {
        SceneManager.LoadScene(scenes[CurrentScene].name);
    }
}
