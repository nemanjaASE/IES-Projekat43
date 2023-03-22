using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class BasicIntervalSchedule : IdentifiedObject
    {
		private DateTime startTime;
        public BasicIntervalSchedule(long globalId) 
            : base(globalId)
        {
        }
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                BasicIntervalSchedule x = (BasicIntervalSchedule)obj;
                return (x.startTime == this.startTime);
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
				case ModelCode.BASICINTERVALSCHEDULE_STARTTIME:
					return true;

				default:
					return base.HasProperty(t);
			}
		}

		public override void GetProperty(Property prop)
		{
			switch (prop.Id)
			{

				case ModelCode.BASICINTERVALSCHEDULE_STARTTIME:
					prop.SetValue(startTime);
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
				case ModelCode.BASICINTERVALSCHEDULE_STARTTIME:
					startTime = property.AsDateTime();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		#endregion IAccess implementation
	}
}
