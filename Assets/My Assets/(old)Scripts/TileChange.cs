using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChange : MonoBehaviour {
	[SerializeField] GameObject tilePrefab;
	private int check = 0;
	GameObject reference2;
	private int num = 0;
	private bool didTouch = false;
	public Sprite rightJumpDown;
	public Sprite leftJumpUp;
	public Sprite leftJumpDown;
	public Sprite rightJumpUp;

	void OnCollisionEnter2D (Collision2D other) {

        if (other.gameObject.tag == "Player" && !didTouch)
        {

			Debug.Log("Player has landed on another tile");

			GameObject thePlayer = GameObject.Find("Player");
			PlayerMovement playerScript = thePlayer.GetComponent<PlayerMovement>();
			other.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;		
			other.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y + 0.12f, this.transform.position.z);
			playerScript.isTouchingTile = true;
			this.enabled = false;
            if (check == 0){
                Instantiate(tilePrefab,new Vector3(this.transform.position.x, this.transform.position.y),Quaternion.identity);

                Destroy(gameObject);
            }
			check++;
			didTouch = true;

			if(playerScript.didLeftJumpDown){
				other.gameObject.GetComponent<SpriteRenderer>().sprite = leftJumpDown;

			}
			if(playerScript.didRightJumpDown){
				other.gameObject.GetComponent<SpriteRenderer>().sprite = rightJumpDown;

			}
			if(playerScript.didLeftJumpUp){
				other.gameObject.GetComponent<SpriteRenderer>().sprite = leftJumpUp;

			}
			if(playerScript.didRightJumpUp){
				other.gameObject.GetComponent<SpriteRenderer>().sprite = rightJumpUp;

			}
	}

		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
			other.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y + 0.05f, this.transform.position.z);

		}

		if (other.gameObject.tag == "Coily") {
			other.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
			other.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y + 0.05f, this.transform.position.z);

		}


		if (other.gameObject.tag == "CoilyBall") {
			other.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
			other.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y + 0.05f, this.transform.position.z);

		}

		if (other.gameObject.tag == "GreenBall") {
			other.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
			other.transform.position =  new Vector3(this.transform.position.x, this.transform.position.y + 0.05f, this.transform.position.z);

		}
	}

	void Update(){
		reference2 = GameObject.Find("Player");
		PlayerMovement playerScript3 = reference2.GetComponent<PlayerMovement>();
					
		if (check == 1) {
			playerScript3.score += check * 25;
			check++;
		}
		}


	//void OnTriggerStay2D (Collider2D other) {
		
}
