using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorPuzzleManager : MonoBehaviour
{
    public bool movingCogOnTop = false;
    public bool movingCogOnBot = false;
    public bool topPathOpen = false;
    public bool bottomPathOpen = false;
    public bool cogInHand = false;
    public Animator topCogAnimator, botCogAnimator, overallDoorAnimator, middleBlockAnimator, movingCogAnimator;

     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TopValve()
    {
        if (topPathOpen == false)
        {
            if(movingCogOnTop)
            {
                topCogAnimator.Play("TopCogSuccess");
                topPathOpen = true;
            }
            else
            {
                topCogAnimator.Play("TopCogEmpty");
            }
        }
    }

    public void BotValve()
    {
        if(bottomPathOpen == false)
        {
            if (movingCogOnBot)
            {
                botCogAnimator.Play("BotCogSuccess");
                bottomPathOpen = true;
            }
            else
            {
                botCogAnimator.Play("BotCogEmpty");
            }
        }
    }

    public void MiddleValve()
    {
        if(topPathOpen == true && bottomPathOpen == true)
        {
            middleBlockAnimator.Play("SuccessOpenDoor");
            overallDoorAnimator.Play("OpenDoor");
        }
        else
        {
            middleBlockAnimator.Play("FailureMiddlePart");
            overallDoorAnimator.Play("FailureDoorFrame");
        }
    }

    public void BottomCogPicked()
    {
        
        if (cogInHand == true)
        {
            movingCogAnimator.Play("BottomCogPlaced");
            cogInHand = false;
            movingCogOnBot = true;
        }
        else
        {
            if (movingCogOnBot)
            {
                movingCogAnimator.Play("BottomCogPickedUp");
                cogInHand = true;
                movingCogOnBot = false;
            }
        }

    }

    public void TopCogPicked()
    {
        if(cogInHand == true)
        {
            movingCogAnimator.Play("TopCogPlaced");
            cogInHand = false;
            movingCogOnTop = true;
        }
        else
        {
            if (movingCogOnTop)
            {
                movingCogAnimator.Play("TopCogPickedUp");
                cogInHand = true;
                movingCogOnTop = false;
            }
        }
    }
}
