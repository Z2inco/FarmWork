using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���崴��ʵ����·��
[CreateAssetMenu(menuName ="Date/Item")]

public class Item : ScriptableObject
{
    //����
    public string Name;
    public bool stackable;
    public Sprite icon;

}
