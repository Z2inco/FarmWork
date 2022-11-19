using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���崴��ʵ����·��
[CreateAssetMenu(menuName ="Data/Item")]

public class Item : ScriptableObject
{
    //����
    public string Name;
    public bool stackable;
    public Sprite icon;

    public ToolAction onAction; //�ж���
    public ToolAction onTileMapAction;
    public ToolAction onItemUsed;

}
