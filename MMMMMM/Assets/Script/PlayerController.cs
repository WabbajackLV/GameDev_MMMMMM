using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;
	float velX;
	float velY;
	bool facingRight = true;
	Rigidbody2D rigBody;
	GameObject cam;
	Vector3 checkpoint;
	
    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
		cam = GameObject.Find("Main Camera");
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
		if(other.gameObject.CompareTag("Spikes"))
		{
			this.transform.position = checkpoint;
			rigBody.gravityScale = 3;
			//SceneManager.LoadScene(0);
		}
		if(other.gameObject.CompareTag("NextLevelToRight"))
		{
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
