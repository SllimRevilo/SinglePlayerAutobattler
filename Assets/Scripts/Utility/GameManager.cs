using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public MoveableObjectManager moveableObjectManager;
    public HexGrid hexGrid;
}