using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BWS.Utils.NetCore.Format {
    public static class EnumHelper {

        public static T Parse<T>(string content) where T : struct
            => (T)Enum.Parse(typeof(T), content);

        public static T TryParse<T>(string content)where T: struct {
            var ok = Enum.TryParse(content, out T result);
            return ok ? result : default(T);
        }

        public static T TryParseHash<T>(int hashCode) where T : struct {
            var values = TryGetValues<T>();
            foreach(var item in values) {
                if (item.GetHashCode() == hashCode)
                    return item;
            }
            return default(T);
        }

        public static T[] TryGetValues<T>() where T : struct
            => Enum.GetValues(typeof(T)) as T[];

        public static string[] TryGetNames<T>() where T : struct
            => Enum.GetNames(typeof(T));

    }

}
