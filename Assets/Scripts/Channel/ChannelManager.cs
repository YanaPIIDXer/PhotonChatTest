using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Channel
{
    /// <summary>
    /// チャンネル管理クラス
    /// </summary>
    public class ChannelManager
    {
        /// <summary>
        /// チャンネル名をキーにしたチャンネルのDictionary
        /// </summary>
        private Dictionary<string, Channel> ChannelDic = new Dictionary<string, Channel>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ChannelManager()
        {
        }

        /// <summary>
        /// チャンネル追加
        /// </summary>
        /// <param name="NewChannel">チャンネル</param>
        public void Add(Channel NewChannel)
        {
            ChannelDic[NewChannel.Name] = NewChannel;
        }
    }
}
