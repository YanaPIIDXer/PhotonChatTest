using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;
using UniRx;
using UniRx.Operators;

namespace Network
{
    /// <summary>
    /// PhotonChatとの接続
    /// </summary>
    public class ChatConnection
    {
        /// <summary>
        /// 接続
        /// </summary>
        public void Connect()
        {
        }

        /// <summary>
        /// 切断
        /// </summary>
        public void Disconnect()
        {
        }

        #region Singleton
        public static ChatConnection Intsance { get { return _Instance; } }
        private static ChatConnection _Instance = new ChatConnection();
        private ChatConnection() { }
        #endregion
    }
}
