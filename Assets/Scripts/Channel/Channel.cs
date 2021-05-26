using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;

namespace Channel
{
    /// <summary>
    /// チャンネルクラス
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// チャンネル名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="Src">Photonが定義したチャンネルクラス</param>
        public Channel(ChatChannel Src)
        {
            Name = Src.Name;
        }
    }
}
