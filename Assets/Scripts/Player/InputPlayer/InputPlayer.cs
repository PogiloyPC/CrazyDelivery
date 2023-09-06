using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer
{
    public bool GetKeyW() => Input.GetKey(KeyCode.W);
    public bool GetKeyS() => Input.GetKey(KeyCode.S);
    public bool GetKeyD() => Input.GetKey(KeyCode.D);
    public bool GetKeyA() => Input.GetKey(KeyCode.A);
}
