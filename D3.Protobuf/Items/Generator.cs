
using PB.GameBalance;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Items
{
    [ProtoContract(Name = "Generator")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class Generator : IExtensible
    {
        private uint _seed;
        private Handle _gb_handle;
        private List<int> _base_affixes = new List<int>();
        private RareItemName _rare_item_name = (RareItemName)null;
        private int _enchant_affix = -1;
        private uint _flags;
        private uint _durability;
        private ulong _stack_size;
        private uint _dye_type = 0;
        private int _item_quality_level = 1;
        private int _item_binding_level = 0;
        private uint _max_durability = 0;
        private List<EmbeddedGenerator> _contents = new List<EmbeddedGenerator>();
        private ulong _item_unlock_timestamp = 0;
        private uint _enchant_range_val = 0;
        private uint _legendary_item_level = 0;
        private int _transmogrify_gbid = 0;
        private int _existing_affix = 0;
        private int _enchanted_affix = 0;
        private int _legendary_tier_quality = 0;
        private uint _enchant_seed = 0;
        private uint _enchanted_count = 0;
        private long _trade_account_id = 0;
        private uint _trade_ticks_left = 0;
        private uint _rank = 0;
        private uint _item_level = 0;
        private int _item_binding = 0;
        private bool _hardcore = false;
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "seed")]
        public uint seed
        {
            get => this._seed;
            set => this._seed = value;
        }

        [Browsable(true)]
        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "gb_handle")]
        public Handle gb_handle
        {
            get => this._gb_handle;
            set => this._gb_handle = value;
        }

        [Browsable(true)]
        [ProtoMember(3, DataFormat = DataFormat.FixedSize, Name = "base_affixes")]
        public List<int> base_affixes
        {
            get => this._base_affixes;
            set => this._base_affixes = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.Default, IsRequired = false, Name = "rare_item_name")]
        [DefaultValue(null)]
        public RareItemName rare_item_name
        {
            get => this._rare_item_name;
            set => this._rare_item_name = value;
        }

        [Browsable(true)]
        [ProtoMember(5, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "enchant_affix")]
        [DefaultValue(-1)]
        public int enchant_affix
        {
            get => this._enchant_affix;
            set => this._enchant_affix = value;
        }

        [Browsable(true)]
        [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "flags")]
        public uint flags
        {
            get => this._flags;
            set => this._flags = value;
        }

        [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "durability")]
        public uint durability
        {
            get => this._durability;
            set => this._durability = value;
        }

        [ProtoMember(8, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "stack_size")]
        public ulong stack_size
        {
            get => this._stack_size;
            set => this._stack_size = value;
        }

        [ProtoMember(9, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "dye_type")]
        [DefaultValue(0)]
        public uint dye_type
        {
            get => this._dye_type;
            set => this._dye_type = value;
        }

        [ProtoMember(10, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "item_quality_level")]
        [DefaultValue(1)]
        public int item_quality_level
        {
            get => this._item_quality_level;
            set => this._item_quality_level = value;
        }

        [ProtoMember(11, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "item_binding_level")]
        [DefaultValue(0)]
        public int item_binding_level
        {
            get => this._item_binding_level;
            set => this._item_binding_level = value;
        }

        [ProtoMember(12, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "max_durability")]
        [DefaultValue(0)]
        public uint max_durability
        {
            get => this._max_durability;
            set => this._max_durability = value;
        }

        [ProtoMember(13, DataFormat = DataFormat.Default, Name = "contents")]
        public List<EmbeddedGenerator> contents
        {
            get => this._contents;
            set => this._contents = value;
        }

        [ProtoMember(14, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "item_unlock_timestamp")]
        [DefaultValue(0.0f)]
        public ulong item_unlock_timestamp
        {
            get => this._item_unlock_timestamp;
            set => this._item_unlock_timestamp = value;
        }

        [ProtoMember(15, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "enchant_range_val")]
        [DefaultValue(0)]
        public uint enchant_range_val
        {
            get => this._enchant_range_val;
            set => this._enchant_range_val = value;
        }

        [ProtoMember(16, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "legendary_item_level")]
        [DefaultValue(0)]
        public uint legendary_item_level
        {
            get => this._legendary_item_level;
            set => this._legendary_item_level = value;
        }

        [Browsable(true)]
        [ProtoMember(17, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "transmog_gbid")]
        [DefaultValue(0)]
        public int transmogrify_gbid
        {
            get => this._transmogrify_gbid;
            set => this._transmogrify_gbid = value;
        }

        [ProtoMember(18, DataFormat = DataFormat.Default, IsRequired = false, Name = "season_id")]
        [DefaultValue(0)]
        public long season_id { get; set; }

        /*private AugmentData _augment_19;

        [ProtoMember(31, DataFormat = DataFormat.Default, IsRequired = false, Name = "augment_19")]
        public AugmentData augment_19
        {
            get => this._augment_19;
            set => this._augment_19 = value;
        }*/

        [Browsable(true)]
        [ProtoMember(20, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "existing_affix")]
        [DefaultValue(0)]
        public int existing_affix
        {
            get => this._existing_affix;
            set => this._existing_affix = value;
        }

        [Browsable(true)]
        [ProtoMember(21, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "enchated_affix")]
        [DefaultValue(0)]
        public int enchanted_affix
        {
            get => this._enchanted_affix;
            set => this._enchanted_affix = value;
        }

        [Browsable(true)]
        [ProtoMember(22, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "legendary_base_item_gbid")]
        [DefaultValue(0)]
        public int legendary_tier_quality
        {
            get => this._legendary_tier_quality;
            set => this._legendary_tier_quality = value;
        }

        [ProtoMember(23, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "enchant_seed")]
        [DefaultValue(0)]
        public uint enchant_seed
        {
            get => this._enchant_seed;
            set => this._enchant_seed = value;
        }

        [ProtoMember(24, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "enchanted_count")]
        [DefaultValue(0)]
        public uint enchanted_count
        {
            get => this._enchanted_count;
            set => this._enchanted_count = value;
        }

        [ProtoMember(25, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "trade_account_id")]
        [DefaultValue(0)]
        public long trade_account_id
        {
            get => this._trade_account_id;
            set => this._trade_account_id = value;
        }

        [ProtoMember(26, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "trade_ticks_left")]
        [DefaultValue(0)]
        public uint trade_ticks_left
        {
            get => this._trade_ticks_left;
            set => this._trade_ticks_left = value;
        }

        [ProtoMember(27, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "jewel_rank")]
        [DefaultValue(0)]
        public uint rank
        {
            get => this._rank;
            set => this._rank = value;
        }

        [ProtoMember(28, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "console_max_level")]
        [DefaultValue(0)]
        public uint item_level
        {
            get => this._item_level;
            set => this._item_level = value;
        }

        [ProtoMember(29, DataFormat = DataFormat.Default, IsRequired = false, Name = "console_promo_item")]
        [DefaultValue(0)]
        public int item_binding
        {
            get => this._item_binding;
            set => this._item_binding = value;
        }

        [ProtoMember(30, DataFormat = DataFormat.Default, IsRequired = false, Name = "hardcore")]
        [DefaultValue(false)]
        public bool hardcore
        {
            get => this._hardcore;
            set => this._hardcore = value;
        }

        private int _augment_gem_type;
        private int _augment_gem_level;

        [ProtoMember(32, DataFormat = DataFormat.Default, IsRequired = false, Name = "augment_gem_type")]
        [DefaultValue(0)]
        public int augment_gem_type
        {
            get => this._augment_gem_type;
            set => this._augment_gem_type = value;
        }

        [ProtoMember(33, DataFormat = DataFormat.Default, IsRequired = false, Name = "augment_gem_level")]
        [DefaultValue(0)]
        public int augment_gem_level
        {
            get => this._augment_gem_level;
            set => this._augment_gem_level = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
