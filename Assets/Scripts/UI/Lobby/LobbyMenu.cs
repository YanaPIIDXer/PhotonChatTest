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
        /// チャンネルを購読した
        /// </summary>
        public IObservable<string> OnSubscribeChannel => SubscribeForm.OnSubscribe;

        /// <summary>
        /// 購読成功
        /// </summary>
        /// <param name="SubscribedChannel">購読したチャンネル</param>
        public void OnSubscribeSuccess(IChannel SubscribedChannel)
        {
            SubscribeForm.ResetChannelNameInput();
            SubscribeList.Add(SubscribedChannel.Name);
        }
    }
}
