using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsToTextManager : MonoBehaviour 
{
	public GameObject manager;
	public StorehouseManager stats;

	public Text text;

	void Start () 
	{
		stats = manager.GetComponent<StorehouseManager> ();

		text = GetComponent<Text> ();
	}
	
	void Update () 
	{
		text.text = "Grain:" + stats.grain +
					"\nWood:" + stats.wood +
					"\nStone:" + stats.ore;
	}
}
