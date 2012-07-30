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
using Glass.Sitecore.Mapper.Data;

namespace Glass.Sitecore.Mapper.Configuration
{
    public abstract class AbstractConfigurationLoader
    {
        public AbstractConfigurationLoader()
        {
            _dataHandlers = new List<Data.AbstractSitecoreDataHandler>(Utility.GetDefaultDataHanlders());
        }
        public abstract IEnumerable<SitecoreClassConfig> Load();

        protected IList<Data.AbstractSitecoreDataHandler> _dataHandlers;

        public IEnumerable<Data.AbstractSitecoreDataHandler> DataHandlers
        {
            get
            {
                return _dataHandlers;
            }
        }

        public void AddDataHandler(Data.AbstractSitecoreDataHandler data)
        {
            this._dataHandlers.Insert(0, data);
        }
        /// <summary>
        /// A unique identifier for this configuration. Override this in module loaders to specify a specific ID.
        /// </summary>
        public abstract Guid Id { get;  }
    }
}
