using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Texture2D))]
public class CursorScript : MonoBehaviour
{

    [SerializeField] Texture2D _cursorTexture;

    // Start is called before the first frame update
    void Start()
    {
     Cursor.SetCursor(_cursorTexture, Vector3.zero, CursorMode.ForceSoftware);
    }


}
