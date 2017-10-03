using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BWS.Utils.NetCore.Format {

    /// <summary>
    /// Enum extensions
    /// </summary>
    public static class EnumHelper {

        /// <summary>
        /// Convert string value into enum instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T Parse<T>(string content) where T : struct
            => (T)Enum.Parse(typeof(T), content);

        /// <summary>
        /// Convert string value into enum instance, failed with a default value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T TryParse<T>(string content)where T: struct {
            var ok = Enum.TryParse(content, out T result);
            return ok ? result : default(T);
        }

        /// <summary>
        /// Convert hash value into enum instance, failed with a default value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashCode"></param>
        /// <returns></returns>
        public static T TryParseHash<T>(int hashCode) where T : struct {
            var values = TryGetValues<T>();
            foreach(var item in values) {
                if (item.GetHashCode() == hashCode)
                    return item;
            }
            return default(T);
        }

        /// <summary>
        /// Get the all values of an enum type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] TryGetValues<T>() where T : struct
            => Enum.GetValues(typeof(T)) as T[];

        /// <summary>
        /// Get the all string names of an enum type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string[] TryGetNames<T>() where T : struct
            => Enum.GetNames(typeof(T));

    }

}
