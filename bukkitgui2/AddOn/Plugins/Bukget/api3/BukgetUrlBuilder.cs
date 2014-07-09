// BukgetUrlBuilder.cs in bukkitgui2/bukkitgui2
// Created 2014/05/03
// Last edited at 2014/06/22 12:34
// ©Bertware, visit http://bertware.net

using System;
using System.Collections.Generic;

namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.Bukget.api3
{
    /// <summary>
    ///     Static class to create API request url's for bukget v3
    /// </summary>
    internal static class BukgetUrlBuilder
    {
        private const int DefaultLimit = 20;

        /// <summary>
        ///     Those are the info fields we want for a BukgetPlugin object, including all data
        /// </summary>
        /// <remarks></remarks>
        public static readonly PluginInfoField[] FieldsSimple =
        {
            PluginInfoField.Slug, PluginInfoField.Plugin_Name, PluginInfoField.Description, PluginInfoField.Main,
            PluginInfoField.Vf_Version, PluginInfoField.Vf_Filename, PluginInfoField.Vf_Game_Versions
        };

        /// <summary>
        ///     Those are the info fields we want for a BukgetPlugin object, including all data
        /// </summary>
        /// <remarks></remarks>
        public static readonly PluginInfoField[] FieldsAll =
        {
            PluginInfoField.Slug, PluginInfoField.Plugin_Name, PluginInfoField.Categories, PluginInfoField.Authors,
            PluginInfoField.Website, PluginInfoField.Dbo_Page, PluginInfoField.Description, PluginInfoField.Main,
            PluginInfoField.Vf_Version, PluginInfoField.Vf_Md5, PluginInfoField.Vf_Filename, PluginInfoField.Vf_Link,
            PluginInfoField.Vf_Type, PluginInfoField.Vf_Download, PluginInfoField.Vf_Status,
            PluginInfoField.Vf_Game_Versions, PluginInfoField.Vf_Date, PluginInfoField.Vf_Slug,
            PluginInfoField.Vf_Soft_Dependencies, PluginInfoField.Vf_Hard_Dependencies
        };

        /// <summary>
        ///     Construct the url to make an API call to get a list of all plugins
        /// </summary>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl()
        {
            return ConstructBaseUrl() + "/plugins";
        }

        /// <summary>
        ///     Construct the url to make an API call to get a list of all plugins
        /// </summary>
        /// <param name="field">the fields to retrieve</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(PluginInfoField[] field)
        {
            return ConstructUrl() + GetFieldArrayUrlValue(field);
        }

        /// <summary>
        ///     Construct the url to make an API call to get a list of all plugins
        /// </summary>
        /// <param name="field">the fields to retrieve</param>
        /// <param name="limit">the maximum amount or results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(PluginInfoField[] field, int limit)
        {
            return ConstructUrl(field) + GetLimitUrlValue(limit);
        }

        /// <summary>
        ///     Construct the url to make an API call to get a list of all plugins
        /// </summary>
        /// <param name="field">the fields to retrieve</param>
        /// <param name="sortField">the PluginInfoField to sort the results</param>
        /// <param name="limit">the maximum amount or results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(PluginInfoField[] field, PluginInfoField sortField, int limit)
        {
            return ConstructUrl(field, sortField, false, limit);
        }

        /// <summary>
        ///     Construct the url to make an API call to get a list of all plugins
        /// </summary>
        /// <param name="field">the fields to retrieve</param>
        /// <param name="sortField">the PluginInfoField to sort the results</param>
        /// <param name="negateSort">should the results list be reversed?</param>
        /// <param name="limit">the maximum amount or results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(PluginInfoField[] field, PluginInfoField sortField, Boolean negateSort,
            int limit)
        {
            return ConstructUrl(field, limit) + GetSortUrlValue(sortField, negateSort);
        }

        /// <summary>
        ///     Construct the url to make an API call get a list of plugins in the requested category
        /// </summary>
        /// <param name="pluginCategory">The category to list</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(PluginCategory pluginCategory)
        {
            return ConstructBaseUrl() + "/categories/" + GetCategoryUrlValue(pluginCategory);
        }

        /// <summary>
        ///     Construct the url to make an API call get a list of plugins in the requested category
        /// </summary>
        /// <param name="pluginCategory">The category to list</param>
        /// <param name="field">the fields to retrieve</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(PluginCategory pluginCategory, PluginInfoField[] field)
        {
            return ConstructUrl(pluginCategory) + GetFieldArrayUrlValue(field);
        }

        /// <summary>
        ///     Construct the url to make an API call get a list of plugins in the requested category
        /// </summary>
        /// <param name="pluginCategory">The category to list</param>
        /// <param name="field">the fields to retrieve</param>
        /// <param name="limit">the maximum amount or results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(PluginCategory pluginCategory, PluginInfoField[] field, int limit)
        {
            return ConstructUrl(pluginCategory, field) + GetLimitUrlValue(limit);
        }

        /// <summary>
        ///     Construct the url to make an API call get a list of plugins in the requested category
        /// </summary>
        /// <param name="pluginCategory">The category to list</param>
        /// <param name="field">the fields to retrieve</param>
        /// <param name="sortField">the PluginInfoField to sort the results</param>
        /// <param name="limit">the maximum amount or results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(PluginCategory pluginCategory, PluginInfoField[] field,
            PluginInfoField sortField,
            int limit)
        {
            return ConstructUrl(pluginCategory, field, sortField, false, limit);
        }

        /// <summary>
        ///     Construct the url to make an API call get a list of plugins in the requested category
        /// </summary>
        /// <param name="pluginCategory">The category to list</param>
        /// <param name="field">the fields to retrieve</param>
        /// <param name="sortField">the PluginInfoField to sort the results</param>
        /// <param name="negateSort">should the results list be reversed?</param>
        /// <param name="limit">the maximum amount or results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(
            PluginCategory pluginCategory,
            PluginInfoField[] field,
            PluginInfoField sortField,
            Boolean negateSort,
            int limit)
        {
            return ConstructUrl(pluginCategory, field, limit) + GetSortUrlValue(sortField, negateSort);
        }

        /// <summary>
        ///     Construct the url to make an API call to search for a given value in the selected PluginInfoField
        /// </summary>
        /// <param name="searchField">The PluginInfoField to search</param>
        /// <param name="action">The relation between the given value and the result</param>
        /// <param name="value">the value to search for</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(PluginInfoField searchField, SearchAction action, String value)
        {
            return ConstructUrl(searchField, action, value, DefaultLimit);
        }

        /// <summary>
        ///     Construct the url to make an API call to search for a given value in the selected PluginInfoField
        /// </summary>
        /// <param name="searchField">The PluginInfoField to search</param>
        /// <param name="action">The relation between the given value and the result</param>
        /// <param name="value">the value to search for</param>
        /// <param name="limit">the maximum amount of results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(PluginInfoField searchField, SearchAction action, String value, int limit)
        {
            return ConstructBaseUrl() + "/" + GetFieldUrlValue(searchField) + "/"
                   + GetSearchActionUrlValue(action) + "/" + value;
        }

        /// <summary>
        ///     Get the base URL for the given BukgetApi version
        /// </summary>
        /// <returns>the base path for the Bukget API</returns>
        /// <remarks>For future-proofing the code</remarks>
        public static string ConstructBaseUrl()
        {
            return "http://api.bukget.org/3";
        }

        /// <summary>
        ///     Get the URL for today's trends: number of plugins and versions
        /// </summary>
        /// <returns></returns>
        public static string ConstructStatsUrl()
        {
            return "http://api.bukget.org/stats/todays_trends";
        }

        /// <summary>
        ///     Convert enum to string for API usage
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private static string GetFieldUrlValue(PluginInfoField field)
        {
            return field.ToString().ToLower().Replace("vf_", "versions.").Replace("pop_", "popularity.");
        }

        private static string GetSearchActionUrlValue(SearchAction action)
        {
            return action.ToString().ToLower().Replace('_', '-');
        }

        private static string GetCategoryUrlValue(PluginCategory pluginCategory)
        {
            return pluginCategory.ToString().Replace("__", "-").Replace('_', '-');
        }

        private static string GetFieldArrayUrlValue(IEnumerable<PluginInfoField> fieldArray)
        {
            string fields = "?fields=";
            foreach (PluginInfoField field in fieldArray)
            {
                fields += GetFieldUrlValue(field) + ",";
            }
            fields = fields.TrimEnd(',');
            return fields;
        }

        private static string GetLimitUrlValue(int limit)
        {
            return "&start=0&size=" + limit;
        }

        /// <summary>
        ///     Get the URL value for a sort command
        /// </summary>
        /// <param name="sortfield">the PluginInfoField to sort</param>
        /// <param name="negate">should the sort direction be reversed?</param>
        /// <returns>the url value for the sort command</returns>
        private static string GetSortUrlValue(PluginInfoField sortfield, Boolean negate)
        {
            String result = "&sort=";
            if (negate)
            {
                result += "-";
            }
            result += GetFieldUrlValue(sortfield);
            return result;
        }
    }

    /// <summary>
    ///     The available categories
    /// </summary>
    /// <remarks>Case sensitive. _ replaces space, __ replaces -</remarks>
    public enum PluginCategory
    {
        Admin_Tools,
        //double underscore to replace -, as underscore already replaces space
        // ReSharper disable once InconsistentNaming
        Anti__Griefing_Tools,

        Chat_Related,

        Client_Fun,

        Client_Teleportation,

        Developer_Tools,

        Economy,

        Fixes,

        Fun,

        General,

        Informational,

        Mechanics,

        Miscellaneous,

        Role_Playing,

        Teleportation,

        Website_Administration,
        // this enum is case sensitive
        // ReSharper disable once InconsistentNaming
        World_Editing_and_Management,

        World_Generators,
    }

    public enum SearchAction
    {
        Equals,

        Not_Equals,

        Less,

        Less_Equal,

        More,

        More_Equals,

        Like
    }

    /// <summary>
    ///     A field describing a plugin property. Fields starting with vf_ describe info about the versions.
    /// </summary>
    public enum PluginInfoField
    {
        /// <summary>
        ///     The canonical name (example, BukkitDev slug name). This name is exclusive and cannot be changed.
        /// </summary>
        Slug,

        /// <summary>
        ///     A thumb-nailed version of the logo from the plugin’s BukkitDev page (Bukkit Only).
        /// </summary>
        Logo,

        /// <summary>
        ///     The full-size logo from the plugin’s BukkitDev page (Bukkit Only).
        /// </summary>
        Logo_Full,

        /// <summary>
        ///     What BukkitDev stage the plugin is in.
        /// </summary>
        Stage,

        /// <summary>
        ///     The name of the plugin. This is non-exclusive and multiple plugins could have the same name.
        /// </summary>
        Plugin_Name,

        /// <summary>
        ///     The server binary that this plugin is compatible with. For example, ‘bukkit’ would denote a bukkit plugin.
        /// </summary>
        Server,

        /// <summary>
        ///     List of categories that this plugin falls under.
        /// </summary>
        Categories,

        /// <summary>
        ///     List of authors that wrote this plug-in.
        /// </summary>
        Authors,

        /// <summary>
        ///     The web-site of the plugin
        /// </summary>
        Website,

        /// <summary>
        ///     The BukkitDev URL for this plugin (Bukkit Only)
        /// </summary>
        Dbo_Page,

        /// <summary>
        ///     A short description of the plugin
        /// </summary>
        Description,

        /// <summary>
        ///     This is the main field in the plugin.yml. Bukkit uses this to identify the plugin internally. This is usually the
        ///     main class.
        /// </summary>
        Main,

        /// <summary>
        ///     A list of version objects.
        /// </summary>
        Versions,

        /// <summary>
        ///     The version number.
        /// </summary>
        Vf_Version,

        /// <summary>
        ///     The MD5Sum of the version download.
        /// </summary>
        Vf_Md5,

        /// <summary>
        ///     Version download filename.
        /// </summary>
        Vf_Filename,

        /// <summary>
        ///     URL for version specific page.
        /// </summary>
        Vf_Link,

        /// <summary>
        ///     The version type.
        /// </summary>
        Vf_Type,

        /// <summary>
        ///     The download URL for this version.
        /// </summary>
        Vf_Download,

        /// <summary>
        ///     The BukkitDev version status (Bukkit Only).
        /// </summary>
        Vf_Status,

        /// <summary>
        ///     List of server versions that this specific plug-in version supports.
        /// </summary>
        Vf_Game_Versions,

        /// <summary>
        ///     Date released
        /// </summary>
        Vf_Date,

        /// <summary>
        ///     The canonical name of this version (example, BukkitDev version slug). This is exclusive to a plugin and cannot be
        ///     changed.
        /// </summary>
        Vf_Slug,

        /// <summary>
        ///     List of plugins that this plugins can optionally depend on.
        /// </summary>
        Vf_Soft_Dependencies,

        /// <summary>
        ///     List of plugins that are required for this plugin to run.
        /// </summary>
        Vf_Hard_Dependencies,

        /// <summary>
        ///     List of permission dictionaries details what permissions this plugin has (if parseable).
        /// </summary>
        Vf_Permissions,

        /// <summary>
        ///     List of command objects detailing what commands this plugins has (if parsable).
        /// </summary>
        Vf_Commands,

        /// <summary>
        ///     Base64 Encoded string of the version changelog.
        /// </summary>
        Vf_Changelog,

        /// <summary>
        ///     The array of pupularity data for this plugin
        /// </summary>
        Popularity,

        /// <summary>
        ///     Popularity score this week
        /// </summary>
        Pop_weekly,

        /// <summary>
        ///     Popularity score this month
        /// </summary>
        Pop_Monthly,

        /// <summary>
        ///     Popularity score today
        /// </summary>
        Pop_Daily,

        /// <summary>
        ///     Popularity score since creation
        /// </summary>
        Pop_Total
    }

    /// <summary>
    ///     The plugin status on bukkitdev
    /// </summary>
    /// <remarks></remarks>
    public enum PluginStatus
    {
        Planning,

        Alpha,

        Beta,

        Release,

        Mature,

        Semi_Normal,

        Normal
    }
}