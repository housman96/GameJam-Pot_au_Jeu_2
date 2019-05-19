using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
	public string villagerName;
	public House house;

	public Villager villagerToTalk1;
	public Villager villagerToTalk2;
	public Villager villagerToTalk3;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	
	public void Print()
	{
		Debug.Log("=================");
		Debug.Log(villagerName);
		Debug.Log(villagerToTalk1.villagerName + " => " + villagerToTalk1.house.size);
		Debug.Log(villagerToTalk2.villagerName + " => " + villagerToTalk2.house.door);
		Debug.Log(villagerToTalk3.villagerName + " => " + villagerToTalk3.house.deco);
	}

}
