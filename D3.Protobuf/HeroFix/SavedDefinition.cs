
using PB.AttributeSerializer;
using PB.Items;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.HeroFix
{
    [ProtoContract(Name = "SavedDefinition")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class SavedDefinition : IExtensible
    {
        private uint _version;
        private IExtension extensionObject;
        //*
        private _armory _armory_data = new _armory();

        [ProtoMember(11, DataFormat = DataFormat.Default, IsRequired = false, Name = "armory")]
        [DefaultValue(null)]
        public _armory armory
        {
            get
            {
                return this._armory_data;
            }
            set
            {
                this._armory_data = value;
            }
        }
        //*/
        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "_armory")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class _armory : IExtensible
    {
        private IExtension extensionObject;

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
