using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;
using UniRx;
using System;
using Channel;
using UI.Lobby;
using Zenject;

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

        /// <summary>
        /// ロビーメニュー
        /// </summary>
        [Inject]
        private ILobbyMenu LobbyMenu = null;

        void Awake()
        {
            ChannelMgr.OnSubscribe
                      .Subscribe((Ch) =>
                      {
                          LobbyMenu.OnSubscribeSuccess(Ch);
                      })
                      .AddTo(gameObject);

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

            ChatConnection.Instance.OnRecvMessage
                          .Subscribe((Pack) => LobbyMenu.OnRecvMessage(Pack.ChannelName, Pack.Messages))
                          .AddTo(gameObject);

            LobbyMenu.OnSubscribeChannel
                     .Subscribe((Name) => ChatConnection.Instance.SubscribeChannel(Name))
                     .AddTo(gameObject);

            LobbyMenu.OnSelectChannel
                     .Subscribe((Name) =>
                     {
                         List<object> Msgs = ChannelMgr.GetMessages(Name);
                         LobbyMenu.SetMessageList(Msgs);
                     })
                     .AddTo(gameObject);

            LobbyMenu.OnSay
                     .Subscribe((Info) => ChatConnection.Instance.SendMessage(Info.ChannelName, Info.Message))
                     .AddTo(gameObject);
        }
    }
}
