using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        }
    }
}
