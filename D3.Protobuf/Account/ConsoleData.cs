
using PB.Achievements;
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Account
{
    [ProtoContract(Name = "ConsoleData")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class ConsoleData : IExtensible
    {
        private uint _version_required = 0;
        private Snapshot _achievement_snapshot = (Snapshot)null;
        private int _highest_completed_difficulty_deprecated = -1;
        private bool _has_demo_save = false;
        private AvengerData _avenger_data = (AvengerData)null;
        private float _progress = 0.0f;
        private bool _has_bnet_account = false;
        private uint _legacy_license_bits = 0;
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "version_required")]
        [DefaultValue(0)]
        public uint version_required
        {
            get => this._version_required;
            set => this._version_required = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "achievement_snapshot")]
        [DefaultValue(null)]
        public Snapshot achievement_snapshot
        {
            get => this._achievement_snapshot;
            set => this._achievement_snapshot = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "highest_completed_difficulty_deprecated")]
        [DefaultValue(-1)]
        public int highest_completed_difficulty_deprecated
        {
            get => this._highest_completed_difficulty_deprecated;
            set => this._highest_completed_difficulty_deprecated = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.Default, IsRequired = true, Name = "has_demo_save")]
        [DefaultValue(false)]
        public bool has_demo_save
        {
            get => this._has_demo_save;
            set => this._has_demo_save = value;
        }

        [ProtoMember(5, DataFormat = DataFormat.Default, IsRequired = true, Name = "avenger_data")]
        [DefaultValue(null)]
        public AvengerData avenger_data
        {
            get => this._avenger_data;
            set => this._avenger_data = value;
        }

        [ProtoMember(6, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "progress")]
        [DefaultValue(0.0f)]
        public float progress
        {
            get => this._progress;
            set => this._progress = value;
        }

        [ProtoMember(7, DataFormat = DataFormat.Default, IsRequired = false, Name = "has_bnet_account")]
        [DefaultValue(false)]
        public bool has_bnet_account
        {
            get => this._has_bnet_account;
            set => this._has_bnet_account = value;
        }

        [ProtoMember(8, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "legacy_license_bits")]
        [DefaultValue(0)]
        public uint legacy_license_bits
        {
            get => this._legacy_license_bits;
            set => this._legacy_license_bits = value;
        }
        /*
        [ProtoMember(9, DataFormat = DataFormat.Default, IsRequired = true, Name = "dm")]
        [DefaultValue(0)]
        public bool dm { get; set; }
        */
        [ProtoMember(14, DataFormat = DataFormat.Default, IsRequired = true, Name = "unknown_14")]
        [DefaultValue(0)]
        public long unknown_14 { get; set; }

        [ProtoMember(15, DataFormat = DataFormat.Default, IsRequired = true, Name = "unknown_15")]
        [DefaultValue(0)]
        public long unknown_15 { get; set; }

        [ProtoMember(16, DataFormat = DataFormat.Default, IsRequired = true, Name = "unknown_16")]
        [DefaultValue(0)]
        public long unknown_16 { get; set; }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
