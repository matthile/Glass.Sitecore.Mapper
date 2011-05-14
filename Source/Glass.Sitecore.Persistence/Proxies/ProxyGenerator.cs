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

using System.Reflection;
using Sitecore.Data.Items;
using System.Collections;

namespace Glass.Sitecore.Persistence.Proxies
{
    public class ProxyGenerator
    {
        private static readonly Castle.DynamicProxy.ProxyGenerator _generator = new Castle.DynamicProxy.ProxyGenerator();

        public static T CreateProxy<T>(InstanceContext context, Item item) where T : class, new()
        {
            return CreateProxy(typeof(T), context, item) as T;
        }
        public static object CreateProxy(Type type,  InstanceContext context, Item item){
            var options = new Castle.DynamicProxy.ProxyGenerationOptions(new ProxyGeneratorHook() );
            var proxy = _generator.CreateClassProxy(type, options, new ProxyClassInterceptor(type,
                context,
                item));
            return proxy;
        }
       
    }
}
