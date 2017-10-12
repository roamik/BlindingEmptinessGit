using UnityEngine;
using System.Collections;

public class ArmToMouse : MonoBehaviour

{
    //public Transform hitPoint;
    public const float FLIPOFFSET = 30f;
    public bool direction;
    public UnityStandardAssets._2D.PlatformerCharacter2D p_Script;
    public int posOffset;
    private Animator anim;

    

    void Start()
    {
        p_Script = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
        anim = GetComponent<Animator>();
        direction = true;
    }

    void Update()
    {
        //rotation
        Vector2 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (direction == true) { posOffset = 0; }
        if (direction == false) { posOffset = 180; }

        float limitedAngle = 0;
        float blendAngle = 0;
        float angleLimit = 12f;
        float flipAngleLimit = 180f - angleLimit;
        float angleOffset = 0.1f;


        if (Mathf.Abs(angle) <= angleLimit || Mathf.Abs(angle) >= flipAngleLimit)
        {
            limitedAngle = angle;
            if (angle <= angleLimit && angle > 0f + angleOffset)
            {
                blendAngle = angle / angleLimit;
                Debug.Log(blendAngle + "    1");
            }
            else if (angle < 0f - angleOffset && angle >= -angleLimit)
            {
                blendAngle = angle / angleLimit;
                Debug.Log(blendAngle + "    4");
            }
            else if (angle < 180f - angleOffset && angle >= flipAngleLimit)
            {
                blendAngle = (angleLimit - (angle - flipAngleLimit)) / angleLimit;
                Debug.Log(blendAngle + "    2");
            }
            else if (angle > -180f + angleOffset && angle <= -flipAngleLimit)
            {
                blendAngle = (angleLimit + (angle + flipAngleLimit)) / -angleLimit;
                Debug.Log(blendAngle + "    3");
            }
            else
            {
                blendAngle = 0;
            }

        }
        else
        {
            if (angle >= angleLimit && angle <= 90f)
            {
                limitedAngle = angleLimit;
                blendAngle = 1f;
            }
            else if (angle <= -angleLimit && angle >= -90f)
            {
                limitedAngle = -angleLimit;
                blendAngle = -1f;
            }
            else if (angle <= flipAngleLimit && angle >= 90f)
            {
                limitedAngle = flipAngleLimit;
                blendAngle = 1f;
            }
            else if (angle >= -flipAngleLimit && angle <= -90f)
            {
                limitedAngle = -flipAngleLimit;
                blendAngle = -1f;
            }

        }

        if (Vector2.Distance(mousePos, transform.position) > 32f)
        {
            if (angle >= 0f + FLIPOFFSET && angle <= 90f - FLIPOFFSET || angle <= 0f - FLIPOFFSET && angle >= -90f + FLIPOFFSET)
            {
                if (direction == false)

                {
                    direction = true;

                    Flip();
                }
            }

            if (angle >= 90f - FLIPOFFSET && angle <= 180f - FLIPOFFSET || angle <= -90f + FLIPOFFSET && angle >= -180f - FLIPOFFSET)
            {
                if (direction == true)

                {
                    direction = false;

                    Flip();
                }
            }
        }
        // transform.rotation = Quaternion.Euler(new Vector3(0, 0, limitedAngle + posOffset)); //Rotating!
        anim.SetFloat("ArmAngle",blendAngle );
        //Gizmos.DrawLine(transform.position, new Vector3(0, 0, limitedAngle + posOffset));                                                                                 //transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.deltaTime * speed);
             Debug.DrawRay(transform.position, mousePos);//from = transform;
       // Debug.Log(Vector2.Distance(mousePos, transform.position));
    }

    private void OnDrawGizmos()
    {        
        Gizmos.DrawWireSphere(transform.position, 1f);
        
    }

    void Flip()
    {
        if (direction == false && p_Script.m_FacingRight == true || direction == true && p_Script.m_FacingRight == false)

        {
            p_Script.Flipp();
        }
    }

}