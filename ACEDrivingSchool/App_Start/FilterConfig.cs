// ***********************************************************************
// Assembly         : ACEDrivingSchool
// Author           : Ben
// Created          : 05-29-2018
//
// Last Modified By : Ben
// Last Modified On : 05-29-2018
// ***********************************************************************

using System.Web;
using System.Web.Mvc;

namespace ACEDrivingSchool
{
    /// <summary>
    /// Class FilterConfig.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
