using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

namespace UI.LogIn
{
    /// <summary>
    /// ログインボタンインタフェース
    /// </summary>
    public interface ILogInButton
    {
        /// <summary>
        /// 押された
        /// </summary>
        IObservable<Unit> OnPress { get; }
    }

    /// <summary>
    /// ログインボタン
    /// </summary>
    public class LogInButton : MonoBehaviour, ILogInButton
    {
        /// <summary>
        /// ボタン
        /// ※ネーミングどうにかならない・・・？
        /// </summary>
        private Button MyButton = null;

        /// <summary>
        /// 押された
        /// </summary>
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

        void Awake()
        {
            OnPress
                .Subscribe((_) => MyButton.interactable = false)
                .AddTo(gameObject);
        }
    }
}
