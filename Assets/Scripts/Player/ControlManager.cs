using UnityEngine;
using System.Collections;
using InControl;
using System.Collections.Generic;


/* Controls:
 * 
 * Up, down left, right
 * 
 * 
 * 
 * 
 */

public class ControlManager : MonoBehaviour {


	// Public Interface //
	
	// Returns the player's state.
	public static PlayerState Player(int i) {
		if (i >= playerStates.Count) {
			playerStates.Add (new PlayerState(playerStates.Count));
		}
		return playerStates [i];
	}



	public class PlayerState {

		public float Left() {
			if (state == null || state.LeftStickX >= -deadZone) return 0f;

			return -state.LeftStickX;
		}	
		public float Right() {
			if (state == null || state.LeftStickX <= deadZone)return 0f;

			return state.LeftStickX;
		}
		public float Up () {
			if (state == null || state.LeftStickY <= deadZone)return 0f;

			return state.LeftStickY;
		}
		public float Down() {
			if (state == null || state.LeftStickY >= -deadZone)return 0f;

			return -state.LeftStickY;
		}

		public bool Attack() {
			if (state == null)return false;

			return state.Action1;
		}
		public bool Special() {
			if (state == null)return false;
			
			return state.Action2;
		}
		public bool Block() {
			if (state == null)return false;
			
			return state.Action2;
		}
		public bool Grab() {
			if (state == null)return false;
			
			return state.Action3;
		}





		public int GetID() {
			return ID;
		}

		public void UpdateState(InputDevice i) {
			prevState = state;
			state = i;

			if (prevState == null && state != null) {
				Debug.Log("Player " + GetID () + " Connected");
			}

			if (prevState != null && state == null) {
				Debug.Log("Player " + GetID () + " Disconnected");
			}
		}

		public PlayerState(int id) {
			state = null;
			ID = id;
		}
		int ID;
		InputDevice state;
		InputDevice prevState;
	};












	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {




		for (int i = 0; i < InputManager.Devices.Count; ++i) { 

			if (i < playerStates.Count) {
				playerStates[i].UpdateState(InputManager.Devices[i]);
			} else {
				playerStates.Add (new PlayerState(playerStates.Count));
				Debug.Log ("Added new controller: ID " + (playerStates.Count-1));
			}

		}

		// Tell all devices that werent updated that their
		// devices are unreachable.
		if (InputManager.Devices.Count < playerStates.Count) {
			for (int i = InputManager.Devices.Count; i < playerStates.Count; ++i) {
				playerStates [i].UpdateState (null);
			}
		}
	}



	static List<PlayerState> playerStates = new List<PlayerState>();
	static float deadZone = .05f;

}
