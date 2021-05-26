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
    /// チャンネル購読フォーム
    /// </summary>
    public class ChannelSubscribe : MonoBehaviour
    {
        /// <summary>
        /// チャンネル名
        /// </summary>
        [SerializeField]
        private InputField ChannelNameInput = null;

        /// <summary>
        /// 購読ボタン
        /// </summary>
        [SerializeField]
        private Button SubscribeButton = null;

        /// <summary>
        /// 購読ボタンが押された
        /// </summary>
        public IObservable<string> OnSubscribe
        {
            get
            {
                return SubscribeButton.OnClickAsObservable()
                               .Select((_) => ChannelNameInput.text);
            }
        }

        void Awake()
        {
            ChannelNameInput.OnValueChangedAsObservable()
                            .Select((Value) => string.IsNullOrEmpty(Value))
                            .Subscribe((IsEmpty) => SubscribeButton.interactable = !IsEmpty)
                            .AddTo(gameObject);
        }

        /// <summary>
        /// チャンネル名入力Inputのリセット
        /// </summary>
        public void ResetChannelNameInput()
        {
            ChannelNameInput.text = "";
        }
    }
}
