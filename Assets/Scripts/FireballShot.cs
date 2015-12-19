using UnityEngine;
using System.Collections;

public class FireballShot : MonoBehaviour {

    public GameObject fireball;
    public int damage;

	// Use this for initialization
	void Start () {
	
	}

    /// <summary>
    /// Shot fireball if left mouse button pressed
    /// </summary>
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<PlayerAtributes>().curentMana > 100)
            {
                var pos = new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0);
                var fball = Instantiate(fireball, transform.position + 2 * pos.normalized, Quaternion.identity) as GameObject;
                fball.GetComponent<FireballController>().target = pos;
                fball.GetComponent<FireballController>().damage = damage;
                GetComponent<PlayerAtributes>().curentMana -= 100;
            }
        }
    }
}
