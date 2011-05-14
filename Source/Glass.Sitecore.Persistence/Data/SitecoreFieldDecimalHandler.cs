﻿/*
   Copyright 2011 Michael Edwards
 
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Sitecore.Persistence.Configuration;
using Sitecore.Data.Items;

namespace Glass.Sitecore.Persistence.Data
{
    public class SitecoreFieldDecimalHandler : AbstractSitecoreField
    {
        public override object GetFieldValue(string fieldValue, object parent, Item item, SitecoreProperty property, InstanceContext context)
        {
            if (fieldValue.IsNullOrEmpty()) return 0M;

            decimal dValue = 0;
            if (decimal.TryParse(fieldValue, out dValue)) return dValue;
            else throw new PersistenceException("Could not convert value to decimal");
        }

        public override string SetFieldValue(Type returnType, object value, InstanceContext context)
        {
            return value.ToString();
        }

        public override Type TypeHandled
        {
            get { return typeof(decimal); }
        }
    }
}
