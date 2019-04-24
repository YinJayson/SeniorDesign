using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItem
{

    public string equipName { get; set; }
    public string equipDescription { get; set; }
    public int equipID { get; set; }

    public EquipmentItem()
    {
        equipName = "";
        equipDescription = "";
        equipID = 0;
    }
    public EquipmentItem(string equipName, string equipDescription, int equipID)
    {
        this.equipName = equipName;
        this.equipDescription = equipDescription;
        this.equipID = equipID;
    }

    /* Methods to be overridden by inheriting classes */
    public virtual int getAtk()
    {
        return -1;
    }
    public virtual bool getAtkType()
    {
        return false;
    }
    public virtual int getDefense()
    {
        return -1;
    }
    public virtual int getResist()
    {
        return -1;
    }
}
