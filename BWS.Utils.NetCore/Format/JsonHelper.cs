using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace BWS.Utils.NetCore.Format {

    /// <summary>
    /// Json Helper.
    /// </summary>
    public static class JsonHelper {
        /// <summary>
        /// Object To json string.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="data">Data model to convert to JSON</param>
        /// <returns>JSON serialized string of data model</returns>
        public static string ToJson<T>(T data) {
            try {
                return JsonConvert.SerializeObject(data);
            }catch(Exception e) {
                throw new Exception("failed to seriailze.", e);
            }
        }

        /// <summary>
        /// String value to typed-instance.
        /// </summary>
        /// <typeparam name="T">Type to convert to</typeparam>
        /// <param name="json">JSON serialized object to convert from</param>
        /// <returns>Object deserialized from JSON</returns>
        public static T FromJson<T>(string json) {
            try {
                return JsonConvert.DeserializeObject<T>(json);
            } catch (Exception ex) {
                throw new Exception("failed to read from JSON: " + json, ex);
            }
        }
    }
}
