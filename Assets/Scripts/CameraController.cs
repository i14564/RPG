using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform followTarget;
    private Vector3 targetPos;
	public float smoth;
	// Use this for initialization
	void Start () {
	    
	}

    /// <summary>
    /// Follow the target with smooth
    /// </summary>
    void FixedUpdate () {
        if (followTarget != null)
        {
            targetPos = followTarget.transform.position - new Vector3(0, 0, 10);
            transform.position = Vector3.Lerp(transform.position, targetPos, 1 / smoth);
        }
	}
}
