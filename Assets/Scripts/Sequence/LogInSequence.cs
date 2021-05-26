using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.LogIn;
using Zenject;
using UniRx;
using System;
using Network;

namespace Sequence
{
    /// <summary>
    /// ログインシーケンス
    /// </summary>
    public class LogInSequence : MonoBehaviour
    {
        /// <summary>
        /// ログインボタンの処理
        /// </summary>
        /// <param name="Btn">ログインボタンインタフェース</param>
        [Inject]
        private void OnLogInButton(ILogInButton Btn)
        {
            ChatConnection.Intsance.OnConnect
                                   .Subscribe((_) =>
                                   {
                                       Debug.Log("LogIn Success!!");
                                       Debug.Log("TODO:シーン遷移");
                                   });
            Btn.OnPress
               .Subscribe((_) => ChatConnection.Intsance.Connect());
        }
    }
}
