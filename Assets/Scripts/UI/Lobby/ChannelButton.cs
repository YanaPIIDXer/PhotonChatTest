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
    /// チャンネルボタン
    /// </summary>
    public class ChannelButton : MonoBehaviour
    {
        /// <summary>
        /// Prefabのパス
        /// </summary>
        private static readonly string PrefabPath = "Prefabs/UI/ChannelButton";

        /// <summary>
        /// Prefab
        /// </summary>
        private static GameObject Prefab = null;

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="ChannelName">チャンネル名</param>
        /// <returns>ボタン</returns>
        public static ChannelButton Create(string ChannelName)
        {
            if (Prefab == null)
            {
                Prefab = Resources.Load<GameObject>(PrefabPath);
                Debug.Assert(Prefab != null, "Channel Button Prefab is NULL! Path:" + PrefabPath);
            }

            var Obj = Instantiate(Prefab);
            var BtnCmp = Obj.GetComponent<ChannelButton>();
            BtnCmp.DisplayText.text = ChannelName;
            return BtnCmp;
        }

        /// <summary>
        /// 表示テキスト
        /// </summary>
        [SerializeField]
        private Text DisplayText = null;

        /// <summary>
        /// 押された
        /// </summary>
        /// <value></value>
        public IObservable<Unit> OnPress
        {
            get
            {
                if (MyButton == null)
                {
                    MyButton = GetComponent<Button>();
                }
                return MyButton.OnClickAsObservable();
            }
        }

        /// <summary>
        /// ボタン
        /// HACK:ネーミング（ｒｙ
        /// </summary>
        private Button MyButton = null;
    }
}
