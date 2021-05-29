using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }
}
