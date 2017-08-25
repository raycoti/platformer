using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;


public class rotatePlayer : MonoBehaviour {
	public PlatformerCharacter2D playerScript;
	private GameObject player;
	private Transform m_Rigidbody;
	// Use this for initialization
	public string dir1;
	public string dir2;
	private float d1;
	private float d2;
	private bool first = true;
	private bool toggle;

	void Start () {
		m_Rigidbody = GetComponent<Transform>();
		toggle = first;
		if(!player){player = GameObject.Find("CharacterRobotBoy");}
		if(!playerScript){playerScript = GameObject.Find("CharacterRobotBoy").GetComponent<PlatformerCharacter2D>();}
		d1 = getDirection(dir2);
		d2 = getDirection(dir1);
	}

	private float getDirection (string userDir){
		if(userDir == "front"){
			return 0.0f;
		}
		else if (userDir == "back"){
			return 180.0f;
		}
		else if (userDir == "left"){
			return 270.0f;
		}
		else{
			return 90.0f;
		}
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
		
		//x and z should be center of this square;
		if(!hasCollide){
			Collidetimer = Time.deltaTime + 0.2f;
			currentTime = 0;
			if(toggle){
				playerScript.UpDateDirection(d1, m_Rigidbody.position.x,m_Rigidbody.position.z,true);
			}
			else{
				playerScript.UpDateDirection(d2, m_Rigidbody.position.x,m_Rigidbody.position.z,true);
			}
      hasCollide = true;   
			toggle = !toggle;
			//print(Collidetimer);
        //print("collided");
		//print(Time.deltaTime);
		}
    }
}
