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
    }
}
