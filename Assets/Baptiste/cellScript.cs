using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cell : MonoBehaviour
{
    [SerializeField] private Image FB_filling;
    [SerializeField] public float fillAmmount;
    private float capacity = 100;
    [SerializeField] private cell OutflowA, OutflowB;
    private bool wichOutput, emptying;
    public bool source;
    private Direction directionA;
    [SerializeField] private Direction direction, directionB;
    [SerializeField] private bool interactible;
    [SerializeField] private bool dir;


    private void Start()
    {
        directionA = direction;
        if (!interactible)
        {
            Button button = GetComponent<Button>();
            button.enabled = false;
        }

        ChangeFlowDir();
    }

    /// <summary>
    /// swich the direction of the flow;
    /// </summary>
    public void SwitchDirection()
    {
        if (dir)
        {
            direction = directionB;
            dir = false;
        }
        else
        {
            direction = directionB;
            dir = true;
        }

        if (wichOutput) { wichOutput=false; }
        else { wichOutput = true; }   

        ChangeFlowDir();
    }

    public void switchWaterDirection()
    {

        switch (direction)
        {
            case Direction.up:
                direction = Direction.down; break;
            case Direction.down:
                direction = Direction.up; break;
            case Direction.left:
                direction = Direction.right; break;
            case Direction.right:
                direction = Direction.left; break;

            case Direction.LeftToUp:
                direction = Direction.UpToLeft; break;
            case Direction.LeftToDown:
                direction = Direction.DownToLeft; break;

            case Direction.UpToLeft:
                direction = Direction.LeftToUp; break;
            case Direction.UpToRight:
                direction = Direction.RightToUp; break;

            case Direction.RightToDown:
                direction = Direction.DownToRight; break;
            case Direction.RightToUp:
                direction = Direction.UpToRight; break;

            case Direction.DownToLeft:
                direction = Direction.LeftToDown; break;
            case Direction.DownToRight:
                direction = Direction.RightToDown; break;

        }

        ChangeFlowDir();
    }

    /// <summary>
    /// change the direction in wich the sprite fill in
    /// </summary>
    public void ChangeFlowDir()
    {
        switch (direction)
        {
            case Direction.up:
                FB_filling.fillMethod = Image.FillMethod.Vertical;
                FB_filling.fillOrigin = 0;
                break;
            case Direction.down:
                FB_filling.fillMethod = Image.FillMethod.Vertical;
                FB_filling.fillOrigin = 1;
                break;
            case Direction.right:
                FB_filling.fillMethod = Image.FillMethod.Horizontal;
                FB_filling.fillOrigin = 0;
                break;
            case Direction.left:
                FB_filling.fillMethod = Image.FillMethod.Horizontal;
                FB_filling.fillOrigin = 1;
                break;


            case Direction.LeftToUp:
                FB_filling.fillMethod = Image.FillMethod.Radial90;
                FB_filling.fillClockwise = false;
                FB_filling.fillOrigin = 1;
                break;
            case Direction.LeftToDown:
                FB_filling.fillMethod = Image.FillMethod.Radial90;
                FB_filling.fillClockwise = true;
                FB_filling.fillOrigin = 0;
                break;

            case Direction.UpToLeft:
                FB_filling.fillMethod = Image.FillMethod.Radial90;
                FB_filling.fillClockwise = true;
                FB_filling.fillOrigin = 1;
                break;
            case Direction.UpToRight:
                FB_filling.fillMethod = Image.FillMethod.Radial90;
                FB_filling.fillClockwise = false;
                FB_filling.fillOrigin = 2;
                break;

            case Direction.RightToUp:
                FB_filling.fillMethod = Image.FillMethod.Radial90;
                FB_filling.fillClockwise = true;
                FB_filling.fillOrigin = 2;
                break;
            case Direction.RightToDown:
                FB_filling.fillMethod = Image.FillMethod.Radial90;
                FB_filling.fillClockwise = false;
                FB_filling.fillOrigin = 3;
                break;

            case Direction.DownToRight:
                FB_filling.fillMethod = Image.FillMethod.Radial90;
                FB_filling.fillClockwise = true;
                FB_filling.fillOrigin = 3;
                break;
            case Direction.DownToLeft:
                FB_filling.fillMethod = Image.FillMethod.Radial90;
                FB_filling.fillClockwise = false;
                FB_filling.fillOrigin = 0;
                break;
        }
    }

    /// <summary>
    /// if this cell is full , fill the next one
    /// </summary>
    public void filling()
    {
        cell Outflow;

        if (!wichOutput) {  Outflow = OutflowA; }
        else {  Outflow = OutflowB;}

        if(fillAmmount >= capacity && !emptying) { emptying = true; switchWaterDirection(); }
        if(fillAmmount <= 0 && emptying) { emptying = false; switchWaterDirection(); }

        if (emptying && fillAmmount > 0)
        {
            if(Outflow != null)
            Outflow.fillAmmount++;
        }

        if (!source && emptying)
        {
            fillAmmount--;
        }

        FB_filling.fillAmount = fillAmmount/100;
    }

    enum Direction { up, down, left, right, LeftToUp, LeftToDown, UpToLeft, UpToRight, RightToUp, RightToDown, DownToLeft, DownToRight};
}
