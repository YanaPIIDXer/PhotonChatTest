﻿using System.Collections;
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
        /// 現在のチャンネル
        /// </summary>
        private string CurrentChannel = "";

        /// <summary>
        /// チャンネルを購読した
        /// </summary>
        public IObservable<string> OnSubscribeChannel => SubscribeForm.OnSubscribe;

        /// <summary>
        /// チャンネルを選択した
        /// </summary>
        public IObservable<string> OnSelectChannel => SubscribeList.OnSelectChannel;

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
            MsgView.Add(Messages);
        }

        void Awake()
        {
            OnSelectChannel.Subscribe((Name) => CurrentChannel = Name);
        }
    }
}
