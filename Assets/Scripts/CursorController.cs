using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public static void EnableCursor()
    {
        Cursor.visible = true;
    }

    public static void DisableCursor()
    {
        Cursor.visible = false;
    }
}
