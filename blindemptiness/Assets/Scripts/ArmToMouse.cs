using UnityEngine;
using System.Collections;

public class ArmToMouse : MonoBehaviour

{
    public Transform hitPoint;

    public bool direction;

    public UnityStandardAssets._2D.PlatformerCharacter2D p_Script;

    public Camera cam;

    public int posOffset;

    private Animator anim;

    void Start()

    {
       
        direction = true;
        
    }

    void Update()

    {
        
        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5f;
        

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        
        //Debug.Log(angle + "");

        if (direction == true) { posOffset = 0; }
        if (direction == false) { posOffset = 180; }

        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + posOffset)); //Rotating!



        if (angle > 0f && angle < 100f || angle < 0f && angle > -90f)
        {
            if (direction == false)

            {
                direction = true;

                Flip();
            }
        }

        if (angle > 110f && angle < 180f || angle < -100f && angle > -180f)

            if (direction == true)

            {
                direction = false;

                Flip();
            }
    }


    void Flip()

    {
        if (direction == false && p_Script.m_FacingRight == true || direction == true && p_Script.m_FacingRight == false)

        { p_Script.Flipp(); }

        hitPoint.Rotate(Vector3.forward * 180);

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;


    }

}