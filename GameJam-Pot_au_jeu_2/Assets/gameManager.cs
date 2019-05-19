﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    [SerializeField]
    public Slider chronoSlider;

    public float timeValue;

    public Dictionary<GameObject, int> scores = new Dictionary<GameObject, int>();
    public Dictionary<GameObject, GameObject> playersSpawn = new Dictionary<GameObject, GameObject>();
    public Dictionary<GameObject, Character> playersSkin = new Dictionary<GameObject, Character>();

    public List<GameObject> pnjList;
    public List<GameObject> playerList;
    public List<GameObject> spawnList;
    public List<Character> skinList;

    private float spawnPosX;
    private float spawnPosY;

    public Character skinWerewolf;

    private void Start()
    {
        for(int i = 0; i < playerList.Count; i++)
        {
            playersSpawn.Add(playerList[i], spawnList[i]);
            playersSkin.Add(playerList[i], skinList[i]);
            Debug.Log(playerList[i].name);
            Debug.Log(skinList[i].name);
        }
    }

    private void Update()
    {
        timeValue = chronoSlider.value;

        if (timeValue >= 12 && timeValue <= 12.25)
        {
            foreach (GameObject player in playerList)
            {
                spawnPosX = playersSpawn[player].transform.position.x;
                spawnPosY = playersSpawn[player].transform.position.y;

                player.transform.position = new Vector3(spawnPosX, spawnPosY, 0);

                player.gameObject.GetComponent<CharacterEnabler>().changeSkin(player, skinWerewolf);
            }

        }
        else if(timeValue >= 0 && timeValue <= 0.25)
        {
            foreach (GameObject player in playerList)
            {
                spawnPosX = playersSpawn[player].transform.position.x;
                spawnPosY = playersSpawn[player].transform.position.y;

                player.transform.position = new Vector3(spawnPosX, spawnPosY, 0);

                player.gameObject.GetComponent<CharacterEnabler>().changeSkin(player, playersSkin[player]);
            }
        }
    }
}
