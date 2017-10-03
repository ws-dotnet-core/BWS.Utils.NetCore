using System;
using System.Collections.Generic;
using System.Text;

namespace BWS.Utils.NetCore.Format {
    public static class DateTimeHelper {

        public static long ToUnix(this DateTime date)
           => (long)Math.Round((date.ToUniversalTime() - BeginOffset).TotalSeconds);

        public static DateTime BeginPoint { get => new DateTime(1970, 1, 1, 0, 0, 0);}

        public static DateTimeOffset BeginOffset { get => new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero); }

    }
}
