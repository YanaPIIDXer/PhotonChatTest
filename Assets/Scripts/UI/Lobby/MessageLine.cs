using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Lobby
{
    /// <summary>
    /// メッセージ
    /// </summary>
    public class MessageLine : MonoBehaviour
    {
        /// <summary>
        /// Prefabのパス
        /// </summary>
        private static readonly string PrefabPath = "Prefabs/UI/MessageLine";

        /// <summary>
        /// Prefab
        /// </summary>
        private static GameObject Prefab = null;

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="Message">メッセージ</param>
        /// <returns>MessageLine</returns>
        public static MessageLine Create(object Message)
        {
            if (Prefab == null)
            {
                Prefab = Resources.Load<GameObject>(PrefabPath);
                Debug.Assert(Prefab != null, "MessageLine Prefab is null! Path:" + PrefabPath);
            }
            var Obj = Instantiate(Prefab);
            var MsgLine = Obj.GetComponent<MessageLine>();
            MsgLine.Set(Message);
            return MsgLine;
        }

        /// <summary>
        /// セット
        /// </summary>
        /// <param name="Message">メッセージ</param>
        private void Set(object Message)
        {
            GetComponent<Text>().text = Message.ToString();
        }
    }
}
