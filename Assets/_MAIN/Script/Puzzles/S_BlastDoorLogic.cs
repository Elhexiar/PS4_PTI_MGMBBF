using System.Collections;
using UnityEngine;

namespace Assets._MAIN.Script.Puzzles
{
    public class S_BlastDoorLogic : MonoBehaviour
    {


        public bool movingCogOnTop = false;
        public bool movingCogOnBot = false;
        public bool topPathOpen = false;
        public bool bottomPathOpen = false;
        public bool cogInHand = false;
        public bool isLocked = true;
        public Animator topCogAnimator, botCogAnimator, overallDoorAnimator, middleBlockAnimator, movingCogAnimator;


        public void TopValve()
        {
            if (topPathOpen == false)
            {
                if (movingCogOnTop)
                {
                    topCogAnimator.Play("EngrennageTopSuccess");
                    movingCogAnimator.Play("TopCogSuccess");
                    topPathOpen = true;
                }
                else
                {
                    topCogAnimator.Play("EngrenageEmpty");
                }
            }
        }

        public void BotValve()
        {
            if (bottomPathOpen == false)
            {
                if (movingCogOnBot)
                {
                    botCogAnimator.Play("EngrenageBotSuccess");
                    movingCogAnimator.Play("BotCogSuccess");
                    bottomPathOpen = true;
                }
                else
                {
                    botCogAnimator.Play("Emptyengrenange");
                }
            }
        }

        public void MiddleValve()
        {
            if (isLocked)
            {
                if (topPathOpen == true && bottomPathOpen == true)
                {
                    middleBlockAnimator.Play("BarreFermetureOpenSuccess");
                    isLocked = false;
                }
                else
                {
                    middleBlockAnimator.Play("BarreFermetureOpenFailure");
                    overallDoorAnimator.Play("EchecOuverturePorte");
                }
            }
            else
            {
                overallDoorAnimator.Play("OuverturePorte");
            }

        }

        public void BottomCogPicked()
        {

            if (cogInHand == true)
            {
                movingCogAnimator.Play("BotCogPlaced");
                cogInHand = false;
                movingCogOnBot = true;
            }
            else
            {
                if (movingCogOnBot)
                {
                    movingCogAnimator.Play("BotCogPicked");
                    cogInHand = true;
                    movingCogOnBot = false;
                }
            }

        }

        public void TopCogPicked()
        {
            if (cogInHand == true)
            {
                movingCogAnimator.Play("TopCogPlaced");
                cogInHand = false;
                movingCogOnTop = true;
            }
            else
            {
                if (movingCogOnTop)
                {
                    movingCogAnimator.Play("TopCogPicked");
                    cogInHand = true;
                    movingCogOnTop = false;
                }
            }
        }

        public void Test(string anim)
        {
            movingCogAnimator.Play(anim);
        }


    }
}