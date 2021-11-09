
using PB.AttributeSerializer;
using PB.ItemCrafting;
using PB.Items;
using PB.OnlineService;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Account
{
    [ProtoContract(Name = "AccountPartition")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class AccountPartition : IExtensible
    {
        private int _partition_id;
        private SavedAttributes _saved_attributes;
        private ItemList _items = (ItemList)null;
        private CrafterSavedData _crafter_data = (CrafterSavedData)null;
        private EntityId _gold_id = (EntityId)null;
        private byte[] _stash_icons = (byte[])null;
        private ulong _accepted_license_bits = 0;
        private uint _alt_level = 0;
        private CurrencySavedData _currency_data = (CurrencySavedData)null;
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "partition_id")]
        public int partition_id
        {
            get => this._partition_id;
            set => this._partition_id = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "saved_attributes")]
        public SavedAttributes saved_attributes
        {
            get => this._saved_attributes;
            set => this._saved_attributes = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = false, Name = "items")]
        [DefaultValue(null)]
        public ItemList items
        {
            get => this._items;
            set => this._items = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.Default, IsRequired = true, Name = "crafter_data")]
        [DefaultValue(null)]
        public CrafterSavedData crafter_data
        {
            get => this._crafter_data;
            set => this._crafter_data = value;
        }

        [ProtoMember(5, DataFormat = DataFormat.Default, IsRequired = true, Name = "gold_id")]
        [DefaultValue(null)]
        public EntityId gold_id
        {
            get => this._gold_id;
            set => this._gold_id = value;
        }

        [ProtoMember(6, DataFormat = DataFormat.Default, IsRequired = true, Name = "stash_icons")]
        [DefaultValue(null)]
        public byte[] stash_icons
        {
            get => this._stash_icons;
            set => this._stash_icons = value;
        }

        [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "accepted_license_bits")]
        [DefaultValue(0.0f)]
        public ulong accepted_license_bits
        {
            get => this._accepted_license_bits;
            set => this._accepted_license_bits = value;
        }

        [ProtoMember(8, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "alt_level")]
        [DefaultValue(0)]
        public uint alt_level
        {
            get => this._alt_level;
            set => this._alt_level = value;
        }

        [ProtoMember(9, DataFormat = DataFormat.Default, IsRequired = true, Name = "currency_data")]
        [DefaultValue(null)]
        public CurrencySavedData currency_data
        {
            get => this._currency_data;
            set => this._currency_data = value;
        }

        [ProtoMember(10, DataFormat = DataFormat.Default, IsRequired = true, Name = "flags")]
        [DefaultValue(0)]
        [Browsable(true)]
        public long flags { get; set; }

        private ConsolePartitionData _console_partition_data = new ConsolePartitionData();
        
        [ProtoMember(11, DataFormat = DataFormat.Default, IsRequired = true, Name = "console_partition_data")]
        [DefaultValue(null)]
        public ConsolePartitionData console_partition_data
        {
            get => this._console_partition_data;
            set => this._console_partition_data = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "ConsolePartitionData")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class ConsolePartitionData : IExtensible
    {
        private IExtension extensionObject;

        private List<int> _seasonal_gift_gbids_redeemed = new List<int>();

        [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "seasonal_gift_gbids_redeemed")]
        [DefaultValue(null)]
        public List<int> seasonal_gift_gbids_redeemed
        {
            get => this._seasonal_gift_gbids_redeemed;
            set => this._seasonal_gift_gbids_redeemed = value;
        }

        private List<SeasonalRolloverItem> _seasonal_rollover_item = new List<SeasonalRolloverItem>();

        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "seasonal_rollover_item")]
        [DefaultValue(null)]
        public List<SeasonalRolloverItem> seasonal_rollover_item
        {
            get => this._seasonal_rollover_item;
            set => this._seasonal_rollover_item = value;
        }

        private ConsoleRandomTransmuteSeedList _console_random_transmute_seed_list = new ConsoleRandomTransmuteSeedList();

        [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = true, Name = "console_random_transmute_seed_list")]
        [DefaultValue(null)]
        public ConsoleRandomTransmuteSeedList console_random_transmute_seed_list
        {
            get => this._console_random_transmute_seed_list;
            set => this._console_random_transmute_seed_list = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "ConsoleRandomTransmuteSeedList")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class ConsoleRandomTransmuteSeed : IExtensible
    {
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "item_slot_key")]
        [DefaultValue(0)]
        public int item_slot_key { get; set; }

        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "random_item_seed")]
        [DefaultValue(0)]
        public int random_item_seed { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = true, Name = "random_item_carry")]
        [DefaultValue(666)]
        public int random_item_carry { get; set; }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "ConsoleRandomTransmuteSeedList")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class ConsoleRandomTransmuteSeedList : IExtensible
    {
        private IExtension extensionObject;

        private List<ConsoleRandomTransmuteSeed> _console_random_transmute_seeds = new List<ConsoleRandomTransmuteSeed>();

        [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "console_random_transmute_seeds")]
        [DefaultValue(null)]
        public List<ConsoleRandomTransmuteSeed> console_random_transmute_seeds
        {
            get => this._console_random_transmute_seeds;
            set => this._console_random_transmute_seeds = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "SeasonalRolloverItem")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class SeasonalRolloverItem : IExtensible
    {
        private IExtension extensionObject;

        private SavedItem _item = new SavedItem();

        [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "item")]
        [DefaultValue(null)]
        public SavedItem item
        {
            get => this._item;
            set => this._item = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "item")]
        [DefaultValue(0)]
        public int create_time { get; set; }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
