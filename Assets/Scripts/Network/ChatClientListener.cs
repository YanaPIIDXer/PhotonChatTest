using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;
using ExitGames.Client.Photon;
using System;

namespace Network
{
    /// <summary>
    /// 受信したメッセージの情報をまとめる構造体
    /// </summary>
    public struct RecvMessagePack
    {
        /// <summary>
        /// チャンネル名
        /// </summary>
        public string ChannelName;

        /// <summary>
        /// 送信者名
        /// </summary>
        public string[] Senders;

        /// <summary>
        /// メッセージ
        /// </summary>
        public object[] Messages;
    }

    /// <summary>
    /// イベントリスナ
    /// </summary>
    public class ChatClientListener : IChatClientListener
    {
        /// <summary>
        /// 接続された
        /// </summary>
        public Action OnConnect { set; private get; }

        /// <summary>
        /// チャンネルをSubscribeした
        /// </summary>
        public Action<string> OnSubscribeChannel { set; private get; }

        /// <summary>
        /// メッセージを受信した
        /// </summary>
        public Action<RecvMessagePack> OnRecvMessage { set; private get; }

        public void DebugReturn(DebugLevel level, string message)
        {
            if (level != DebugLevel.ERROR)
            {
                Debug.Log(string.Format("[{0}] : {1}", level.ToString(), message));
            }
            else
            {
                Debug.LogError("[ERROR] : " + message);
            }
        }

        public void OnChatStateChange(ChatState state)
        {
        }

        public void OnConnected()
        {
            OnConnect?.Invoke();
        }

        public void OnDisconnected()
        {
        }

        public void OnGetMessages(string channelName, string[] senders, object[] messages)
        {
            RecvMessagePack Pack = new RecvMessagePack
            {
                ChannelName = channelName,
                Senders = senders,
                Messages = messages
            };
            OnRecvMessage?.Invoke(Pack);
        }

        public void OnPrivateMessage(string sender, object message, string channelName)
        {
        }

        public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
        {
        }

        public void OnSubscribed(string[] channels, bool[] results)
        {
            for (int i = 0; i < channels.Length; i++)
            {
                if (results[i])
                {
                    OnSubscribeChannel?.Invoke(channels[i]);
                }
            }
        }

        public void OnUnsubscribed(string[] channels)
        {
        }

        public void OnUserSubscribed(string channel, string user)
        {
            DebugReturn(DebugLevel.INFO, "User Subscribe.");
            DebugReturn(DebugLevel.INFO, "Channel:" + channel);
            DebugReturn(DebugLevel.INFO, "User:" + user);
        }

        public void OnUserUnsubscribed(string channel, string user)
        {
            DebugReturn(DebugLevel.INFO, "User Unsubscribe.");
            DebugReturn(DebugLevel.INFO, "Channel:" + channel);
            DebugReturn(DebugLevel.INFO, "User:" + user);
        }
    }
}
