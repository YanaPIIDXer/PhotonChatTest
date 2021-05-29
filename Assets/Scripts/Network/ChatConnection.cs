using System.Collections;
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
        /// 接続された時のSubject
        /// </summary>
        private Subject<Unit> OnConnectSubject = new Subject<Unit>();

        /// <summary>
        /// 接続された
        /// </summary>
        public IObservable<Unit> OnConnect { get { return OnConnectSubject; } }

        /// <summary>
        /// チャンネルをSubscribeした時のSubject
        /// </summary>
        private Subject<ChatChannel> OnSubscribeChannelSubject = new Subject<ChatChannel>();

        /// <summary>
        /// チャンネルをSubscribeした
        /// </summary>
        public IObservable<ChatChannel> OnSubscribeChannel { get { return OnSubscribeChannelSubject; } }

        /// <summary>
        /// 接続
        /// </summary>
        public void Connect()
        {
            // 一旦Disconnect
            Disconnect();

            var Listener = new ChatClientListener();

            Listener.OnConnect = () => OnConnectSubject.OnNext(Unit.Default);
            Listener.OnSubscribeChannel = (Channel) =>
            {
                var Ch = Client.PublicChannels[Channel];
                OnSubscribeChannelSubject.OnNext(Ch);
            };

            Client = new ChatClient(Listener);
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

        /// <summary>
        /// チャンネルのSubscribe
        /// </summary>
        /// <param name="ChannelName">チャンネル名</param>
        public void SubscribeChannel(string ChannelName)
        {
            if (Client == null) { return; }
            Client.Subscribe(ChannelName);
        }

        /// <summary>
        /// メッセージ送信
        /// </summary>
        /// <param name="ChannelName">チャンネル名</param>
        /// <param name="Message">メッセージ</param>
        public void SendMessage(string ChannelName, string Message)
        {
            if (Client == null) { return; }
            Client.PublishMessage(ChannelName, Message);
        }

        #region Singleton
        public static ChatConnection Instance { get { return _Instance; } }
        private static ChatConnection _Instance = new ChatConnection();
        private ChatConnection() { }
        #endregion
    }
}
