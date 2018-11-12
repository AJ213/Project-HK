using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static int levelNum;
    public static bool alive;
    public static Vector3[] playerData = new Vector3[] { new Vector3(0, 0.8f, 0), new Vector3(-90, 0, 0) };
    public static Vector3[] cameraPositions = new Vector3[] { new Vector3(0, 5, 0), new Vector3(-0.04f, 0, 0.06f) };
    public static Vector3[] cameraRotations = new Vector3[] { new Vector3(90, -90, -180), new Vector3(180, -75, -90) };

    public GameObject[] allEnemies;
    public List<GameObject> allEnemiesCopy;
    public GameObject prompt;
    public  GameObject player;

    public delegate void ChangeLevel();
    public static event ChangeLevel OnLevelChange;

    void SetLevel(int level)
    {
        //OnLevelChange();
        //Camera.main.transform.position = cameraPositions[level];
        //Camera.main.transform.eulerAngles = cameraRotations[level];
        //player.transform.position = playerData[level];
    }
    public float smoothFactor = 0.1f;
    void SetCameraPosition(int when)
    {
        //Vector3 offset = playerData[0] + cameraPositions[when];
        //Vector3 rotationoffset = playerData[0] + cameraRotations[when];


        //Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, offset, smoothFactor);
        //Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, rotationoffset, smoothFactor);
    }


    private void Start()
    {
        
        
        //StartPrompt();
        //GameObject go;
        //player = GameObject.FindGameObjectWithTag("Player");
        //foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        //{
        //    go = Instantiate(enemy, enemy.transform.position, enemy.transform.rotation) as GameObject;
        //    allEnemiesCopy.Add(go);
        //    go.SetActive(false);
        //}
    }

    private void Update()
    {
        //if(alive == false)
        //{
        //    StartPrompt();
        //}

    }

    //void StartPrompt()
    //{
    //    prompt.SetActive(true);
    //    if (Input.GetButtonDown("Submit"))
    //    {
    //        prompt.SetActive(false);
    //        Restart();
    //    }
    //}

    //public void Restart()
    //{
    //    levelNum = 0;
    //    alive = true;
    //    player.GetComponent<HealthScript>().Health = 1;
    //    SetLevel(0);
    //    foreach (GameObject aliveEnemy in GameObject.FindGameObjectsWithTag("Enemy"))
    //    {
    //        foreach(GameObject enemy in allEnemiesCopy.ToArray())
    //        {
    //            if (aliveEnemy == enemy)
    //            {
    //                continue;
    //            }
    //        }
            
    //        Destroy(aliveEnemy);
    //    }
    //    GameObject go;
    //    foreach (GameObject enemy in allEnemiesCopy.ToArray())
    //    {
    //        go = Instantiate(enemy, enemy.transform.position, enemy.transform.rotation) as GameObject;
    //        go.SetActive(true);
    //    }
    //}

    
}
