using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSweet : MonoBehaviour
{
    private GameSweet sweet;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        sweet = GetComponent<GameSweet>();
    }

    public void Move(int newX, int newY)
    {
        sweet.x = newX;
        sweet.y = newY;
        sweet.transform.localPosition = sweet.gameManager.CorrectPosition(newX, newY);
    }

}
