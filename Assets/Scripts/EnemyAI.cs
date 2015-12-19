using UnityEngine;
using System.Collections;


public class EnemyAI : MonoBehaviour {
    public GameObject target;
    public int moveSpeed;
    public int rotationSpeed;
    public int damage;
    public GameObject fireball;
    public System.Single shot_time;
    public int shot_time_delay;
    private System.Single move_time;
    public int move_time_delay = 100;
    private Vector3 direction;
    private bool closer = false;


    void Start()
    {
        var shot_time = Time.time;
        move_time = Time.time;

    }


    /// <summary>
    /// Enemy AI 
    /// </summary>
    void Update()
    { 
        // Follow the target
        if (target != null && Vector2.Distance(transform.position, target.transform.position) < 35f && Vector2.Distance(transform.position, target.transform.position) > 5f
             && closer == false)
        {
            if (Time.time >= move_time)
            {
                Vector3 dir = target.transform.position - transform.position;
                // Only needed if objects don't share 'z' value.
                dir.z = 0.0f;
                if (dir != Vector3.zero)
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                        Quaternion.FromToRotation(Vector3.right, dir),
                        rotationSpeed * Time.deltaTime);

                //Move Towards Target
                transform.position += (target.transform.position - transform.position).normalized
                    * moveSpeed * Time.deltaTime;
            }
        }

        //Move randomly on some range near target
        if (target != null && Vector2.Distance(transform.position, target.transform.position) <= 10f && Vector2.Distance(transform.position, target.transform.position) > 0f)
        {
            closer = true;
            if (Time.time >= move_time)
            {
                System.Random rand = new System.Random();
                direction = new Vector3(rand.Next(10), rand.Next(10),0);
                // Only needed if objects don't share 'z' value.
                move_time = Time.time + Time.deltaTime * move_time_delay;
            }

            transform.position += direction.normalized  * moveSpeed * Time.deltaTime;

            if (Vector2.Distance(transform.position, target.transform.position) >= 5f)
                closer = false;
        }

        //Shot fireball
        if (target != null && Vector2.Distance(transform.position, target.transform.position) >= 2f && Vector2.Distance(transform.position, target.transform.position) <= 20f)
        {
            if (Time.time >= shot_time)
            {
                var pos = target.transform.position - transform.position;
                var fball = Instantiate(fireball, transform.position + 2 * pos.normalized, Quaternion.identity) as GameObject;
                fball.GetComponent<FireballController>().target = pos;
                fball.GetComponent<FireballController>().damage = damage;    
                shot_time = Time.time+ Time.deltaTime * shot_time_delay;
            }            
        }

        //Damage if target too close
        if (target != null && Vector2.Distance(transform.position, target.transform.position) <= 2f)
        {
            var script =  target.GetComponent<PlayerAtributes>();
            script.curentHealth -= damage;
        }
    }
}
