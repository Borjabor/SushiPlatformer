using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{


    [SerializeField]
    private GameObject _dashIntruction;

    [SerializeField]
    private GameObject _doubleJumpInstruction;

    [SerializeField]
    private GameObject _wallClimbInstruction;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ShrimpBuff"))
        {
            _dashIntruction.SetActive(true);
            Invoke("SetFalse", 4.0f);
        }

        if (other.gameObject.CompareTag("DoubleJump"))
        {
            _doubleJumpInstruction.SetActive(true);
            Invoke("SetFalse", 4.0f);
        }

        if (other.gameObject.CompareTag("WallJump"))
        {
            _wallClimbInstruction.SetActive(true);
            Invoke("SetFalse", 4.0f);
        }

    }

    private void SetFalse()
    {
        _dashIntruction.SetActive(false);
        _doubleJumpInstruction.SetActive(false);
        _wallClimbInstruction.SetActive(false);
    }


}
