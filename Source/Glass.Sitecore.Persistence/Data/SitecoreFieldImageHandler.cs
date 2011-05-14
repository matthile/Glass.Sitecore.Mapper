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
using Glass.Sitecore.Persistence.FieldTypes;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Glass.Sitecore.Persistence.Configuration;
using Sitecore.Data;
using Sitecore.Links;

namespace Glass.Sitecore.Persistence.Data
{
    public class SitecoreFieldImageHandler : AbstractSitecoreField
    {

        public override object GetValue(object parent, global::Sitecore.Data.Items.Item item, Glass.Sitecore.Persistence.Configuration.SitecoreProperty property, InstanceContext context)
        {
            string fieldName = GetFieldName(property);

            Image img = new Image();
            ImageField scImg = new ImageField(item.Fields[fieldName]);

            int height = 0;
            int.TryParse(scImg.Height, out height);
            int width = 0;
            int.TryParse(scImg.Width, out width);
            int hSpace = 0;
            int.TryParse(scImg.HSpace, out hSpace);
            int vSpace = 0;
            int.TryParse(scImg.VSpace, out vSpace);

            img.Alt = scImg.Alt;
            img.Border = scImg.Border;
            img.Class = scImg.Class;
            img.Height = height;
            img.HSpace = hSpace;
            img.MediaId = scImg.MediaID.Guid;
            img.Src = scImg.Src;
            img.VSpace = vSpace;
            img.Width = width;

            return img;
        }
        public override void SetValue(object parent, global::Sitecore.Data.Items.Item item, object value, Glass.Sitecore.Persistence.Configuration.SitecoreProperty property, InstanceContext context)
        {
            string fieldName = GetFieldName(property);

            Image img = value as Image;
            ImageField scImg = new ImageField(item.Fields[fieldName]);


            if (scImg.MediaID.Guid != img.MediaId)
            {
                //this only handles empty guids, but do we need to remove the link before adding a new one?
                if (img.MediaId == Guid.Empty)
                {
                    ItemLink link = new ItemLink(item.Database.Name, item.ID, null, scImg.MediaItem.Database.Name, scImg.MediaID, scImg.MediaPath);
                    scImg.RemoveLink(link);
                }
                else
                {
                    ID newId = new ID(img.MediaId);
                    Item target = item.Database.GetItem(newId);
                    if (target != null)
                    {
                        scImg.MediaID = newId;
                        ItemLink link = new ItemLink(item.Database.Name, item.ID, null, target.Database.Name, target.ID, target.Paths.FullPath);
                        scImg.UpdateLink(link);
                    }
                    else throw new PersistenceException("No item with ID {0}. Can not update Media Item field".Formatted(newId));
                }
            }

            scImg.Height = img.Height.ToString();
            scImg.Width = img.Width.ToString();
            scImg.HSpace = img.HSpace.ToString();
            scImg.VSpace = img.VSpace.ToString();
            scImg.Alt = img.Alt;
            scImg.Border = img.Border;
            scImg.Class = img.Class;
          
           

        }

        public override object GetFieldValue(string fieldValue, object parent, Item item, SitecoreProperty property, InstanceContext context)
        {
            throw new NotImplementedException();
           
        }

        public override string SetFieldValue(Type returnType, object value, InstanceContext context)
        {
            throw new NotImplementedException();
        }

        public override Type TypeHandled
        {
            get { return typeof(FieldTypes.Image); }
        }
    }
}
