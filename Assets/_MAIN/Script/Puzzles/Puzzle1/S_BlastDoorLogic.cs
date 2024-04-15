using System.Collections;
using UnityEngine;


    public class S_BlastDoorLogic : MonoBehaviour
    {


        public bool movingCogOnTop = false;
        public bool movingCogOnBot = false;
        public bool topPathOpen = false;
        public bool bottomPathOpen = false;
        public bool cogInHand = false;
        public bool isLocked = true;
        public bool puzzleIsDone = false;
        public Animator topCogAnimator, botCogAnimator, overallDoorAnimator, middleBlockAnimator, movingCogAnimator;
        [SerializeField]
        private AudioSource cranck1, cranck2, cranck3, cranck4, cranck5 ,cranck6, doorAudioOpen;

        [SerializeField]
        private GameObject doorUi;

        [SerializeField]
        private S_BlastDoor blastDoorInteractionBehaviour;
        public void TopValve()
        {
            if (topPathOpen == false)
            {
                if (movingCogOnTop)
                {
                    topCogAnimator.Play("EngrennageTopSuccess");
                    movingCogAnimator.Play("TopCogSuccess");

                    cranck4.Play();
                    cranck5.Play();
                    topPathOpen = true;
                }
                else
                {
                    topCogAnimator.Play("EngrenageEmpty");
                    cranck5.Play();

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
                    cranck4.Play();
                    cranck5.Play();
                    bottomPathOpen = true;
                }
                else
                {
                    botCogAnimator.Play("EmptyEngrenange");
                    cranck5.Play();

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
                    cranck6.Play();
                    isLocked = false;
                }
                else
                {
                    cranck1.Play();
                    middleBlockAnimator.Play("BarreFermetureOpenFailure");
                    overallDoorAnimator.Play("EchecOuverturePorte");
                }
            }
            else
            {
                overallDoorAnimator.Play("OuverturePorte");
                doorAudioOpen.Play();
                puzzleIsDone = true;
                doorUi.SetActive(false);
                if (cogInHand)
                {
                movingCogAnimator.Play("TopCogPlaced");
                cranck2.Play();

                }
        }

        }

        public void BottomCogPicked()
        {

            if (cogInHand == true)
            {
                movingCogAnimator.Play("BotCogPlaced");
                cranck2.Play();

                cogInHand = false;
                movingCogOnBot = true;
            }
            else
            {
                if (movingCogOnBot)
                {
                    movingCogAnimator.Play("BotCogPicked");
                    cranck3.Play();
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
                cranck2.Play();
                cogInHand = false;
                movingCogOnTop = true;
            }
            else
            {
                if (movingCogOnTop)
                {
                    movingCogAnimator.Play("TopCogPicked");
                    cranck3.Play();
                    cogInHand = true;
                    movingCogOnTop = false;
                }
            }
        }


    }
