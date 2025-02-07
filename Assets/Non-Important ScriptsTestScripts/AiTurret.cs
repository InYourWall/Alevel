using UnityEngine;
using System.Collections;

public class AiTurret : MonoBehaviour {
	
	public Transform target;
	public Transform looker;
	
	public Transform Xsmoothlooker;
	public Transform Ysmoothlooker;
	
	public float Xspeed = 2f;
	public float Yspeed = 2f;
	
	
	
	// Use this for initialization
    private void Awake()
    {
        target = FindObjectOfType<PlayerControl>().transform;
    }
	
	// Update is called once per frame
	void Update () {
		
		looker.LookAt (target);
		
		float YRotation = looker.eulerAngles.y;
		float XRotation = looker.eulerAngles.x;
		
		Xsmoothlooker.rotation = Quaternion.Slerp(Xsmoothlooker.rotation , Quaternion.Euler(0 , YRotation, 0), Time.deltaTime * Xspeed);
		Ysmoothlooker.rotation = Quaternion.Slerp(Ysmoothlooker.rotation , Quaternion.Euler(XRotation , YRotation, 0), Time.deltaTime * Yspeed);
	}
}