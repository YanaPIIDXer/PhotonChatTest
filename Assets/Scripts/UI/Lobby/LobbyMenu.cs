using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

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
        /// チャンネルを購読した
        /// </summary>
        public IObservable<string> OnSubscribeChannel => SubscribeForm.OnSubscribe;
    }
}
