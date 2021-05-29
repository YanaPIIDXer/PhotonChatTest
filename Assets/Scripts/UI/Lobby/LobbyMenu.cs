using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Channel;

namespace UI.Lobby
{
    /// <summary>
    /// ロビーメニューインタフェース
    /// </summary>
    public interface ILobbyMenu
    {
        /// <summary>
        /// チャンネルを購読した
        /// </summary>
        IObservable<string> OnSubscribeChannel { get; }

        /// <summary>
        /// 行動性向
        /// </summary>
        /// <param name="SubscribedChannel">購読したチャンネル</param>
        void OnSubscribeSuccess(IChannel SubscribedChannel);

        /// <summary>
        /// チャンネルを選択した
        /// </summary>
        IObservable<string> OnSelectChannel { get; }

        /// <summary>
        /// メッセージリストをセット
        /// </summary>
        /// <param name="Messages">メッセージリスト</param>
        void SetMessageList(List<object> Messages);

        /// <summary>
        /// 発言した
        /// </summary>
        IObservable<MessageInfo> OnSay { get; }

        /// <summary>
        /// メッセージを受信した
        /// </summary>
        /// <param name="ChannelName">チャンネル名</param>
        /// <param name="Messages">メッセージリスト</param>
        void OnRecvMessage(string ChannelName, object[] Messages);
    }

    /// <summary>
    /// ロビーメニュー
    /// </summary>
    public class LobbyMenu : MonoBehaviour, ILobbyMenu
    {
        /// <summary>
        /// 購読フォーム
        /// </summary>
        [SerializeField]
        private ChannelSubscribe SubscribeForm = null;

        /// <summary>
        /// 購読リスト
        /// </summary>
        [SerializeField]
        private ChannelList SubscribeList = null;

        /// <summary>
        /// メッセージビュー
        /// </summary>
        [SerializeField]
        private MessageView MsgView = null;

        /// <summary>
        /// 発言Unit
        /// ※ネーミング（ｒｙ
        /// </summary>
        [SerializeField]
        private SayUnit Say = null;

        /// <summary>
        /// チャンネルを購読した
        /// </summary>
        public IObservable<string> OnSubscribeChannel => SubscribeForm.OnSubscribe;

        /// <summary>
        /// チャンネルを選択した
        /// </summary>
        public IObservable<string> OnSelectChannel => SubscribeList.OnSelectChannel;

        /// <summary>
        /// 発言した
        /// </summary>
        public IObservable<MessageInfo> OnSay => Say.OnSay;

        /// <summary>
        /// メッセージを受信した
        /// </summary>
        /// <param name="ChannelName">チャンネル名</param>
        /// <param name="Messages">メッセージリスト</param>
        public void OnRecvMessage(string ChannelName, object[] Messages)
        {
            // HACK:↓現在のチャンネル名を保持しているのがコイツなので
            if (Say.CurrentChannel == ChannelName)
            {
                MsgView.AddList(Messages);
            }
        }

        /// <summary>
        /// 購読成功
        /// </summary>
        /// <param name="SubscribedChannel">購読したチャンネル</param>
        public void OnSubscribeSuccess(IChannel SubscribedChannel)
        {
            SubscribeForm.ResetChannelNameInput();
            SubscribeList.Add(SubscribedChannel.Name);
        }

        /// <summary>
        /// メッセージリストをセット
        /// </summary>
        /// <param name="Messages">メッセージリスト</param>
        public void SetMessageList(List<object> Messages)
        {
            MsgView.Clear();
            MsgView.AddList(Messages.ToArray());
        }

        void Awake()
        {
            OnSelectChannel.Subscribe((Name) => Say.CurrentChannel = Name)
                           .AddTo(gameObject);
        }
    }
}
