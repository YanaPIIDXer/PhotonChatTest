using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

namespace UI.Lobby
{
    /// <summary>
    /// 発言情報
    /// </summary>
    public struct MessageInfo
    {
        /// <summary>
        /// チャンネル名
        /// </summary>
        public string ChannelName;

        /// <summary>
        /// 発言内容
        /// </summary>
        public string Message;
    }
    /// <summary>
    /// 発言ユニット
    /// </summary>
    public class SayUnit : MonoBehaviour
    {
        /// <summary>
        /// メッセージ入力欄
        /// </summary>
        [SerializeField]
        private InputField MessageInput = null;

        /// <summary>
        /// 発言ボタン
        /// </summary>
        [SerializeField]
        private Button SayButton = null;

        /// <summary>
        /// 発言した
        /// </summary>
        public IObservable<MessageInfo> OnSay
        {
            get
            {
                return SayButton.OnClickAsObservable()
                         .Select((_) => new MessageInfo()
                         {
                             ChannelName = CurrentChannel,
                             Message = MessageInput.text
                         });
            }
        }

        /// <summary>
        /// 現在のチャンネル名
        /// </summary>
        public string CurrentChannel
        {
            get { return _CurrentChannel; }
            set
            {
                _CurrentChannel = value;
                MessageInput.interactable = !string.IsNullOrEmpty(_CurrentChannel);
            }
        }
        private string _CurrentChannel = "";

        void Awake()
        {
            CurrentChannel = "";
            MessageInput.OnValueChangedAsObservable()
                        .Select((Value) => string.IsNullOrEmpty(Value))
                        .Subscribe((IsEmpty) => SayButton.interactable = !IsEmpty)
                        .AddTo(gameObject);
        }
    }
}
