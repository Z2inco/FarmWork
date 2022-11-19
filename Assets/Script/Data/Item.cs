using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//定义创建实例的路径
[CreateAssetMenu(menuName ="Data/Item")]

public class Item : ScriptableObject
{
    //变量
    public string Name;
    public bool stackable;
    public Sprite icon;

    public ToolAction onAction; //有动作
    public ToolAction onTileMapAction;
    public ToolAction onItemUsed;

}
