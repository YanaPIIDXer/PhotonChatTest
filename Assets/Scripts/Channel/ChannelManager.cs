using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

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
        /// 購読時のSubject
        /// </summary>
        private Subject<Channel> OnSubscribeSubject = new Subject<Channel>();

        /// <summary>
        /// 購読した
        /// </summary>
        public IObservable<Channel> OnSubscribe { get { return OnSubscribeSubject; } }

        /// <summary>
        /// 購読解除Subject
        /// </summary>
        private Subject<Channel> OnUnsubscribeSubject = new Subject<Channel>();

        /// <summary>
        /// 購読を解除した
        /// </summary>
        public IObservable<Channel> OnUnsubscribe { get { return OnUnsubscribeSubject; } }

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
            if (Exists(NewChannel.Name)) { return; }
            ChannelDic[NewChannel.Name] = NewChannel;
            OnSubscribeSubject.OnNext(NewChannel);
        }

        /// <summary>
        /// チャンネル削除
        /// </summary>
        /// <param name="ChannelName">チャンネル名</param>
        public void Remove(string ChannelName)
        {
            if (!Exists(ChannelName)) { return; }
            var Ch = ChannelDic[ChannelName];
            ChannelDic.Remove(ChannelName);
            OnUnsubscribeSubject.OnNext(Ch);
        }

        /// <summary>
        /// 指定したチャンネルは存在するか？
        /// </summary>
        /// <param name="ChannelName">チャンネル名</param>
        /// <returns>存在するならtrue</returns>
        public bool Exists(string ChannelName)
        {
            return ChannelDic.ContainsKey(ChannelName);
        }
    }
}
