using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimDelegate : MonoBehaviour
{
    public GameObject leftArmPoint, rightArmPoint, leftLegPoint, rightLegPoint;
    // Start is called before the first frame update
    void LeftArmOn()
    {
        leftArmPoint.SetActive(true);
    }
    void LeftArmOff()
    {
        if (leftArmPoint.activeInHierarchy)
        {
           leftArmPoint.SetActive(false);
        }
        
    }
    void RightArmOn()
    {
        rightArmPoint.SetActive(true);
    }
    void RightArmOff()
    {
        if (rightArmPoint.activeInHierarchy)
        {
            rightArmPoint.SetActive(false);
        }

    }

    void LeftLegOn()
    {
        leftLegPoint.SetActive(true);
    }
    void LeftLegOff()
    {
        if (leftLegPoint.activeInHierarchy)
        {
            leftLegPoint.SetActive(false);
        }

    }
    void RightLegOn()
    {
        rightLegPoint.SetActive(true);
    }
    void RightLegOff()
    {
        if (rightLegPoint.activeInHierarchy)
        {
            rightLegPoint.SetActive(false);
        }

    }
    void TagLeftArm()
    {
        leftArmPoint.tag = Tags.LEFT_ARM_TAG;
    }
    void UnTagLeftArm()
    {
        leftArmPoint.tag = Tags.UNTAGGED_TAG;
    }
    void TagLeftLeg()
    {
        leftLegPoint.tag = Tags.LEFT_LEG_TAG;
    }
    void UnTagLeftLeg()
    {
        leftLegPoint.tag = Tags.UNTAGGED_TAG;
    }
    // Update is called once per frame
}
