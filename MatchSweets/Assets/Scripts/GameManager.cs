using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public enum SweetsType
    {
        EMPTY,
        NORMAL,
        BARRIER,
        ROW_CLEAR,
        COLUMN_CLEAR,
        RAINBOWCANDY,
        COUNT
    }

    //游戏字典
    public Dictionary<SweetsType, GameObject> sweetPrefabDict;

    [Serializable]
    public struct SweetPrefab
    {
        public SweetsType type;
        public GameObject prefab;
    }

    public SweetPrefab[] sweetPrefabs;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    public int xColumn;
    public int yRow;

    public GameObject gridPrefab;

    private GameSweet[,] sweets;
    void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        sweetPrefabDict = new Dictionary<SweetsType, GameObject>();
        for(int i = 0; i < sweetPrefabs.Length; i++)
        {
            if(!sweetPrefabDict.ContainsKey(sweetPrefabs[i].type))
            {
                sweetPrefabDict.Add(sweetPrefabs[i].type, sweetPrefabs[i].prefab);
            }
        }

        for(int x = 0; x < xColumn; x++ )
        {
            for (int y = 0; y < yRow; y++)
            {
                GameObject chocolate = Instantiate(gridPrefab, CorrectPosition(x, y), Quaternion.identity);
                chocolate.transform.SetParent(transform);
            }
        }

        sweets = new GameSweet[xColumn, yRow];
        for(int x = 0; x < xColumn; x++ )
        {
            for (int y = 0; y < yRow; y++)
            {
                GameObject newSweet = Instantiate(sweetPrefabDict[SweetsType.NORMAL], CorrectPosition(x, y), Quaternion.identity);
                newSweet.transform.SetParent(transform);

                sweets[x, y] = newSweet.GetComponent<GameSweet>();
                sweets[x, y].Init(x, y, this, SweetsType.NORMAL);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 CorrectPosition(int x, int y)
    {
        //实际需要实例化巧克力块的X位置=GameManager位置的x坐标-大网格的长度的一半+行列对应的x坐标
        //实际需要实例化巧克力块的Y位置=GameManager位置的y坐标-大网格的长度的一半+行列对应的y坐标
        return new Vector3(transform.position.x - xColumn / 2f + x,
        transform.position.y - yRow / 2f + y, 0);
    }
}
