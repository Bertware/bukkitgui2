using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bukkitgui2.Core.Locale
{
	interface ILocale
	{

		/// <summary>
		/// Returns the current language of the translator
		/// </summary>
         string currentLanguage
        {
            get;
        }

        /// <summary>
        /// Indicates wether this component is initialized and can be used
        /// </summary>
         bool isInitialized
        {
            get;
        }

		/// <summary>
		/// Stop the logger, dispose used sources
		/// </summary>
		 void Dispose();

		/// <summary>
		/// Translate a string
		/// </summary>
		/// <param name="original">The original text</param>
		/// <returns></returns>
		 string Tr(string original);

		/// <summary>
		/// Translate a string
		/// </summary>
		/// <param name="original">The original text</param>
		/// <param name="p1">replacement value of parameter %1</param>
		/// <param name="p2">replacement value of parameter %2</param>
		/// <param name="p3">replacement value of parameter %3</param>
		/// <param name="p4">replacement value of parameter %4</param>
		/// <returns></returns>
		 string Tr(string original,string p1, string p2="", string p3="", string p4="");

	}
}
