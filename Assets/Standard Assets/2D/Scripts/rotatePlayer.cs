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
	private bool hasCollide = false;
	private float Collidetimer = 1;
	private float currentTime = 0;
	void Update () {
		//print(Time.deltaTime > Collidetimer);
		currentTime+= Time.deltaTime;
		if(hasCollide && currentTime > Collidetimer){
			hasCollide = false;
			currentTime= 0;
			Collidetimer=1;
		}
	}
	void OnTriggerEnter(Collider collision)
    {
		
		if(hasCollide == false){
			Collidetimer = Time.deltaTime + 0.2f;
			currentTime = 0;
			if(toggle){
				playerScript.UpDateDirection(d1,true);
			}
			else{
				playerScript.UpDateDirection(d2,true);
			}
            hasCollide = true;   
			toggle = !toggle;
			print(Collidetimer);
        print("collided");
		print(Time.deltaTime);
		}
    }
}
