using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode {
    idle,
    playing,
    levelEnd
}

public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S; //private Singleton

    [Header("Inscribed")]
    public Text uitLevel; //UIText_Level Text
    public Text uitShots; //UIText_Shots Text
    public Vector3 castlePos; //The place to put castles
    public GameObject[] castles; //an array of castles

    [Header("Dynamic")]
    public int level; //current level
    public int levelMax; //number of levels
    public int shotsTaken;
    public GameObject castle; //current castle
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot"; //FollowCam mode

    // Start is called before the first frame update
    void Start()
    {
        S = this; //Define the Singleton
        level = 0;
        shotsTaken = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    void StartLevel(){
        //get rid of the old castle
        if (castle != null){
            Destroy(castle);
        }
        Projectile. DESTROY_PROJECTILES(); //method not yet written

        //instantiate new castle
         castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;

        //reset the goal 
        Goal.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        //show the data in the GUITexts
        uitLevel.text = "Level: " + (level+1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }

    void Update() {
        UpdateGUI();
        //check for level end
        if ((mode == GameMode.playing)&& Goal.goalMet){
            //change mode to stop checking for level end
            mode = GameMode.levelEnd;
            //start the next level in 2 seconds
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel(){
        level++;
        if (level == levelMax){
            level = 0;
            shotsTaken =0;  
        }
        StartLevel();
    }

    static public void SHOT_FIRED(){
        S.shotsTaken++;
    }

    static public GameObject GET_CASTLE(){
        return S.castle;
    }
}
