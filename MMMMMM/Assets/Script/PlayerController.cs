using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Text hardmode;
	GameObject victory1;
	GameObject victory2;
	float velX;
	float velY;
	bool facingRight = true;
	bool hm = false;
	Rigidbody2D rigBody;
	GameObject cam;
	Vector3 checkpoint;
	
    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
		cam = GameObject.Find("Main Camera");
		checkpoint = this.transform.position;
		victory1 = GameObject.Find("VictoryText1");
		victory1.GetComponent<Text>().enabled = false;
		victory2 = GameObject.Find("VictoryText2");
		victory2.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        velX = Input.GetAxisRaw("Horizontal");
		velY = rigBody.velocity.y;
		rigBody.velocity = new Vector2(velX * moveSpeed, velY);
    }
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Coins"))
		{
			Destroy(other.gameObject);
		}
		if(other.gameObject.CompareTag("Coin_Hardmode"))
		{
			Destroy(other.gameObject);
			Destroy(hardmode);
			hm = true;
		}
		if(other.gameObject.CompareTag("Spikes"))
		{
			if (!hm)
			{
				this.transform.position = checkpoint;
				rigBody.gravityScale = 3;
				rigBody.velocity = new Vector2 (0,0);
			}
			if (hm)
			{
				SceneManager.LoadScene(0);
			}
		}
		if(other.gameObject.CompareTag("NextLevelToRight"))
		{
			Destroy(hardmode);
			cam.transform.position = cam.transform.position + new Vector3(7.666667f,0,0);
			checkpoint = this.transform.position;
			Destroy(other.gameObject);
		}
		if(other.gameObject.CompareTag("NextLevelUpwards"))
		{
			cam.transform.position = cam.transform.position + new Vector3(0,11f,0);
			checkpoint = this.transform.position + new Vector3(2,3,0);
			Destroy(other.gameObject);
		}
		if(other.gameObject.CompareTag("NextLevelDownwards"))
		{
			cam.transform.position = cam.transform.position + new Vector3(0,-11f,0);
			checkpoint = this.transform.position;
			Destroy(other.gameObject);
			victory1.GetComponent<Text>().enabled = true;
			victory2.GetComponent<Text>().enabled = true;
		}
		if(other.gameObject.CompareTag("PlayAgain"))
		{
			SceneManager.LoadScene(0);
		}

	}
	
	void LateUpdate()
	{
		Vector3 localScale = transform.localScale;
		if(velX > 0){
			facingRight = true;
		}else if(velX < 0){
			facingRight = false;
		}
		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0))){
			localScale.x *= -1;
		}
		
		transform.localScale = localScale;
		
	}
	
	
}
