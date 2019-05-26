using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [SerializeField]
    public Slider chronoSlider;

    public bool isJ1Winner = true;

    public GameObject chasseur;

    public float timeValue;

    public GameObject waypoints;

    public AudioClip clipDay;
    public AudioClip clipNight;


    public PostProcessingProfile dayPostProcess;
    public PostProcessingProfile nightPostProcess;

    public PostProcessingBehaviour camera1;
    public PostProcessingBehaviour camera2;

    public MusicManager musicManager;

    public Dictionary<GameObject, int> scores = new Dictionary<GameObject, int>();
    public Dictionary<GameObject, GameObject> playersSpawn = new Dictionary<GameObject, GameObject>();
    public Dictionary<GameObject, Character> playersSkin = new Dictionary<GameObject, Character>();
    public Dictionary<GameObject, List<GameObject>> playersTargets = new Dictionary<GameObject, List<GameObject>>();

    public List<GameObject> villagerList;
    public List<GameObject> targets = new List<GameObject>();

    private List<Vector3> startVillagerPosition = new List<Vector3>();
    private List<GameObject> listChasseur = new List<GameObject>();

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

    public int scoreP1;
    public int scoreP2;
    public GameObject winner;

    public AudioClip yellingWolvesClip;
    public AudioClip morningClip;

    private bool songDay = false;

    private float deathNumer = 0;
    public static gameManager Instance { get; set; }

    private void Start()
    {
        musicManager.setTargetVolume(0.75f);
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        for (int i = 0; i < playerList.Count; i++)
        {
            playersSpawn.Add(playerList[i], spawnList[i]);
            playersSkin.Add(playerList[i], skinList[i]);
        }

        GameObject[] temp = GameObject.FindGameObjectsWithTag("Villager");

        foreach (GameObject villager in temp)
        {
            villagerList.Add(villager);
            startVillagerPosition.Add(villager.transform.position);
        }

        foreach (GameObject player in playerList)
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
        if (gameManager.Instance.p1HasKilled && gameManager.Instance.p2HasKilled)
        {
            gameManager.Instance.startNewRound();
        }

        timeValue = chronoSlider.value;

        if (timeValue >= 12 && timeValue <= 12.25)
        {
            if (songDay)
            {
                foreach (GameObject player in playerList)
                {
                    teleportPlayer(player);

                    player.gameObject.GetComponent<CharacterEnabler>().changeSkin(player, skinWerewolf);

                }
                deathNumer = 0;
                for (int i = 0; i < villagerList.Count; i++)
                {
                    if (villagerList[i].activeSelf)
                    {
                        villagerList[i].transform.position = new Vector2(500 + i, 500 + i);
                        villagerList[i].GetComponent<IAPNJjour>().enabled = false;
                        villagerList[i].GetComponent<AILerp>().enabled = false;
                    }
                    else
                    {
                        deathNumer++;
                    }
                }

                camera1.profile = nightPostProcess;
                camera2.profile = nightPostProcess;
                musicManager.setMusicOn(clipNight, 1);
                StartCoroutine("yellingWolves");
                songDay = false;

                for (int i = 0; i < Mathf.Min(6, deathNumer + 1); i++)
                {
                    GameObject newChasseur = (Instantiate(chasseur, startVillagerPosition[i], Quaternion.identity));
                    listChasseur.Add(newChasseur);
                    newChasseur.GetComponent<IAChasseur>().waypoints = waypoints;
                }
            }
        }
        else if (timeValue >= 0 && timeValue <= 0.25)
        {

            if (!songDay)
            {
                foreach (GameObject player in playerList)
                {
                    teleportPlayer(player);

                    player.gameObject.GetComponent<CharacterEnabler>().changeSkin(player, playersSkin[player]);

                    player.GetComponent<AILerp>().enabled = false;

                    player.GetComponent<CharacterInputController>().enabled = true;
                    player.GetComponent<Fuite>().isInFuite = false;
                    player.GetComponent<BoxCollider2D>().enabled = true;
                }
                for (int i = 0; i < villagerList.Count; i++)
                {
                    villagerList[i].transform.position = startVillagerPosition[i];
                    villagerList[i].GetComponent<IAPNJjour>().enabled = true;
                    villagerList[i].GetComponent<AILerp>().enabled = true;
                }

                musicManager.setMusicOn(clipDay, 1);
                camera1.profile = dayPostProcess;
                camera2.profile = dayPostProcess;
                foreach (GameObject chasseur in listChasseur)
                {
                    DestroyImmediate(chasseur);

                }
                listChasseur.Clear();

                songDay = true;
                StartCoroutine("morning");
            }

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
        Debug.Log("test0" + scoreP1 + " " + scoreP2);
        if (scoreP1 == 3)
        {
            Debug.Log("test1");
            isJ1Winner = true;
            SceneManager.LoadScene("GameOver");
        }
        else if (scoreP2 == 3)
        {
            Debug.Log("test2");
            isJ1Winner = false;
            SceneManager.LoadScene("GameOver");
        }
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


        if (playersTargets[playerList[0]].Contains(villager))
        {
            panelP1.GetComponent<AfficheCible>().AfficherLaMort(villager);
            scoreP1 += 1;
        }
        else if (playersTargets[playerList[1]].Contains(villager))
        {
            panelP2.GetComponent<AfficheCible>().AfficherLaMort(villager);
            scoreP2 += 1;
        }

        if (player.tag == "Player1")
        {
            p1HasKilled = true;
        }
        else if (player.tag == "Player2")
        {
            p2HasKilled = true;
        }
    }

    public void teleportPlayer(GameObject player)
    {
        spawnPosX = playersSpawn[player].transform.position.x;
        spawnPosY = playersSpawn[player].transform.position.y;

        player.transform.position = new Vector3(spawnPosX, spawnPosY, 0);
    }

    public void startNewRound()
    {
        StartCoroutine("startNewRoundEnum");
    }

    public IEnumerator startNewRoundEnum()
    {
        yield return new WaitForSeconds(4f);
        chronoSlider.value = 0;
        gameManager.Instance.p1HasKilled = false;
        gameManager.Instance.p2HasKilled = false;

        dialogue.GenerateNewDialogues();


    }



}
