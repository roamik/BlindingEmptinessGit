using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets._2D;

public class FootstepSound : MonoBehaviour
{

    public List<GroundType> GroundTypes = new List<GroundType>();
    public PlatformerCharacter2D PC2D;
    public string currentGround;

	// Use this for initialization
	void Start ()
    {
        setGroundType(GroundTypes[0]);
	}
	
	// Update is called once per frame
	void Update ()
    {
        	
	}


    void OnControllerColliderHit (ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Snow")
        {
            setGroundType(GroundTypes[1]);
        }
        else if (hit.transform.tag == "DefaultGround")
        {
            setGroundType(GroundTypes[2]);
        }
        else
        {
            setGroundType(GroundTypes[0]);
        }
    }


    public void setGroundType(GroundType ground)
    {
        if (currentGround != ground.name)
        {
            PC2D.footSound = ground.footstepSounds;
            currentGround = ground.name;
        }

    }
}
[System.Serializable]
public class GroundType
{
    public string name;
    public AudioClip[] footstepSounds;
}
