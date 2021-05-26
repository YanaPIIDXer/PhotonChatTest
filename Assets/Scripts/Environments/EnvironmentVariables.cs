using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environments
{
    /// <summary>
    /// 環境変数定義
    /// Githubで公開してはいけない値を扱うクラス
    /// </summary>
    public partial class EnvironmentVariables
    {
        /// <summary>
        /// アプリケーションＩＤ
        /// </summary>
        public string ApplicationId { get; private set; }

        #region Singleton
        public static EnvironmentVariables Insatnce { get { return _Instance; } }
        private static EnvironmentVariables _Instance = new EnvironmentVariables();
        #endregion
    }
}
