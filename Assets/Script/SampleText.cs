using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SampleText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textUi = default;

    void Start()
    {
        _textUi.text = "Stand by Ready!";
    }

    void Update()
    {
        
    }
}
