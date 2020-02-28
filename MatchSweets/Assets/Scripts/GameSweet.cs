using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSweet : MonoBehaviour
{
    public int x {get;
        set
        {
            if(CanMove()){ x = value; }
        }
    }
    public int y {get; 
        set
        {
            if(CanMove()) { y = value; }
        }
    }
    public GameManager.SweetsType type {get; set;}
    public GameManager gameManager{get; set;}
    public MoveSweet movedComponent{get;}

    public bool CanMove()
    {
        return movedComponent != null;
    }

    public void Init(int x, int y, GameManager gameManager, GameManager.SweetsType type)
    {
        this.x = x;
        this.y = y;
        this.gameManager = gameManager;
        this.type = type;
    }

}
