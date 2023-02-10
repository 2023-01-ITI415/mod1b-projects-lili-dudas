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
        Projectile.DESTROY_PROJECTILES(); //method not yet written

        //instantiate new castle
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
