using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	public GameObject Reiniciar; 
	public Rigidbody rb;
	public float jump;

        private float movementX;
        private float movementY;


	private int count;
	private int countWin;
	private int countLose;


	// At the start of the game..
	void Start ()
	{
		//Reiniciar.gameObject.SetActive(false);

		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;
		countLose = 0;
		countWin = 0;

		SetCountText ();

                // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
                winTextObject.SetActive(false);
	}

	void FixedUpdate ()
	{
		if(Input.GetKey (KeyCode.Space)){
			Vector3 atas = new Vector3(0,5,0);
			rb.AddForce(atas * speed);
		}
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

		rb.AddForce (movement * speed);
	}


	void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;
			countWin = countWin+ 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
			Reiniciar.gameObject.SetActive(true);
		}

		if (other.gameObject.CompareTag ("Bad"))
		{
			other.gameObject.SetActive (false);
            
			count = count - 1;
			countLose = countLose + 1;

			SetCountText ();
			Reiniciar.gameObject.SetActive(true);
		}


	}

        void OnMove(InputValue value)
        {
        	Vector2 v = value.Get<Vector2>();

        	movementX = v.x;
        	movementY = v.y;

        }

        void SetCountText()
	{
		countText.text = "Puntos: " + count.ToString();

		if (countWin >= 12)
		{
            winTextObject.SetActive(true);
			winTextObject.GetComponent<TextMeshProUGUI>().text="Has Ganado";
			SceneManager.LoadScene("MiniGame2");
		}

		if (countLose >= 2)
		{
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
			winTextObject.GetComponent<TextMeshProUGUI>().text="Has Perdido";
		}		
	}
}
