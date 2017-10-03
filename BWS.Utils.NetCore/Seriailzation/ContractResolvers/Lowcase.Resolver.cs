using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BWS.Utils.NetCore.Seriailzation.ContractResolvers {

    public class LowercaseContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver {
        protected override string ResolvePropertyName(string propertyName) {
            var coll = new Regex(@"[a-z]{1}[A-Z]{1}|[A-Z]{2}[a-z]{1}").Matches(propertyName);
            foreach (Match item in coll) {
                propertyName = propertyName.Replace(item.Value, item.Value.Substring(0, 1) + "_" + item.Value.Substring(1));
            }
            return propertyName.ToLower();
        }
    }

}
