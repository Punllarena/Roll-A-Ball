using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour 
{
	public float speed;
	private int count;
	public GUIText countText;
	public GUIText winText;

	void Start()
	{
		count = 0;
		setCountText ();
		winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertival = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertival);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp") 
			{
			other.gameObject.SetActive(false);
			count++; 
			setCountText();
		}
	}
	void setCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!";		
		}
	}
}
//Destroy(other.gameObject);