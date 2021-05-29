using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;

namespace Channel
{
    /// <summary>
    /// チャンネルインタフェース
    /// </summary>
    public interface IChannel
    {
        /// <summary>
        /// チャンネル名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// メッセージリスト
        /// </summary>
        List<object> Messages { get; }
    }

    /// <summary>
    /// チャンネルクラス
    /// </summary>
    public class Channel : IChannel
    {
        /// <summary>
        /// チャンネル名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// メッセージリスト
        /// </summary>
        public List<object> Messages { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="Src">Photonが定義したチャンネルクラス</param>
        public Channel(ChatChannel Src)
        {
            Name = Src.Name;
            Messages = Src.Messages;
        }
    }
}
