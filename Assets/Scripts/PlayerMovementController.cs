using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float Speed;
	Vector3 moveVector;
    Rigidbody rb;

	/// Hareketi kameraya göre yapmak için
	public int cameraNormal;
	float moveH = 0,moveV = 0;
	string moveHString,moveVString;
	int moveHSign,moveVSign;
	///

    void Start () 
    {
		rb = GetComponent<Rigidbody>();
	}
    void Update () 
    {
		Movement();
    }
    void FixedUpdate()
	{
		if(moveVector != Vector3.zero)
		{
			rb.MovePosition(rb.position+ moveVector.normalized * Time.fixedDeltaTime * Speed);
		}
	}
	public void SyncWithCameraNormal()
	{
			if(cameraNormal == 0 )
			{
				moveHSign = 1;
				moveVSign = 1;
				moveHString = "Horizontal";
				moveVString = "Vertical";
			}
			else if(cameraNormal == 1 )
			{
				moveHSign = -1;
				moveVSign = 1;
				moveHString = "Vertical";
				moveVString = "Horizontal";
			}
			else if(cameraNormal == 2 )
			{
				moveHSign = -1;
				moveVSign = -1;
				moveHString = "Horizontal";
				moveVString = "Vertical";
			}
			else if(cameraNormal == 3 )
			{
				moveHSign = 1;
				moveVSign = -1;
				moveHString = "Vertical";
				moveVString = "Horizontal";
			}
	}
	void Movement()
	{
		moveH = Input.GetAxisRaw(moveHString) * moveHSign;
		moveV = Input.GetAxisRaw(moveVString) * moveVSign;
		moveVector = new Vector3(moveH,0,moveV);
        LookMovementDirection();
	}
    void LookMovementDirection()
    {
        transform.LookAt(transform.position + moveVector);
    }
}
