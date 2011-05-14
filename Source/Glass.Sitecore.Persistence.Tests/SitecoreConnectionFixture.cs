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
using NUnit.Framework;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Glass.Sitecore.Persistence.Tests
{
    [TestFixture]
    public class SitecoreConnectionFixture
    {
        [Test]
        public void ConnectionTest_ConnectsToSitecoreDatabase_RetrievesRootItem()
        {
            Database db = global::Sitecore.Configuration.Factory.GetDatabase("master");
            Item item = db.GetItem("/sitecore");
            Assert.IsNotNull(item);
            Assert.AreEqual("sitecore", item.Name.ToLower());

        }
    }
}
