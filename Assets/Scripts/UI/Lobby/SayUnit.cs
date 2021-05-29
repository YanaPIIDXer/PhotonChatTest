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
