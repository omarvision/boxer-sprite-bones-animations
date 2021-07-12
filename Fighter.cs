using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public float MoveSpeed = 3.5f;
    public float MinPosition = -4.0f;
    public float MaxPosition = 4.0f;
    public string PunchBoneName = "bone_7";
    public string KickBoneName = "bone_12";
    private Animator anim = null;
    private HittingBodyPart punchbone = null;
    private HittingBodyPart kickbone = null;

    private void Start()
    {
        //reference to animator component
        anim = this.GetComponent<Animator>();

        //reference to scripts on punch and kick bones
        punchbone = GetBodyPartScript(PunchBoneName);
        kickbone = GetBodyPartScript(KickBoneName);
    }
    private void Update()
    {
        //control movement
        float horz = Input.GetAxis("Horizontal");  //-1 .. 1
        if (horz > 0 && this.transform.position.x < MaxPosition)
        {
            this.transform.Translate(Vector3.right * horz * MoveSpeed * Time.deltaTime);
        }
        else if (horz < 0 && this.transform.position.x > MinPosition)
        {
            this.transform.Translate(Vector3.right * horz * MoveSpeed * Time.deltaTime);
        }

        //control attacks
        if (Input.GetKeyDown(KeyCode.LeftAlt) == true || Input.GetKeyDown(KeyCode.RightAlt) == true)
        {
            anim.SetTrigger("punch");
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) == true || Input.GetKeyDown(KeyCode.RightControl) == true)
        {
            anim.SetTrigger("kick");
        }
    }
    public void PunchOn()
    {
        punchbone.CanHit = true;
    }
    public void PunchOff()
    {
        punchbone.CanHit = false;
    }
    public void KickOn()
    {
        kickbone.CanHit = true;
    }
    public void KickOff()
    {
        kickbone.CanHit = false;
    }
    private HittingBodyPart GetBodyPartScript(string name)
    {
        //look for the child gameobject in the list of all the child objects
        Transform[] children = this.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.gameObject.name == name)
            {
                return child.gameObject.GetComponent<HittingBodyPart>();
            }
        }
        return null;
    }
}
