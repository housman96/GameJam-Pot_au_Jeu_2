using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillText : MonoBehaviour
{
	public TextMeshProUGUI killText;


	public void UpdateKillText(GameObject villager)
	{
		string villagerName = villager.GetComponent<Villager>().villagerName;
		killText.text = villagerName + " died tonight";
	}
}
