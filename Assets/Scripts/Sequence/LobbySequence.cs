using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;
using UniRx;
using System;
using Channel;

namespace Sequence
{
    /// <summary>
    /// ロビー画面シーケンス
    /// </summary>
    public class LobbySequence : MonoBehaviour
    {
        /// <summary>
        /// チャンネル管理
        /// </summary>
        private ChannelManager ChannelMgr = new ChannelManager();

        void Awake()
        {
            ChatConnection.Instance.OnSubscribeChannel
                    .Subscribe((Ch) =>
                    {
                        if (ChannelMgr.Exists(Ch.Name))
                        {
                            Debug.LogError(Ch.Name + " is exists.");
                            return;
                        }
                        var NewChannel = new Channel.Channel(Ch);
                        ChannelMgr.Add(NewChannel);
                    })
                    .AddTo(gameObject);
        }
    }
}
