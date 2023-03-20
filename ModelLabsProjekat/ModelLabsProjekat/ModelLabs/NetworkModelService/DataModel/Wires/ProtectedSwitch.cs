using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class ProtectedSwitch : Switch
    {
        private float breakingCapacity;
        public ProtectedSwitch(long globalId)
           : base(globalId)
        {
        }
        public float BreakingCapacity
        {
            get { return breakingCapacity; }
            set { breakingCapacity = value; }
        }
		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				ProtectedSwitch x = (ProtectedSwitch)obj;
				return (x.breakingCapacity == this.breakingCapacity);
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#region IAccess implementation

		public override bool HasProperty(ModelCode t)
		{
			switch (t)
			{
				case ModelCode.PROTECTEDSWITCH_BREAKINGCAPACITY:
					return true;

				default:
					return base.HasProperty(t);
			}
		}

		public override void GetProperty(Property prop)
		{
			switch (prop.Id)
			{

				case ModelCode.PROTECTEDSWITCH_BREAKINGCAPACITY:
					prop.SetValue(breakingCapacity);
					break;

				default:
					base.GetProperty(prop);
					break;
			}
		}

		public override void SetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.PROTECTEDSWITCH_BREAKINGCAPACITY:
					breakingCapacity = property.AsFloat();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		#endregion IAccess implementation
	}
}
