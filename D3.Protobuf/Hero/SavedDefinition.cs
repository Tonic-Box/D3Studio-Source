
using PB.AttributeSerializer;
using PB.Items;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
    [ProtoContract(Name = "SavedDefinition")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class SavedDefinition : IExtensible
    {
        private uint _version;
        private Digest _digest = (Digest)null;
        private SavedAttributes _saved_attributes;
        private SavedData _saved_data = (SavedData)null;
        private List<SavedQuest> _saved_quest = new List<SavedQuest>();
        private ItemList _items = (ItemList)null;
        private List<QuestRewardHistoryEntry> _quest_reward_history = new List<QuestRewardHistoryEntry>();
        private ulong _accepted_license_bits = 0;
        private uint _season_created = 0;
        private ConsoleData _console_data = (ConsoleData)null;
        private string _wm = System.Text.Encoding.ASCII.GetString(new byte[]
        {
            77, 111, 100, 105, 102, 105,
            101, 100, 32, 119, 105, 116,
            104, 32, 84, 111, 110, 105,
            99, 66, 111, 120, 39, 115, 32,
            69, 100, 105, 116, 111, 114, 46
        });
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "version")]
        public uint version
        {
            get => this._version;
            set => this._version = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "digest")]
        [DefaultValue(null)]
        public Digest digest
        {
            get => this._digest;
            set => this._digest = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = true, Name = "saved_attributes")]
        public SavedAttributes saved_attributes
        {
            get => this._saved_attributes;
            set => this._saved_attributes = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.Default, IsRequired = true, Name = "saved_data")]
        [DefaultValue(null)]
        public SavedData saved_data
        {
            get => this._saved_data;
            set => this._saved_data = value;
        }

        [ProtoMember(5, DataFormat = DataFormat.Default, Name = "saved_quest")]
        public List<SavedQuest> saved_quest
        {
            get => this._saved_quest;
            set => this._saved_quest = value;
        }

        [ProtoMember(6, DataFormat = DataFormat.Default, IsRequired = false, Name = "items")]
        [DefaultValue(null)]
        public ItemList items
        {
            get => this._items;
            set => this._items = value;
        }

        [ProtoMember(7, DataFormat = DataFormat.Default, Name = "quest_reward_history")]
        public List<QuestRewardHistoryEntry> quest_reward_history
        {
            get => this._quest_reward_history;
            set => this._quest_reward_history = value;
        }

        [ProtoMember(8, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "accepted_license_bits")]
        [DefaultValue(0.0f)]
        public ulong accepted_license_bits
        {
            get => this._accepted_license_bits;
            set => this._accepted_license_bits = value;
        }

        [ProtoMember(9, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "season_created")]
        [DefaultValue(0)]
        public uint season_created
        {
            get => this._season_created;
            set => this._season_created = value;
        }

        [ProtoMember(10, DataFormat = DataFormat.Default, IsRequired = false, Name = "console_data")]
        [DefaultValue(null)]
        public ConsoleData console_data
        {
            get => this._console_data;
            set => this._console_data = value;
        }
        /*
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
        

        [ProtoMember(15, DataFormat = DataFormat.Default, IsRequired = false, Name = "wm")]
        [DefaultValue(null)]
        [Browsable(false)]
        public string wm
        {
            get => this._wm;
            set => this._wm = value;
        }
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

        private List<_armory_save> _armory_data = new List<_armory_save>();

        [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = false, Name = "armory_save")]
        [DefaultValue((List<_armory_save>)null)]
        public List<_armory_save> armory_save
        {
            get => this._armory_data;
            set => this._armory_data = value;
        }
        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "_armory_save")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class _armory_save : IExtensible
    {
        private IExtension extensionObject;

        private List<_11_field_1> _field_1_data = new List<_11_field_1>();
        private List<_11_field_2_7> _field_2_data = new List<_11_field_2_7>();
        private List<long> _field_3_data = new List<long>();
        private List<long> _field_4_data = new List<long>();
        private List<_11_field_2_7> _field_7_data = new List<_11_field_2_7>();

        [ProtoMember(1, DataFormat = DataFormat.Default, Name = "field_1")]
        [DefaultValue((List<_11_field_1>)null)]
        public List<_11_field_1> field_1
        {
            get => this._field_1_data;
            set => this._field_1_data = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.Default, Name = "field_2")]
        [DefaultValue((List<_11_field_2_7>)null)]
        public List<_11_field_2_7> field_2
        {
            get => this._field_2_data;
            set => this._field_2_data = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.Default, Name = "field_3")]
        [DefaultValue((List<long>)null)]
        public List<long> field_3
        {
            get => this._field_3_data;
            set => this._field_3_data = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.Default, Name = "field_4")]
        [DefaultValue((List<long>)null)]
        public List<long> field_4
        {
            get => this._field_4_data;
            set => this._field_4_data = value;
        }

        [ProtoMember(5, DataFormat = DataFormat.Default, Name = "name")]
        [DefaultValue("")]
        public string name { get; set; }

        [ProtoMember(6, DataFormat = DataFormat.ZigZag, Name = "slot_id")]
        [DefaultValue(null)]
        public int slot_id { get; set; }

        [ProtoMember(7, DataFormat = DataFormat.Default, Name = "field_7")]
        [DefaultValue((List<_11_field_2_7>)null)]
        public List<_11_field_2_7> field_7
        {
            get => this._field_7_data;
            set => this._field_7_data = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "_11_field_1")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class _11_field_1 : IExtensible
    {
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.Default, Name = "field_1")]
        [DefaultValue(null)]
        public long field_1 { get; set; }
        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "_11_field_2_7")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class _11_field_2_7 : IExtensible
    {
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.Default, Name = "field_1")]
        [DefaultValue(null)]
        public long field_1 { get; set; }

        [ProtoMember(2, DataFormat = DataFormat.Default, Name = "field_2")]
        [DefaultValue(null)]
        public long field_2 { get; set; }
        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
