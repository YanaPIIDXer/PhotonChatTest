using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;
using ExitGames.Client.Photon;

namespace Network
{
    /// <summary>
    /// イベントリスナ
    /// </summary>
    public class ChatClientListener : IChatClientListener
    {
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
            DebugReturn(DebugLevel.INFO, "ChatState:" + state.ToString());
        }

        public void OnConnected()
        {
            DebugReturn(DebugLevel.INFO, "OnConnected");
        }

        public void OnDisconnected()
        {
            DebugReturn(DebugLevel.INFO, "OnDisconnected");
        }

        public void OnGetMessages(string channelName, string[] senders, object[] messages)
        {
        }

        public void OnPrivateMessage(string sender, object message, string channelName)
        {
        }

        public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
        {
        }

        public void OnSubscribed(string[] channels, bool[] results)
        {
        }

        public void OnUnsubscribed(string[] channels)
        {
        }

        public void OnUserSubscribed(string channel, string user)
        {
        }

        public void OnUserUnsubscribed(string channel, string user)
        {
        }
    }
}
