
using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {


    public bool _isTriggered; //Is the bomb triggered? if so explode
    public float _timer;      //How long before the bomb goes of
    public int _strength;     //The default strength of the bomb
    public Vector3 _direction;//This is the standard direction the bomb is moving
	public bool _ApplyForce = false;


	float _dir = 0; //This is just a value that stores the axis that the player is facing
	Rigidbody _rigidbody;

	float forcevalue;
	// Use this for initialization
	void Start () 
    {
		_rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
    {

		forcevalue = 100 * _strength * _dir;

	

		if (_ApplyForce == false) 
		{

			Debug.Log ("Applying force " + forcevalue.ToString());
			_ApplyForce = true;
			_rigidbody.AddForce (new Vector3 (0, 0, forcevalue));
		}


		//transform.position += _direction * _strength * Time.deltaTime;  
	}

	public void SetDirection(float direction)  { _dir = direction; }
	public void SetStrength(int strength) { _strength = strength; } 

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
			PlayerController player = collision.gameObject.GetComponent<PlayerController>();
			player.isAlive(false);
			Debug.Log("Player died");
		}
	}
}
