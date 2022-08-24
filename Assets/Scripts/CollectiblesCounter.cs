using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectiblesCounter : MonoBehaviour
{
    public static int TotalPoints = 0;
    [SerializeField] private int _collectibleAmount;

    [SerializeField] TMP_FontAsset _fontCollectible;
    
    public TextMeshProUGUI TargetCount;
    //public TextMeshProUGUI StartMessage;

    private void Start()
    {
        
        SetCountText();
        //StartCoroutine(FadeCoroutine());
    }

    void FixedUpdate()
    {
        SetCountText();
    }

    void SetCountText()
    {
        TargetCount.font = _fontCollectible;
        TargetCount.text = "Wasabi: " + TotalPoints.ToString() + " / " + _collectibleAmount;
    }

    /*IEnumerator FadeCoroutine()
    {
        float _waitTime = 3;
        while (_waitTime > 0)
        {
            StartMessage.fontMaterial.SetColor("_FaceColor", Color.Lerp(Color.clear, Color.white, _waitTime));
            yield return null;
            _waitTime -= Time.deltaTime;
        }

        if (_waitTime <=0)
        {
            StartMessage.enabled = false;
        }

    }*/
}