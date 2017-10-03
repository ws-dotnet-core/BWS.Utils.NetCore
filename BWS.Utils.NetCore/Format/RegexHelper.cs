using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BWS.Utils.NetCore.Format {

    /// <summary>
    /// Regex extensions
    /// </summary>
    public static class RegexHelper {

        /// <summary>
        /// Math with a name.
        /// </summary>
        /// <param name="expre"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Match NamesMatch(string expre,string content) => new Regex(expre).Match(content);

        /// <summary>
        /// Math with all names in collection.
        /// </summary>
        /// <param name="expre"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static MatchCollection AllNamesMatch(string expre, string content) => new Regex(expre).Matches(content);

        /// <summary>
        /// Check if has the name-value pair.
        /// </summary>
        /// <param name="coll"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool HasValue(this Match coll,string name) => coll.Groups[name].Value != "";

        /// <summary>
        /// Get the name-value if exist , or return empty string value;
        /// </summary>
        /// <param name="coll"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string TryGet(this Match coll, string name) => coll.Groups[name].Value;

    }
}
