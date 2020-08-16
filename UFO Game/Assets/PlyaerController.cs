using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlyaerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private int count;
    public Text countText;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      float moveHorizontal = Input.GetAxis ("Horizontal");
      float moveVertical = Input.GetAxis ("Vertical");
      Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
      rb2d.AddForce(movement*speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUp"))
                {
                     other.gameObject.SetActive(false);
                     count = count + 1;
                     SetCountText ();
                }
    }

    void SetCountText(){
      countText.text = "Count: " + count.ToString ();
      if(count >= 12) winText.text = "You win!";
    }
}
