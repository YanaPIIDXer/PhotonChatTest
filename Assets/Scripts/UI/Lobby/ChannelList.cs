using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;

namespace UI.Lobby
{
    /// <summary>
    /// チャンネルリスト
    /// </summary>
    public class ChannelList : MonoBehaviour
    {
        /// <summary>
        /// リストビュー
        /// </summary>
        private ScrollRect ListView = null;

        /// <summary>
        /// 名前に対応するボタンのDictionary
        /// </summary>
        private Dictionary<string, ChannelButton> ButtonDic = new Dictionary<string, ChannelButton>();

        void Awake()
        {
            ListView = GetComponent<ScrollRect>();
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="ChannelName">チャンネル名</param>
        public void Add(string ChannelName)
        {
            var ChBtn = ChannelButton.Create(ChannelName);
            ChBtn.transform.SetParent(ListView.content);
            ChBtn.transform.localPosition = Vector3.zero;
            ChBtn.Selected = false;
            ButtonDic[ChannelName] = ChBtn;

            ChBtn.OnPress
                 .Subscribe((Name) =>
                 {
                     foreach (var Kv in ButtonDic)
                     {
                         Kv.Value.Selected = Kv.Key == Name;
                     }
                 });
        }
    }
}
