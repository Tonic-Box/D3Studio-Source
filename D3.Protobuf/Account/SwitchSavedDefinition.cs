
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
    [ProtoContract(Name = "SwitchSavedDefinition")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class SwitchSavedDefinition : IExtensible
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
        private CrafterTransmogData _account_wide_transmog_data = (CrafterTransmogData)null;
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

        [ProtoMember(19, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "create_time")]
        [DefaultValue(0)]
        public uint create_time
        {
            get => this._create_time;
            set => this._create_time = value;
        }

        [ProtoMember(22, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "num_groups_created")]
        [DefaultValue(0)]
        public uint num_groups_created
        {
            get => this._num_groups_created;
            set => this._num_groups_created = value;
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ProtoMember(20, DataFormat = DataFormat.Default, Name = "partitions")]
        public List<AccountPartition> partitions
        {
            get => this._partitions;
            set => this._partitions = value;
        }

        [ProtoMember(5, DataFormat = DataFormat.Default, IsRequired = true, Name = "deprecated_normal_shared_saved_items")]
        [DefaultValue(null)]
        public ItemList deprecated_normal_shared_saved_items
        {
            get => this._deprecated_normal_shared_saved_items;
            set => this._deprecated_normal_shared_saved_items = value;
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

        [ProtoMember(21, DataFormat = DataFormat.Default, IsRequired = true, Name = "console_data")]
        [DefaultValue(null)]
        public ConsoleData console_data
        {
            get => this._console_data;
            set => this._console_data = value;
        }

        [ProtoMember(23, DataFormat = DataFormat.Default, IsRequired = true, Name = "account_wide_transmog_data")]
        [DefaultValue(null)]
        public CrafterTransmogData account_wide_transmog_data
        {
            get => this._account_wide_transmog_data;
            set => this._account_wide_transmog_data = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
