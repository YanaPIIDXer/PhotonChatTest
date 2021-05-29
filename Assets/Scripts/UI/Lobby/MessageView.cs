using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Lobby
{
    /// <summary>
    /// メッセージビュー
    /// </summary>
    public class MessageView : MonoBehaviour
    {
        /// <summary>
        /// View
        /// </summary>
        private ScrollRect ListView = null;

        void Awake()
        {
            ListView = GetComponent<ScrollRect>();
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="Message">メッセージ</param>
        public void Add(object Message)
        {
            var Line = MessageLine.Create(Message);
            Line.transform.SetParent(ListView.content);
            Line.transform.localPosition = Vector3.zero;
        }

        /// <summary>
        /// 追加
        /// </summary>
        /// <param name="Messages">メッセージリスト</param>
        public void AddList(object[] Messages)
        {
            foreach (var Msg in Messages)
            {
                Add(Msg);
            }
        }

        /// <summary>
        /// クリア
        /// </summary>
        public void Clear()
        {
            for (var i = ListView.content.childCount - 1; i >= 0; i--)
            {
                var Child = ListView.content.GetChild(i);
                Destroy(Child.gameObject);
            }
        }
    }
}
