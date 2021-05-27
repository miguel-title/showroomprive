using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AtomicSeller.Helpers
{
    class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        private readonly string resourceName;
        public LocalizedDisplayNameAttribute(string resourceName)
            : base()
        {
          this.resourceName = resourceName;
        }

        public override string DisplayName
        {
            get
            {
                return Resources.Resources.ResourceManager.GetString(this.resourceName);
            }
        }
    }
}