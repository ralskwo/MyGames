using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float _Sec;
    int _Min;

    public Text TimeText;

    void Update()
    {
        _Sec += Time.deltaTime;

        TimeText.text = string.Format("{0:D2} : {1:D2}", _Min, (int)_Sec);

        if (_Sec >= 60)
        {
            _Sec = 0;
            _Min++;
        }
    }

}
