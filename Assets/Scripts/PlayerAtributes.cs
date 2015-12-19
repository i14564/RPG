using UnityEngine;
using System.Collections;

public class PlayerAtributes : MonoBehaviour {

	public int maxHealth = 1000;
	public int curentHealth = 1000;
	public int maxMana = 1000;
	public int curentMana = 1000;

	public float healthBarLength;
	public float manaBarLength;

    public bool draw = false;

	// Use this for initialization
	void Start () {
	}

	void Update () {
        curentMana += 2;
        adjustCurentHealthAndMana(0);
	}

    /// <summary>
    /// Draw health and mana bar
    /// </summary>
    void OnGUI () {
        if (draw == true)
        {
            GUI.Box(new Rect(10, 10, healthBarLength, 20), "Heath:" + curentHealth + "/" + maxHealth);
            GUI.Box(new Rect(10, 40, manaBarLength, 20), "Mana:" + curentMana + "/" + maxMana);
        }
	}

    /// <summary>
    /// Adjust health, mana, health and mana bar lenth
    /// </summary>
    public void adjustCurentHealthAndMana(int adj) {

        healthBarLength = curentHealth * Screen.width / 4 / (maxHealth);

        if (healthBarLength < 200)
            healthBarLength = 200;
        if (curentHealth <= 0)
        {
            curentHealth = 0;

            Destroy(gameObject);
            if (gameObject.name == "Player")
            Application.LoadLevel("level_0");
        }

		if(curentHealth >= maxHealth)
			curentHealth = maxHealth;

        manaBarLength = curentMana * Screen.width / 4 / maxMana;

		if(manaBarLength < 200)
			manaBarLength = 200;
		if(curentMana < 0)
			curentMana = 0;
		if(curentMana >= maxMana)
			curentMana = maxMana;
	}
}
