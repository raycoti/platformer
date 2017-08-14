using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
public class rotatePlayer : MonoBehaviour {
	public PlatformerCharacter2D playerScript;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("CharacterRobotBoy");
		//print(player.GetComponent<PlatformerCharacter2D>());
	playerScript = GameObject.Find("CharacterRobotBoy").GetComponent<PlatformerCharacter2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider collision)
    {
        print("ouch");
			//	playerScript.upDateDirection(0.0);
    }
}
