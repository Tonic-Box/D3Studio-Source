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
    [ProtoContract(Name = "SavedDefinition")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class SavedDefinition : IExtensible
    {
        private uint _version;
        private Digest _digest = (Digest)null;
        private byte[] _seen_tutorials = (byte[])null;
        private long _num_vote_kicks_participated_in = 0;
        private long _num_vote_kicks_initiated = 0;
        private long _num_public_games_no_kick = 0;
        private long _times_vote_kicked = 0;
        private uint _create_time = 0;
        private uint _num_groups_created = 0;
        private List<AccountPartition> _partitions = new List<AccountPartition>();
        private ItemList _deprecated_normal_shared_saved_items = (ItemList)null;
        private SavedAttributes _deprecated_saved_attributes;
        private SavedAttributes _deprecated_saved_attributes_hardcore = (SavedAttributes)null;
        private ItemList _deprecated_hardcore_shared_saved_items = (ItemList)null;
        private CrafterSavedData _deprecated_crafter_normal_data = (CrafterSavedData)null;
        private CrafterSavedData _deprecated_crafter_hardcore_data = (CrafterSavedData)null;
        private EntityId _deprecated_gold_id_normal = (EntityId)null;
        private EntityId _deprecated_gold_id_hardcore = (EntityId)null;
        private byte[] _deprecated_stash_icons_normal = (byte[])null;
        private ulong _deprecated_accepted_license_bits = 0;
        private byte[] _deprecated_stash_icons_hardcore = (byte[])null;
        private ConsoleData _console_data = (ConsoleData)null;
        private CrafterTransmogData _Unknown_field_20 = (CrafterTransmogData)null;
        private UnlockedCosmetics _unlocked_cosmetics;
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

        [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = true, Name = "deprecated_saved_attributes")]
        public SavedAttributes deprecated_saved_attributes
        {
            get => this._deprecated_saved_attributes;
            set => this._deprecated_saved_attributes = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.Default, IsRequired = true, Name = "deprecated_saved_attributes_hardcore")]
        [DefaultValue(null)]
        public SavedAttributes deprecated_saved_attributes_hardcore
        {
            get => this._deprecated_saved_attributes_hardcore;
            set => this._deprecated_saved_attributes_hardcore = value;
        }

        [ProtoMember(5, DataFormat = DataFormat.Default, IsRequired = true, Name = "deprecated_normal_shared_saved_items")]
        [DefaultValue(null)]
        public ItemList deprecated_normal_shared_saved_items
        {
            get => this._deprecated_normal_shared_saved_items;
            set => this._deprecated_normal_shared_saved_items = value;
        }

        [ProtoMember(6, DataFormat = DataFormat.Default, IsRequired = true, Name = "deprecated_hardcore_shared_saved_items")]
        [DefaultValue(null)]
        public ItemList deprecated_hardcore_shared_saved_items
        {
            get => this._deprecated_hardcore_shared_saved_items;
            set => this._deprecated_hardcore_shared_saved_items = value;
        }

        [ProtoMember(7, DataFormat = DataFormat.Default, IsRequired = true, Name = "deprecated_crafter_normal_data")]
        [DefaultValue(null)]
        public CrafterSavedData deprecated_crafter_normal_data
        {
            get => this._deprecated_crafter_normal_data;
            set => this._deprecated_crafter_normal_data = value;
        }

        [ProtoMember(8, DataFormat = DataFormat.Default, IsRequired = true, Name = "deprecated_crafter_hardcore_data")]
        [DefaultValue(null)]
        public CrafterSavedData deprecated_crafter_hardcore_data
        {
            get => this._deprecated_crafter_hardcore_data;
            set => this._deprecated_crafter_hardcore_data = value;
        }

        [ProtoMember(9, DataFormat = DataFormat.Default, IsRequired = true, Name = "seen_tutorials")]
        [DefaultValue(null)]
        public byte[] seen_tutorials
        {
            get => this._seen_tutorials;
            set => this._seen_tutorials = value;
        }

        [ProtoMember(10, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "num_vote_kicks_participated_in")]
        [DefaultValue(0)]
        public long num_vote_kicks_participated_in
        {
            get => this._num_vote_kicks_participated_in;
            set => this._num_vote_kicks_participated_in = value;
        }

        [ProtoMember(11, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "num_vote_kicks_initiated")]
        [DefaultValue(0)]
        public long num_vote_kicks_initiated
        {
            get => this._num_vote_kicks_initiated;
            set => this._num_vote_kicks_initiated = value;
        }

        [ProtoMember(12, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "num_public_games_no_kick")]
        [DefaultValue(0)]
        public long num_public_games_no_kick
        {
            get => this._num_public_games_no_kick;
            set => this._num_public_games_no_kick = value;
        }

        [ProtoMember(13, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "times_vote_kicked")]
        [DefaultValue(0)]
        public long times_vote_kicked
        {
            get => this._times_vote_kicked;
            set => this._times_vote_kicked = value;
        }

        [ProtoMember(14, DataFormat = DataFormat.Default, IsRequired = true, Name = "deprecated_gold_id_normal")]
        [DefaultValue(null)]
        public EntityId deprecated_gold_id_normal
        {
            get => this._deprecated_gold_id_normal;
            set => this._deprecated_gold_id_normal = value;
        }

        [ProtoMember(15, DataFormat = DataFormat.Default, IsRequired = true, Name = "deprecated_gold_id_hardcore")]
        [DefaultValue(null)]
        public EntityId deprecated_gold_id_hardcore
        {
            get => this._deprecated_gold_id_hardcore;
            set => this._deprecated_gold_id_hardcore = value;
        }

        [ProtoMember(16, DataFormat = DataFormat.Default, IsRequired = true, Name = "deprecated_stash_icons_normal")]
        [DefaultValue(null)]
        public byte[] deprecated_stash_icons_normal
        {
            get => this._deprecated_stash_icons_normal;
            set => this._deprecated_stash_icons_normal = value;
        }

        [ProtoMember(17, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "deprecated_accepted_license_bits")]
        [DefaultValue(0.0f)]
        public ulong deprecated_accepted_license_bits
        {
            get => this._deprecated_accepted_license_bits;
            set => this._deprecated_accepted_license_bits = value;
        }

        [ProtoMember(18, DataFormat = DataFormat.Default, IsRequired = true, Name = "deprecated_stash_icons_hardcore")]
        [DefaultValue(null)]
        public byte[] deprecated_stash_icons_hardcore
        {
            get => this._deprecated_stash_icons_hardcore;
            set => this._deprecated_stash_icons_hardcore = value;
        }

        [ProtoMember(19, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "create_time")]
        [DefaultValue(0)]
        public uint create_time
        {
            get => this._create_time;
            set => this._create_time = value;
        }

        [Browsable(true)]
        [ProtoMember(20, DataFormat = DataFormat.Default, Name = "partitions")]
        public List<AccountPartition> partitions
        {
            get => this._partitions;
            set => this._partitions = value;
        }

        [ProtoMember(21, DataFormat = DataFormat.Default, IsRequired = true, Name = "console_data")]
        [DefaultValue(null)]
        public ConsoleData console_data
        {
            get => this._console_data;
            set => this._console_data = value;
        }

        [ProtoMember(22, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "num_groups_created")]
        [DefaultValue(0)]
        public uint num_groups_created
        {
            get => this._num_groups_created;
            set => this._num_groups_created = value;
        }

        private _console_exclusive_transmog_data _console_exclusive_transmog_data_field = new _console_exclusive_transmog_data();

        [ProtoMember(23, DataFormat = DataFormat.Default, IsRequired = true, Name = "console_exclusive_transmog_data")]
        [DefaultValue(null)]
        public _console_exclusive_transmog_data console_exclusive_transmog_data
        {
            get
            {
                return this._console_exclusive_transmog_data_field;
            }
            set
            {
                this._console_exclusive_transmog_data_field = value;
            }
        }

        [ProtoMember(24, IsRequired = false, Name = "unlocked_cosmetics", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public UnlockedCosmetics unlocked_cosmetics
        {
            get
            {
                return this._unlocked_cosmetics;
            }
            set
            {
                this._unlocked_cosmetics = value;
            }
        }
        /*
        [ProtoMember(25, IsRequired = false, Name = "dev_mode", DataFormat = DataFormat.Default)]
        [DefaultValue(false)]
        public bool dev_mode { get; set; }
        */
        private CurrencySavedData _account_wide_currency_data = new CurrencySavedData();

        [ProtoMember(26, IsRequired = false, Name = "account_wide_currency_data", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public CurrencySavedData account_wide_currency_data
        {
            get
            {
                return this._account_wide_currency_data;
            }
            set
            {
                this._account_wide_currency_data = value;
            }
        }
        
        private DeliveredRewards _delivered_rewards = new DeliveredRewards();

        [ProtoMember(27, IsRequired = false, Name = "delivered_rewards", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public DeliveredRewards delivered_rewards
        {
            get
            {
                return this._delivered_rewards;
            }
            set
            {
                this._delivered_rewards = value;
            }
        }

        private ConsumablesData _consumables = new ConsumablesData();

        [ProtoMember(28, IsRequired = false, Name = "consumables_data", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public ConsumablesData consumables_data
        {
            get
            {
                return this._consumables;
            }
            set
            {
                this._consumables = value;
            }
        }
        
        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "ConsumablesData")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class Consumable : IExtensible
    {
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.Default, Name = "license_instance_id")]
        public long license_instance_id { get; set; }

        [ProtoMember(2, DataFormat = DataFormat.Default, Name = "license_id")]
        public long license_id { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.Default, Name = "transaction_id")]
        public long transaction_id { get; set; }

        [ProtoMember(4, DataFormat = DataFormat.Default, Name = "quantity")]
        public long quantity { get; set; }

        [ProtoMember(5, DataFormat = DataFormat.Default, Name = "consume_time")]
        public long consume_time { get; set; }

        [ProtoMember(6, DataFormat = DataFormat.Default, Name = "revoke_time")]
        public long revoke_time { get; set; }

        [ProtoMember(7, DataFormat = DataFormat.Default, Name = "type")]
        public int type { get; set; }

        [ProtoMember(8, DataFormat = DataFormat.Default, Name = "data_persist_flags")]
        public int data_persist_flags { get; set; }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "ConsumablesData")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class ConsumablesData : IExtensible
    {
        private IExtension extensionObject;
        private List<Consumable> _consumed_licenses = new List<Consumable>();

        [ProtoMember(1, DataFormat = DataFormat.Default, Name = "consumed_licenses")]
        public List<Consumable> consumed_licenses
        {
            get
            {
                return this._consumed_licenses;
            }
            set
            {
                this._consumed_licenses = value;
            }
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }





    [ProtoContract(Name = "DeliveredRewards")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class DeliveredRewards : IExtensible
    {
        private IExtension extensionObject;
        private List<long> _achievement_reward = new List<long>();

        [ProtoMember(1, DataFormat = DataFormat.Default, Name = "achievement_reward")]
        public List<long> achievement_reward
        {
            get
            {
                return this._achievement_reward;
            }
            set
            {
                this._achievement_reward = value;
            }
        }

        [ProtoMember(2, DataFormat = DataFormat.Default, Name = "entitled_reward_license_bits")]
        [DefaultValue(0)]
        public int entitled_reward_license_bits { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.Default, Name = "outstanding_reward_license_bits")]
        [DefaultValue(0)]
        public int outstanding_reward_license_bits { get; set; }

        private List<float> _legacy_achievements_to_deliver = new List<float>();

        [ProtoMember(4, DataFormat = DataFormat.Default, Name = "legacy_achievements_to_deliver")]
        public List<float> legacy_achievements_to_deliver
        {
            get
            {
                return this._legacy_achievements_to_deliver;
            }
            set
            {
                this._legacy_achievements_to_deliver = value;
            }
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "_console_exclusive_transmog_data")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class _console_exclusive_transmog_data : IExtensible
    {
        private IExtension extensionObject;
        private List<int> _field_1 = new List<int>();
        private byte[] _field_2 = null;

        [ProtoMember(1, DataFormat = DataFormat.Default, Name = "transmog_data")]
        public List<int> field_1
        {
            get
            {
                return this._field_1;
            }
            set
            {
                this._field_1 = value;
            }
        }

        [ProtoMember(2, DataFormat = DataFormat.Default, Name = "transmog_data_bitfield")]
        public byte[] field_2
        {
            get
            {
                return this._field_2;
            }
            set
            {
                this._field_2 = value;
            }
        }

        [ProtoMember(3, DataFormat = DataFormat.Default, Name = "transmog_data_varrient")]
        [DefaultValue(0)]
        public long field_3 { get; set; }
        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
