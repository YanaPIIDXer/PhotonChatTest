using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.LogIn;
using Zenject;
using UniRx;
using System;
using Network;
using UnityEngine.SceneManagement;

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
                                       SceneManager.LoadScene("Lobby");
                                   });
            Btn.OnPress
               .Subscribe((_) => ChatConnection.Intsance.Connect());
        }
    }
}
