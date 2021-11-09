
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.ItemCrafting
{
    [ProtoContract(Name = "CrafterSavedData")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class CrafterSavedData : IExtensible
    {
        private List<CrafterData> _crafter_data = new List<CrafterData>();
        private CrafterTransmogData _transmog_data = (CrafterTransmogData)null;
        private CrafterDevilsHandData _devils_hand_data = (CrafterDevilsHandData)null;
        private CrafterKanaisCubeData _kanais_cube_data;
        private MysteryData _mystery_data;
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.Default, Name = "crafter_data")]
        public List<CrafterData> crafter_data
        {
            get => this._crafter_data;
            set => this._crafter_data = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = false, Name = "transmog_data")]
        [DefaultValue(null)]
        public CrafterTransmogData transmog_data
        {
            get => this._transmog_data;
            set => this._transmog_data = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = false, Name = "devils_hand_data")]
        [DefaultValue(null)]
        public CrafterDevilsHandData devils_hand_data
        {
            get => this._devils_hand_data;
            set => this._devils_hand_data = value;
        }

        [ProtoMember(4, IsRequired = false, Name = "kanais_cube_data", DataFormat = DataFormat.Default)]
        [DefaultValue(null)]
        public CrafterKanaisCubeData kanais_cube_data
        {
            get
            {
                return this._kanais_cube_data;
            }
            set
            {
                this._kanais_cube_data = value;
            }
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
