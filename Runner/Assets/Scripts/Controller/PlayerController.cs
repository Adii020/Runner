using UnityEngine;
using System.Collections;


public class PlayerController : GameControlScript
{
   


    private Vector3 newPosition;
    private Vector2 startTouchPosition, endTouchPosition;
    public float smooth = 10f;
    private bool right = false;
    private bool mid = true;
    private bool left = false;
    private GameControlScript control;
    


    void Start()
    {
        control = GameObject.Find("GameControl").GetComponent<GameControlScript>();
        newPosition = transform.position;
    }
   
    
    void Update()
    {
        PositionChanging();
        balans();
    }



    void PositionChanging()
        {
            //STEROWANIE PC

             if (Input.GetKeyDown(KeyCode.RightArrow))
             {
                 if (mid == true)
                 {
                     newPosition = new Vector3(2f, newPosition.y, newPosition.z);
                     mid = false;
                     right = true;
                 }
                 if (left == true)
                 {
                     newPosition = new Vector3(0f, newPosition.y, newPosition.z);
                     left = false;
                     mid = true;
                 }


             }
             else if (Input.GetKeyDown(KeyCode.LeftArrow))
             {
                 if (mid == true)
                 {
                     newPosition = new Vector3(-2f, newPosition.y, newPosition.z);
                     mid = false;
                     left = true;
                 }
                 if (right == true)
                 {
                     newPosition = new Vector3(0f, newPosition.y, newPosition.z);
                     right = false;
                     mid = true;
                 }     
            }


            ///// MOBILNE STEROWANIE
        
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
            startTouchPosition = Input.GetTouch(0).position;
            }
              

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;

                if ((endTouchPosition.x < startTouchPosition.x))
                {
                    if (mid == true)
                    {
                        newPosition = new Vector3(-2f, newPosition.y, newPosition.z);
                        mid = false;
                        left = true;
                    }
                    if (right == true)
                    {
                        newPosition = new Vector3(0f, newPosition.y, newPosition.z);
                        right = false;
                        mid = true;
                    }
                }

                if ((endTouchPosition.x > startTouchPosition.x))
                {
                    if (mid == true)
                    {
                        newPosition = new Vector3(2f, newPosition.y, newPosition.z);
                        mid = false;
                        right = true;
                    }
                    if (left == true)
                    {
                        newPosition = new Vector3(0f, newPosition.y, newPosition.z);
                        left = false;
                        mid = true;
                    }
                }
            }

            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smooth);
     }

    void balans()
    {
        if (mid == true)
        {
           
        }
        if (right == true)
        {
            control.TimeSub();
        }
        if (left == true)
        {
            control.TimeAdd();
        }
    }

   

    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			//Destroy(other.gameObject);
			control.PlayerDied();
		
		}

		if (other.tag == "Collectible")
		{
			control.AddScore();
            PlayCollectCoinSound();
            Destroy(other.gameObject);
            
        }

        if (other.tag == "Collectible2")
        {
            PlayCollectCoinSound();
            Destroy(other.gameObject);

        }
    }
}
