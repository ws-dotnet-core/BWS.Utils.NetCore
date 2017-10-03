using System;
using System.Collections.Generic;
using System.Text;

namespace BWS.Utils.NetCore.Format {
    /// <summary>
    /// Date time extensons.
    /// </summary>
    public static class DateTimeHelper {

        /// <summary>
        /// Convert DateTime to unix format.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long ToUnix(this DateTime date)
           => (long)Math.Round((date.ToUniversalTime() - BeginOffset).TotalSeconds);

        /// <summary>
        /// 1970-01-01 00:00:00
        /// </summary>
        public static DateTime BeginPoint { get => new DateTime(1970, 1, 1, 0, 0, 0);}

        /// <summary>
        /// 1970-01-01 00:00:00 +00
        /// </summary>
        public static DateTimeOffset BeginOffset { get => new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero); }

    }
}
