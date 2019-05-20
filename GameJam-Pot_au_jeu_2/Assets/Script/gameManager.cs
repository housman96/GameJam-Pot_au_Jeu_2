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
    public Dictionary<GameObject, List<GameObject>> playersTargets = new Dictionary<GameObject, List<GameObject>>();

    public List<GameObject> villagerList;
    public List<GameObject> targets = new List<GameObject>();

    public List<GameObject> playerList;
    public List<GameObject> spawnList;
    public List<Character> skinList;

    public Character skinWerewolf;

    private float spawnPosX;
    private float spawnPosY;

    public GameObject deadVillager;
    public bool p1HasKilled;
    public bool p2HasKilled;

    public GameObject panelP1;
    public GameObject panelP2;

	public Dialogue dialogue;


    public AudioClip yellingWolvesClip;
    public AudioClip morningClip;

    public static gameManager Instance { get; set; }

    private void Start()
    {
        Instance = this;

        for (int i = 0; i < playerList.Count; i++)
        {
            playersSpawn.Add(playerList[i], spawnList[i]);
            playersSkin.Add(playerList[i], skinList[i]);
        }

        GameObject[] temp = GameObject.FindGameObjectsWithTag("Villager");

        foreach(GameObject villager in temp)
        {
            villagerList.Add(villager);
    }

        foreach(GameObject player in playerList)
        {
            int randIndex1;
            int randIndex2;
            int randIndex3;

            do
            {
                randIndex1 = Random.Range(0, villagerList.Count);
                randIndex2 = Random.Range(0, villagerList.Count);
                randIndex3 = Random.Range(0, villagerList.Count);

            } while (randIndex1 == randIndex2 || randIndex1 == randIndex3 || randIndex2 == randIndex3);

            targets.Add(villagerList[randIndex1]);
            targets.Add(villagerList[randIndex2]);
            targets.Add(villagerList[randIndex3]);


            playersTargets.Add(player, targets);




            if (player.tag == "Player1")
            {
                panelP1.GetComponent<AfficheCible>().SetLesCiblesVisu(playersTargets[player][0], playersTargets[player][1], playersTargets[player][2]);
            }
            else if (player.tag == "Player2")
            {
                panelP2.GetComponent<AfficheCible>().SetLesCiblesVisu(playersTargets[player][0], playersTargets[player][1], playersTargets[player][2]);
            }

            targets = new List<GameObject>();

        }

    }

    private void Update()
    {
        timeValue = chronoSlider.value;

        if (timeValue >= 12 && timeValue <= 12.25)
        {
            foreach (GameObject player in playerList)
            {
                teleportPlayer(player);

                player.gameObject.GetComponent<CharacterEnabler>().changeSkin(player, skinWerewolf);
                
            }
			StartCoroutine("yellingWolves");
        }
        else if (timeValue >= 0 && timeValue <= 0.25)
        {
            foreach (GameObject player in playerList)
            {
                teleportPlayer(player);

                player.gameObject.GetComponent<CharacterEnabler>().changeSkin(player, playersSkin[player]);
            }
            StartCoroutine("morning");
        }
    }

    public IEnumerator yellingWolves()
    {
        AudioSource listener = gameObject.AddComponent<AudioSource>();
        listener.playOnAwake = false;
        listener.clip = yellingWolvesClip;
        listener.loop = false;
        listener.volume = 0.4f;
        listener.Play();
        yield return new WaitUntil(() => !listener.isPlaying);
        Destroy(listener);
    }

    public IEnumerator morning()
    {
        AudioSource listener = gameObject.AddComponent<AudioSource>();
        listener.playOnAwake = false;
        listener.clip = morningClip;
        listener.loop = false;
        listener.volume = 0.4f;
        listener.Play();
        yield return new WaitUntil(() => !listener.isPlaying);
        Destroy(listener);
    }

    public void killVillager(GameObject player, GameObject villager)
    {
        deadVillager = villager;
        deadVillager.SetActive(false);
        
        if(player.tag == "Player1")
        {
            panelP1.GetComponent<AfficheCible>().AfficherLaMort(villager);
            p1HasKilled = true;
        }
        else if(player.tag == "Player2")
        {
            panelP2.GetComponent<AfficheCible>().AfficherLaMort(villager);
            p2HasKilled = true;
        }
    }

    public void teleportPlayer(GameObject player)
    {
        spawnPosX = playersSpawn[player].transform.position.x;
        spawnPosY = playersSpawn[player].transform.position.y;

        player.transform.position = new Vector3(spawnPosX, spawnPosY, 0);
    }

    public IEnumerator startNewRound()
    {
		yield return new WaitForSeconds(1f);

		chronoSlider.value = 0;
        gameManager.Instance.p1HasKilled = false;
        gameManager.Instance.p2HasKilled = false;

		dialogue.GenerateNewDialogues();
    }
}
