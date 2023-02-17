using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrototypeMaze : MonoBehaviour
{
    static private PrototypeMaze S; //private Singleton

    [Header("Inscribed")]
    public Text uitLevel; //UIText_Level Text
    public Text uitScore; //UIText_Shots Text
    public GameObject[] mazes; //an array of mazes
    public Vector3 mazePos; //The place to put mazes

    [Header("Dynamic")]
    public int level; //current level
    public int levelMax; //number of levels
    public int score;
    public GameObject maze;
    public GameMode mode = GameMode.idle;
   
    void Start()
    {
        S = this; //Define the Singleton
        level = 0;
        score = 0;
        levelMax = mazes.Length;
        StartLevel();
    }

    void StartLevel(){
        //get rid of the old maze
        if (maze != null){
            Destroy(maze);
        }

        //instantiate new castle
        maze = Instantiate<GameObject>(mazes[level]);
        maze.transform.position = mazePos;

        //reset the goal 
        Target.targetMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        //show the data in the GUITexts
        uitLevel.text = "Level: " + (level+1) + " of " + levelMax;
        uitScore.text = "Score: " + score;
    }

    void NextLevel(){
        level++;
        if (level == levelMax){
            level = 0;
            score = 0;
        }
        StartLevel();
    }

    void Update() {
        UpdateGUI();
        //check for level end
        if ((mode == GameMode.playing)&& Target.targetMet){
            //change mode to stop checking for level end
            mode = GameMode.levelEnd;
            //start the next level in 2 seconds
            Invoke("NextLevel", 2f);
        }
    }

    static public GameObject GET_MAZE(){
        return S.maze;
    }
}
