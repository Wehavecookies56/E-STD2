using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType {
    OPEN, PICKUP, TOUCH, TALK, SEARCH, FLIP, CLOSE, BURN
}

[CreateAssetMenu(fileName = "Data", menuName = "CustomData/InteractiveObject", order = 1)]
public class objectScriptable : ScriptableObject {
    [SerializeField]
    private string objectName;
    [SerializeField]
    private ObjectType type;

    public string ObjectName {
        get {
            return objectName;
        }
    }

    public ObjectType Type {
        get {
            return type;
        }
    }

}
