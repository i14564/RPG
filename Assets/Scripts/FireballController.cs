using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {

    public int speed = 5;
    public Vector2 target;
    private Rigidbody2D rbody;
    public int damage = 100;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        var direction = target;
        direction = direction.normalized * speed;
        rbody.velocity = direction;

    }

    /// <summary>
    /// Check for collision
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            other.GetComponent<PlayerAtributes>().curentHealth -= damage;

        if (other.tag != "fireball")
            Destroy(gameObject);
    }
}
