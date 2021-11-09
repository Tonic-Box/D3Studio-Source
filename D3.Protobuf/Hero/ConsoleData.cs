
using PB.Profile;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
    [ProtoContract(Name = "ConsoleData")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class ConsoleData : IExtensible
    {
        private HeroProfile _hero_profile = (HeroProfile)null;
        private int _last_played_handicap = 2;
        private string _killer_name = "";
        private int _last_played_adventure_mode_act = 0;
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = false, Name = "hero_profile")]
        [DefaultValue(null)]
        public HeroProfile hero_profile
        {
            get => this._hero_profile;
            set => this._hero_profile = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "last_played_handicap")]
        [DefaultValue(2)]
        public int last_played_handicap
        {
            get => this._last_played_handicap;
            set => this._last_played_handicap = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = false, Name = "killer_name")]
        [DefaultValue("")]
        public string killer_name
        {
            get => this._killer_name;
            set => this._killer_name = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "last_played_adventure_mode_act")]
        [DefaultValue(0)]
        public int last_played_adventure_mode_act
        {
            get => this._last_played_adventure_mode_act;
            set => this._last_played_adventure_mode_act = value;
        }

        
        private _unknown_5 _unknown_5_data = new _unknown_5();

        [ProtoMember(5, DataFormat = DataFormat.Default, IsRequired = false, Name = "random_item_vendor_seed_list")]
        [DefaultValue(null)]
        public _unknown_5 random_item_vendor_seed_list
        {
            get => this._unknown_5_data;
            set => this._unknown_5_data = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "_unknown_5")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class _unknown_5 : IExtensible
    {
        private IExtension extensionObject;

        private List<unknown_5_entry> _unknown_5_data = new List<unknown_5_entry>();

        [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = false, Name = "random_item_vendor_seed_list")]
        [DefaultValue((List<unknown_5_entry>)null)]
        public List<unknown_5_entry> random_item_vendor_seed_list
        {
            get => this._unknown_5_data;
            set => this._unknown_5_data = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "unknown_5_entry")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class unknown_5_entry : IExtensible
    {
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = false, Name = "field_1")]
        [DefaultValue(null)]
        public long filed_1 { get; set; }

        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = false, Name = "field_2")]
        [DefaultValue(null)]
        public long filed_2 { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = false, Name = "field_3")]
        [DefaultValue(null)]
        public long filed_3 { get; set; }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
