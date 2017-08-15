using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
public class rotatePlayer : MonoBehaviour {
	public PlatformerCharacter2D playerScript;
	private GameObject player;
	// Use this for initialization
	public float d1;
	public float d2;
	public bool toggle;
	void Start () {
		player = GameObject.Find("CharacterRobotBoy");
		//print(player.GetComponent<PlatformerCharacter2D>());
	if(!playerScript) {playerScript = GameObject.Find("CharacterRobotBoy").GetComponent<PlatformerCharacter2D>();}
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider collision)
    {
        print("ouch");
		if(toggle){
			playerScript.UpDateDirection(d1);
		}
		else{
			playerScript.UpDateDirection(d2);
		}
		toggle = !toggle;
		
    }
}
