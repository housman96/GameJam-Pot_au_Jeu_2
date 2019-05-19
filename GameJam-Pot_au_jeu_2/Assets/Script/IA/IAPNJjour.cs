using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using TMPro;
using UnityEngine;


public class IAPNJjour : MonoBehaviour
{
	public GameObject waypoints;
	private Transform[] waypointsArray;
	private Transform target;
	public CharacterAnimationController animationController;
	private Vector3 lastPosition;
	public AIDestinationSetter destinationSetter;
	public AILerp lerp;
	private bool isPlayerNear;

	private bool IsTalkingP1;
	private bool IsTalkingP2;
	public GameObject PanelP1;
	public GameObject PanelP2;
	public TextMeshProUGUI TextP1;
	public TextMeshProUGUI TextP2;


	// Start is called before the first frame update
	void Start()
	{

		if (waypoints) {
			waypointsArray = waypoints.GetComponentsInChildren<Transform>();
		}

		pickNewCurrentWaypoint();
		destinationSetter.target = target;
		lastPosition = transform.position;

		IsTalkingP1 = false;
		IsTalkingP2 = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (!isPlayerNear) {
			if (lerp.enabled == false) {
				lerp.enabled = true;
			}
			if (lerp.reachedDestination) {
				pickNewCurrentWaypoint();
				destinationSetter.target = target;
				lerp.enabled = false;
				lerp.enabled = true;
			}

			Vector2 currentInput = new Vector2(0, 0);
			if ((transform.position - lastPosition).x > 0.01) {
				currentInput.x = 1;
			}

			if ((transform.position - lastPosition).x < -0.01) {
				currentInput.x = -1;
			}

			if ((transform.position - lastPosition).y > 0.01) {
				currentInput.y = 1;
			}

			if ((transform.position - lastPosition).y < -0.01) {
				currentInput.y = -1;
			}

			animationController.input = currentInput;
			lastPosition = transform.position;
		} else {
			lerp.enabled = false;
			animationController.input = new Vector2(0, 0);
		}

	}



	public void pickNewCurrentWaypoint()
	{
		Transform newWaypoint = waypointsArray[Random.Range(1, waypointsArray.Length)];
		while (newWaypoint == target) {
			newWaypoint = waypointsArray[Random.Range(1, waypointsArray.Length)];
		}
		target = newWaypoint;
	}


	public void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.tag == "Player1" || collision.tag == "Player2") {
			isPlayerNear = true;
		}

		if (collision.tag == "Player1") {
			if (Input.GetAxis("P1_Action") > 0) {
				if (!IsTalkingP1) {
					IsTalkingP1 = true;
					Villager current = gameObject.GetComponent<Villager>();
					TalkP1(current);
				}
			}
		}

		if (collision.tag == "Player2") {
			if (Input.GetAxis("P2_Action") > 0) {
				if (!IsTalkingP2) {
					IsTalkingP2 = true;
					Villager current = gameObject.GetComponent<Villager>();
					TalkP2(current);
				}
			}
		}

	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player1" || collision.tag == "Player2") {
			isPlayerNear = false;
		}

		if (collision.tag == "Player1") {
			IsTalkingP1 = false;
			PanelP1.SetActive(false);
		}

		if (collision.tag == "Player2") {
			IsTalkingP2 = false;
			PanelP2.SetActive(false);
		}
	}


	private void TalkP1(Villager current)
	{
		string Nom1 = current.villagerToTalk1.villagerName;
		string Nom2 = current.villagerToTalk2.villagerName;
		string Nom3 = current.villagerToTalk3.villagerName;

		string Taille;
		if (current.villagerToTalk1.house.size == Size.Large) { Taille = "large"; } else if (current.villagerToTalk1.house.size == Size.Medium) { Taille = "medium"; } else { Taille = "small"; }

		string Porte;
		if (current.villagerToTalk1.house.door == Door.Brown) { Porte = "brown"; } else if (current.villagerToTalk1.house.door == Door.Blue) { Porte = "blue"; } else { Porte = "green"; }

		string Objet;
		if (current.villagerToTalk1.house.deco == Deco.Barrel) { Objet = "barrel"; } else if (current.villagerToTalk1.house.deco == Deco.Seat) { Objet = "seat"; } else { Objet = "ladder"; }

		TextP1.text = "Hello,\n<b>" + Nom1 + "</b> has a <b>" + Taille + "</b> house. \n<b>" + Nom2 + "</b> has a <b>" + Porte + "</b> door. \nThere is a <b>" + Objet + "</b> around <b>" + Nom3 + "</b>'s house.";
		PanelP1.SetActive(true);
	}

	private void TalkP2(Villager current)
	{
		string Nom1 = current.villagerToTalk1.villagerName;
		string Nom2 = current.villagerToTalk2.villagerName;
		string Nom3 = current.villagerToTalk3.villagerName;

		string Taille;
		if (current.villagerToTalk1.house.size == Size.Large) { Taille = "large"; } else if (current.villagerToTalk1.house.size == Size.Medium) { Taille = "medium"; } else { Taille = "small"; }

		string Porte;
		if (current.villagerToTalk1.house.door == Door.Brown) { Porte = "brown"; } else if (current.villagerToTalk1.house.door == Door.Blue) { Porte = "blue"; } else { Porte = "green"; }

		string Objet;
		if (current.villagerToTalk1.house.deco == Deco.Barrel) { Objet = "barrel"; } else if (current.villagerToTalk1.house.deco == Deco.Seat) { Objet = "seat"; } else { Objet = "ladder"; }

		TextP2.text = "Hello,\n<b>" + Nom1 + "</b> has a <b>" + Taille + "</b> house. \n<b>" + Nom2 + "</b> has a <b>" + Porte + "</b> door. \nThere is a <b>" + Objet + "</b> around <b>" + Nom3 + "</b>'s house.";
		PanelP2.SetActive(true);
	}


}
