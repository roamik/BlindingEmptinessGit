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
    public Transform from;
    public Transform to;
    public float speed = 1f;
    

    void Start()
    {
       
        direction = true;
        from = transform;
        to = transform;
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
        
        Debug.Log(angle + "");

        if (direction == true) { posOffset = 0; }
        if (direction == false) { posOffset = 180; }

        float limitedAngle = 0;

        if (Mathf.Abs(angle) <= 15f ||  Mathf.Abs(angle) >= 165f)
        {
            limitedAngle = angle;
        }
        else
        {
            if(angle >= 15f && angle <= 90f)
            {
                limitedAngle = 15f;
            }
            else if (angle <= -15f && angle >= -90f)
            {
                limitedAngle = -15f;
            }
            else if (angle <= 165f && angle >= 90f)
            {
                limitedAngle = 165f;
            }
            else if (angle >= -165f && angle <= -90f)
            {
                limitedAngle = -165f;
            }

        }

        if (angle >= 0f && angle <= 90f || angle <= 0f && angle >= -90f)
        {
            if (direction == false)

            {
                direction = true;

                Flip();
            }
        }

        if (angle >= 90f && angle <= 180f || angle <= -90f && angle >= -180f)
        {
            if (direction == true)

            {
                direction = false;

                Flip();
            }
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, limitedAngle + posOffset)); //Rotating!
                                                                                            //transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.deltaTime * speed);
                                                                                            //from = transform;
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