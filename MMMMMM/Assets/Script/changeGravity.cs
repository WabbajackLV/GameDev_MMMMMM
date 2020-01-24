using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGravity : MonoBehaviour
{
	private Rigidbody2D rb;
	private bool top;
	public float timer;
	
	void Start(){
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update(){
		timer += Time.deltaTime;
		if(Input.GetKeyDown(KeyCode.Space) && timer > 0.7f)
		{
		rb.gravityScale *= -1;
		Rotation();
		timer = 0;
		}
	}
	
	void Rotation(){
		if(top == false){
			transform.eulerAngles = new Vector3(0, 0, 180f);
		}else{
			transform.eulerAngles = Vector3.zero;
		}
		top = !top;
	}
}
