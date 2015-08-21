
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
			_direction = 1;
        }


        if (Input.GetKey(_moveRight))
        {
			transform.Translate(new Vector3(0,0,-1) * _speed * Time.deltaTime);
			_direction = -1;
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

					_strengthbar.transform.localScale = new Vector3(1, 1,_strength);

                    if (_strength >= 10)
                        _strengthInvert = true;



                }

                if( _strengthInvert)
                {
                    _strength -= 1;
                    _timer = _delay;

					_strengthbar.transform.localScale = new Vector3(1, 1,_strength);

                    if (_strength <= 0)
                        _strengthInvert = false;

                }



            }

            

        }
    }




    void Xbox360Input()
    {
        Debug.Log("No Xbox360 Input Yet Lol");

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
		Vector3 Offset = new Vector3 (0, 0 , zOffset);
		Debug.Log ("Z offset: " + zOffset.ToString ());

		GameObject obj = Instantiate(_bomb, transform.position + Offset, transform.rotation) as GameObject;
		BombScript bomb = obj.GetComponent<BombScript> ();
		bomb.SetDirection (_direction);
		bomb.SetStrength(_strength);

	}

	public void isAlive(bool val) { _alive = val; }

}