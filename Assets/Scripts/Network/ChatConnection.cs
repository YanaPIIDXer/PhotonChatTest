﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;
using UniRx;
using UniRx.Operators;
using Environments;
using System;

namespace Network
{
    /// <summary>
    /// PhotonChatとの接続
    /// </summary>
    public class ChatConnection
    {
        /// <summary>
        /// ChatClient
        /// </summary>
        private ChatClient Client = null;

        /// <summary>
        /// ClientのServiceメソッドを呼び続けるObservable
        /// </summary>
        private IDisposable ServiceDisposable = null;

        /// <summary>
        /// 接続
        /// </summary>
        public void Connect()
        {
            Client = new ChatClient(new ChatClientListener());
            Client.Connect(EnvironmentVariables.Insatnce.ApplicationId, "1.0", null);
            ServiceDisposable = Observable.Interval(TimeSpan.FromMilliseconds(1000.0 / 60))
                      .Subscribe((_) => Client.Service());
        }

        /// <summary>
        /// 切断
        /// </summary>
        public void Disconnect()
        {
            if (Client != null)
            {
                ServiceDisposable.Dispose();
                ServiceDisposable = null;

                Client.Disconnect();
                Client = null;
            }
        }

        #region Singleton
        public static ChatConnection Intsance { get { return _Instance; } }
        private static ChatConnection _Instance = new ChatConnection();
        private ChatConnection() { }
        #endregion
    }
}