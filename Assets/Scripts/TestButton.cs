using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UniRx.Operators;
using Network;

/// <summary>
/// テスト用のボタン
/// 用が済んだら消す
/// </summary>
public class TestButton : MonoBehaviour
{
    void Awake()
    {
        var Btn = GetComponent<Button>();
        Btn.OnClickAsObservable()
            .Subscribe((_) => ChatConnection.Intsance.Connect())
            .AddTo(gameObject);
    }
}
