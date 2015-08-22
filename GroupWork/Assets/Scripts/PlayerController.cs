
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{





    public float _speed;
	Rigidbody _rigidbody;
    //This is the PC keycode for PC controls
   
	public KeyCode _jump = KeyCode.Space;
    public KeyCode _moveLeft = KeyCode.A;
    public KeyCode _moveRight = KeyCode.D;
    public KeyCode _shootKey = KeyCode.E;

<<<<<<< HEAD
=======
	public bool isSecond;
	public float AxisInput = 0;
	public string PlayerID; //EG P1, P2, P3, P4

>>>>>>> ac63eaae736e5cd5e96fcf4b55c89425e56c989a
	float _direction = 1; //(If set to 1: Player facing Right) Else if( set to -1: Player Facing left);

    bool _holdingbomb = false;
    bool _bombreleased = false; //This is if the bomb has been released etc etc
    bool _strengthInvert = false;
	public bool _canJump = true;
	private bool _alive = true;


    int _strength = 0;//The strength of the bomb ranging from 0-10

    float _timer = .1f;
    public float _delay = .1f; //this is the delay between the strength incrimenting 


    public GameObject _bomb; //This is the bomb prefab that we have created :D
    public GameObject _strengthbar;




    // Use this for initialization
    void Start()
    {
<<<<<<< HEAD
=======

>>>>>>> ac63eaae736e5cd5e96fcf4b55c89425e56c989a
		_rigidbody = GetComponent<Rigidbody> ();
       
    }

    // Update is called once per frame
    void Update()
    {

		if (!_alive)
			Destroy (this.gameObject);


        PCUserInput();
        Xbox360Input();
        StrengthToggle();
    }

    void PCUserInput()
    {
        
        if (Input.GetKey(_moveLeft))
        {
    
			transform.Translate(new Vector3(0,0,1) * _speed * Time.deltaTime);
<<<<<<< HEAD
			_direction = 1;
=======
			_direction = -1;
>>>>>>> ac63eaae736e5cd5e96fcf4b55c89425e56c989a
        }


        if (Input.GetKey(_moveRight))
        {
			transform.Translate(new Vector3(0,0,-1) * _speed * Time.deltaTime);
<<<<<<< HEAD
			_direction = -1;
=======
			_direction = 1;
>>>>>>> ac63eaae736e5cd5e96fcf4b55c89425e56c989a
        }

        if (Input.GetKey(_jump) && _canJump)
        {
			//Add jump code here quickly!
			_rigidbody.AddForce(new Vector3(0,800,0));
			_canJump = false;

            //transform.Rotate(new Vector3(0, 1, 0), -3);
        }

        if(Input.GetKeyDown(_shootKey))
        {
            ShootBomb();
        }
       
    }

    void StrengthToggle()
    {
        if(_holdingbomb)
        {
            _timer -= Time.deltaTime;
            if(_timer < 0)
            {

                //This Toggles the Strength
                //We should do some strength modifying stuff here as well

                if (!_strengthInvert)
                {
                    _strength += 1;
                    _timer = _delay;

<<<<<<< HEAD
					_strengthbar.transform.localScale = new Vector3(1, 1,_strength);
=======
					_strengthbar.transform.localScale = new Vector3(_strength, 1,1);
>>>>>>> ac63eaae736e5cd5e96fcf4b55c89425e56c989a

                    if (_strength >= 10)
                        _strengthInvert = true;



                }

                if( _strengthInvert)
                {
                    _strength -= 1;
                    _timer = _delay;

<<<<<<< HEAD
					_strengthbar.transform.localScale = new Vector3(1, 1,_strength);
=======
					_strengthbar.transform.localScale = new Vector3(_strength, 1,1);
>>>>>>> ac63eaae736e5cd5e96fcf4b55c89425e56c989a

                    if (_strength <= 0)
                        _strengthInvert = false;

                }



            }

            

        }
    }


<<<<<<< HEAD

=======
	float oldAxis1 = 0.0f;
	float oldAxis2 = 0.0f;
>>>>>>> ac63eaae736e5cd5e96fcf4b55c89425e56c989a

    void Xbox360Input()
    {
        Debug.Log("No Xbox360 Input Yet Lol");
<<<<<<< HEAD

=======
		AxisInput = 0;
		AxisInput = Input.GetAxis (PlayerID.ToString() + "_Horizontal");



		//Debug.Log ("Axis Input is: " + AxisInput.ToString ());

		if (Input.GetButtonDown(PlayerID + "_XboxJump") && _canJump)
		{
			//Add jump code here quickly!
			_rigidbody.AddForce(new Vector3(0,800,0));
			_canJump = false;
		}

		if (Input.GetButtonDown (PlayerID + "_XboxShoot")) 
		{
			ShootBomb();
		}
		


		//Move player left

		if (AxisInput < 0) 
		{
			Debug.Log("Player Moving left");
			transform.Translate(new Vector3(-1,0,0) * _speed * Time.deltaTime);
			_direction = -1;
		}
		
		//Move player right
		
		if (AxisInput > 0) 
		{
			Debug.Log("Player Moving right");
			transform.Translate(new Vector3(1,0,0) * _speed * Time.deltaTime);
			_direction = 1;
		}

		float axis1 = 0.0f;
		float axis2 = 0.0f;

		axis1 =   Input.GetAxisRaw ("P2_Horizontal");
		axis2 = Input.GetAxisRaw ("P2_Horizontal");

		Debug.Log ("Player one input: " + Input.GetAxisRaw ("P1_Horizontal"));
		Debug.Log ("Player two inpuut: " + Input.GetAxisRaw ("P2_Horizontal"));
>>>>>>> ac63eaae736e5cd5e96fcf4b55c89425e56c989a
    }

    void ShootBomb()
    {

        if(_holdingbomb)
        {
			CreateBomb();
			_strength = 0;
			_timer = _delay;
        }


        _holdingbomb = !_holdingbomb;
    }


	void CreateBomb()
	{

		float zOffset = _direction * 3;
<<<<<<< HEAD
		Vector3 Offset = new Vector3 (0, 0 , zOffset);
=======
		Vector3 Offset = new Vector3 (zOffset, 0 , 0);
>>>>>>> ac63eaae736e5cd5e96fcf4b55c89425e56c989a
		Debug.Log ("Z offset: " + zOffset.ToString ());

		GameObject obj = Instantiate(_bomb, transform.position + Offset, transform.rotation) as GameObject;
		BombScript bomb = obj.GetComponent<BombScript> ();
		bomb.SetDirection (_direction);
		bomb.SetStrength(_strength);

	}

	public void isAlive(bool val) { _alive = val; }

}