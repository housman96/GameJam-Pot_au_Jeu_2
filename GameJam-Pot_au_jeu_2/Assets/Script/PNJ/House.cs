using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Size { Small, Medium, Large };
public enum Door { Brown, Blue, Green };
public enum Deco { Barrel, Seat, Ladder };

public class House : MonoBehaviour
{
	public Size size;
	public Door door;
	public Deco deco;


	void Start()
	{
		
	}
}
