using UnityEngine;
using System.Collections;

public class LoadNewArea : MonoBehaviour {

    public string nextLevel;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	void OnTriggerEnter2D(Collider2D player)
    {
        /// <summary>
        /// Load new level
        /// </summary>
        if (player.gameObject.name == "Player")
        {
            Application.LoadLevel(nextLevel);
        }
    }
}
