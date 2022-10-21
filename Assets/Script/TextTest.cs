using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class TextTest : MonoBehaviour
{
    [SerializeField]
    Text _text;
    /// <summary>
    /// 登録する文章
    /// </summary>
    [SerializeField]
    string[] _texts;
    /// <summary>
    /// 分割された文字列の格納配列
    /// </summary>
    [SerializeField]
    string[] _words;
    /// <summary>
    /// ページ数
    /// </summary>
    [SerializeField]
    int _count = 0;

    [SerializeField]
    float _textSpeed = 0.1f;

    [SerializeField]
    bool _isShowText ;

    [SerializeField]
    bool _isSkipText;
    private void Start()
    {
        _text.text = null;
        //_words = _texts[_count].Select(x => x.ToString()).ToArray();
    }
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if(!_isShowText)
            {
                _count++;
                _text.text = null;
            }
            //_words = _texts[_count -1].Select(x => x.ToString()).ToArray();
        }

        if (Input.GetButtonDown("Fire2"))
        {

            if (!_isShowText && _text.text != _texts[_count])
            {

                StartCoroutine(aaa());

            }
        }

        if (_count >= _texts.Length || _count <= 0)
        {
            _count = 0;
        }
        if (Input.GetButtonDown("Fire3") && _isShowText)
        {
            _isSkipText = true;
        }

        //_text.text = _texts[_count];

        //if(_showText)
        //{
        //    if (Input.GetButtonDown("Fire2"))
        //    {
        //        _text.text = null;

        //        _text.text = _texts[_count];
        //        return;

        //    }
        //}

    }

    IEnumerator aaa()
    {

        _isShowText = true;

        //一文字ずつ分割
        _words = _texts[_count].Select(x => x.ToString()).ToArray();
        foreach (var word in _words)
        {
            if (_isShowText && _isSkipText)
            {
                Debug.Log("スキップ");
                _text.text = null;
                _text.text = _texts[_count];
                _isShowText = false;
                _isSkipText = false;
                yield break;
            }
            // 0.1秒刻みで１文字ずつ表示する。
            _text.text = _text.text + word;
            yield return new WaitForSeconds(_textSpeed);
        }

        _isShowText = false;

    }
}
