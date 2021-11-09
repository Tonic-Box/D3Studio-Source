
using PB.Achievements;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using PB.AttributeSerializer;
using PB.ItemCrafting;
using PB.Items;
using PB.OnlineService;

namespace PB.Account
{
	[ProtoContract(Name = "UnlockedPetsDataX")]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[Serializable]
	public class UnlockedCosmetics : IExtensible
	{
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600030C RID: 780 RVA: 0x00006034 File Offset: 0x00004234
		// (set) Token: 0x0600030D RID: 781 RVA: 0x0000604C File Offset: 0x0000424C
		[ProtoMember(1, Name = "unlocked_cosmetics_data", DataFormat = DataFormat.Default)]
		public UnlockedCosmeticsData unlocked_cosmetics_data
		{
			get
			{
				return this._unlocked_cosmetics_data;
			}
			set
			{
				this._unlocked_cosmetics_data = value;
			}
		}

		// Token: 0x06000312 RID: 786 RVA: 0x000060A0 File Offset: 0x000042A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400018C RID: 396
		private UnlockedCosmeticsData _unlocked_cosmetics_data;

		// Token: 0x0400018F RID: 399
		private IExtension extensionObject;
	}
}
