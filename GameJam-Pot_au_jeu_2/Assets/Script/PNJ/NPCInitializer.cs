using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInitializer : MonoBehaviour
{
	public List<GameObject> villagers;
	public List<GameObject> houses;


    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject villager in villagers) {
			int randomIndex = Random.Range(0, houses.Count);
			GameObject randHouse = houses[randomIndex];
			houses.RemoveAt(randomIndex);

			villager.GetComponent<Villager>().house = randHouse.GetComponent<House>();
		}
    }

    // Update is called once per frame
    void Update()
    {
		//if (Input.GetKeyDown(KeyCode.Space)) {
		//	foreach (GameObject villager in villagers) {
		//		Debug.Log("=================");
		//		villager.GetComponent<Villager>().Print();
		//	}
		//}
    }
}
