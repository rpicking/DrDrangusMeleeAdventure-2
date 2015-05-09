using UnityEngine;
using System.Collections;

public class temp : MonoBehaviour {

	public int playerNum;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ControlManager.PlayerState player = ControlManager.Player (playerNum);

		transform.Translate (-player.Left (), 0, 0);
		transform.Translate ( player.Right (), 0, 0);
		transform.Translate (0,  player.Up (), 0);
		transform.Translate (0, -player.Down(), 0);


	}
}
