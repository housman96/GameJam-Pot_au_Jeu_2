using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
	GameObject[] aliveVillagers;


	// Start is called before the first frame update
	void Start()
	{
		GenerateNewDialogues();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			foreach (GameObject villager in aliveVillagers) {
				villager.GetComponent<Villager>().Print();
			}
		}
	}


	public void GenerateNewDialogues()
	{
		aliveVillagers = GameObject.FindGameObjectsWithTag("Villager");
		Shuffle(aliveVillagers);

		int numVillagers = aliveVillagers.Length;
		for (int i = 0; i < numVillagers; i++) {
			Villager current = aliveVillagers[i].GetComponent<Villager>();
			current.villagerToTalk1 = aliveVillagers[(i + 1) % numVillagers].GetComponent<Villager>();
			current.villagerToTalk2 = aliveVillagers[(i + 2) % numVillagers].GetComponent<Villager>();
			current.villagerToTalk3 = aliveVillagers[(i + 3) % numVillagers].GetComponent<Villager>();
		}
	}

	private void Shuffle(GameObject[] array)
	{
		for (int t = 0; t < array.Length; t++) {
			GameObject tmp = array[t];
			int r = Random.Range(t, array.Length);
			array[t] = array[r];
			array[r] = tmp;
		}
	}

}
