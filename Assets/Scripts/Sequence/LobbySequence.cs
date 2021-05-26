using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;
using UniRx;
using System;

namespace Sequence
{
    /// <summary>
    /// ロビー画面シーケンス
    /// </summary>
    public class LobbySequence : MonoBehaviour
    {
        void Awake()
        {
            /*
            ChatConnection.Instance.OnsSubscribeChannel
                    .Subscribe((Ch) => Debug.Log(Ch.Name))
                    .AddTo(gameObject);

            ChatConnection.Instance.SubscribeChannel("Test");
            */
        }
    }
}