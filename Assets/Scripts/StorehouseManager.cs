using UnityEngine;
using System.Collections;

public class StorehouseManager : MonoBehaviour 
{
	public int grain;
	public int wood;
	public int ore;

	private float timer;

	void Start () 
	{
		grain = 2000;
		wood = 2000;
		ore = 2000;

		timer = 1;
	}
	
	void Update () 
	{
		timer -= Time.deltaTime;

		if (timer <= 0) 
		{
			grain -= 5;
			wood -= 5;
			ore -= 5;

			timer = 1;
		}
	}
}
