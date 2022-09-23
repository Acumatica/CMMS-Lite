using CommonServiceLocator;
using PX.Common;
using PX.Data;
using System;


namespace CMMS
{
    public static class WODatabase
    {
		#region Methods

		#region InsertWithAudit

		/// <summary>
		/// Calls <see cref="PXDatabase.Insert{Table}(PXDataFieldAssign[])"/> while providing logic to assign Audit Field data.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="noteID"/>
		/// <param name="screenID"/>
		/// <param name="pars"></param>
		/// <returns></returns>
		public static bool InsertWithAudit<T>(bool noteID, string screenID = null, params PXDataFieldAssign[] pars)
		where T : class, IBqlTable, new()
		{
			ICurrentUserInformationProvider currentUserProvider = ServiceLocator.Current.GetInstance<ICurrentUserInformationProvider>();

			PXDataFieldAssign[] arr = new PXDataFieldAssign[noteID ? pars.Length + 7 : pars.Length + 6];

			pars.CopyTo(arr, 0);

			arr[pars.Length] = new PXDataFieldAssign("CreatedByID", currentUserProvider.GetUserIdAccountingForImpersonationOrDefault());
			arr[pars.Length + 1] = new PXDataFieldAssign("CreatedByScreenID", screenID ?? PXContext.GetScreenID()?.Replace(".", "") ?? "00000000");
			arr[pars.Length + 2] = new PXDataFieldAssign("CreatedDateTime", PXContext.GetBusinessDate() ?? PXTimeZoneInfo.Today);
			arr[pars.Length + 3] = new PXDataFieldAssign("LastModifiedByID", currentUserProvider.GetUserIdAccountingForImpersonationOrDefault());
			arr[pars.Length + 4] = new PXDataFieldAssign("LastModifiedByScreenID", screenID ?? PXContext.GetScreenID()?.Replace(".", "") ?? "00000000");
			arr[pars.Length + 5] = new PXDataFieldAssign("LastModifiedDateTime", PXContext.GetBusinessDate() ?? PXTimeZoneInfo.Today);

			if (noteID)
			{
				arr[pars.Length + 6] = new PXDataFieldAssign("NoteID", new Guid?(SequentialGuid.Generate()));
			}

			return PXDatabase.Insert<T>(arr);
		}

		#endregion

		#region UpdateWithAudit

		/// <summary>
		/// Calls <see cref="PXDatabase.Update{Table}(PXDataFieldParam[])"/> while providing logic to assign Audit Field data.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="screenID"/>
		/// <param name="pars"></param>
		/// <returns></returns>
		public static bool UpdateWithAudit<T>(string screenID = null, params PXDataFieldParam[] pars)
		where T : class, IBqlTable, new()
		{
			ICurrentUserInformationProvider currentUserProvider = ServiceLocator.Current.GetInstance<ICurrentUserInformationProvider>();

			PXDataFieldParam[] arr = new PXDataFieldParam[pars.Length + 3];

			arr[0] = new PXDataFieldAssign("LastModifiedByID", currentUserProvider.GetUserIdAccountingForImpersonationOrDefault());
			arr[1] = new PXDataFieldAssign("LastModifiedByScreenID", screenID ?? PXContext.GetScreenID()?.Replace(".", "") ?? "00000000");
			arr[2] = new PXDataFieldAssign("LastModifiedDateTime", PXContext.GetBusinessDate() ?? PXTimeZoneInfo.Today);

			pars.CopyTo(arr, 3);

			return PXDatabase.Update<T>(arr);
		}

		#endregion

		#endregion
	}
}
