namespace Bukkitgui2.AddOn.Plugins.BukgetPlugins
{
    using System;
    using System.Collections.Generic;

    internal class BukgetV3
    {
        private const int DefaultLimit = 20;

        /// <summary>
        ///     Those are the info fields we want for a BukgetPlugin object, including all data
        /// </summary>
        /// <remarks></remarks>
        public static readonly Field[] FieldsSimple =
            {
                Field.Slug, Field.Plugin_Name, Field.Description, Field.Main,
                Field.Vf_Version, Field.Vf_Filename, Field.Vf_Game_Versions
            };

        /// <summary>
        ///     Those are the info fields we want for a BukgetPlugin object, including all data
        /// </summary>
        /// <remarks></remarks>
        public static readonly Field[] FieldsAll =
            {
                Field.Slug, Field.Plugin_Name, Field.Categories, Field.Authors,
                Field.Website, Field.Dbo_Page, Field.Description, Field.Main,
                Field.Vf_Version, Field.Vf_Md5, Field.Vf_Filename, Field.Vf_Link,
                Field.Vf_Type, Field.Vf_Download, Field.Vf_Status,
                Field.Vf_Game_Versions, Field.Vf_Date, Field.Vf_Slug,
                Field.Vf_Soft_Dependencies, Field.Vf_Hard_Dependencies
            };

        public static string ConstructUrl()
        {
            return ConstructBaseUrl(BukgetVersion.V3) + "/plugins";
        }

        public static string ConstructUrl(Field[] field)
        {
            return ConstructUrl() + GetFieldArrayUrlValue(field);
        }

        public static string ConstructUrl(Field[] field, int limit)
        {
            return ConstructUrl(field) + GetLimitUrlValue(limit);
        }

        public static string ConstructUrl(Field[] field, Field sortField, int limit)
        {
            return ConstructUrl(field, sortField, false, limit);
        }

        public static string ConstructUrl(Field[] field, Field sortField, Boolean negateSort, int limit)
        {
            return ConstructUrl(field, limit) + GetSortUrlValue(sortField, negateSort);
        }

        public static string ConstructUrl(Category category)
        {
            return ConstructBaseUrl(BukgetVersion.V3) + "/categories/" + GetCategoryUrlValue(category);
        }

        public static string ConstructUrl(Category category, Field[] field)
        {
            return ConstructUrl(category) + GetFieldArrayUrlValue(field);
        }

        public static string ConstructUrl(Category category, Field[] field, int limit)
        {
            return ConstructUrl(category, field) + GetLimitUrlValue(limit);
        }

        public static string ConstructUrl(Category category, Field[] field, Field sortField, int limit)
        {
            return ConstructUrl(category, field, sortField, false, limit);
        }

        public static string ConstructUrl(
            Category category,
            Field[] field,
            Field sortField,
            Boolean negateSort,
            int limit)
        {
            return ConstructUrl(category, field, limit) + GetSortUrlValue(sortField, negateSort);
        }

        public static string ConstructUrl(Field searchField, SearchAction action, String value)
        {
            return ConstructUrl(searchField, action, value, DefaultLimit);
        }

        public static string ConstructUrl(Field searchField, SearchAction action, String value, int limit)
        {
            return ConstructBaseUrl(BukgetVersion.V3) + "/" + GetFieldUrlValue(searchField) + "/"
                   + GetSearchActionUrlValue(action) + "/" + value;
        }

        /// <summary>
        ///     Get the base URL for the given BukgetApi version
        /// </summary>
        /// <param name="version">the API version to use</param>
        /// <returns>the base path for the Bukget API</returns>
        /// <remarks>For future-proofing the code</remarks>
        private static string ConstructBaseUrl(BukgetVersion version)
        {
            switch (version)
            {
                case BukgetVersion.V3:

                    return "http://api.bukget.org/3";
                default:
                    return "";
            }
        }

        private static string GetFieldUrlValue(Field field)
        {
            return field.ToString().ToLower().Replace("vf_", "versions.");
        }

        private static string GetSearchActionUrlValue(SearchAction action)
        {
            return action.ToString().ToLower().Replace('_', '-');
        }

        private static string GetCategoryUrlValue(Category category)
        {
            return category.ToString().Replace("__", "-").Replace('_', '-');
        }

        private static string GetFieldArrayUrlValue(IEnumerable<Field> fieldArray)
        {
            string fields = "?fields=";
            foreach (Field field in fieldArray)
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

        private static string GetSortUrlValue(Field sortfield, Boolean negate)
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

    public enum Field
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

        Vf_Version,

        Vf_Md5,

        Vf_Filename,

        Vf_Link,

        Vf_Type,

        Vf_Download,

        Vf_Status,

        Vf_Game_Versions,

        Vf_Date,

        Vf_Slug,

        Vf_Soft_Dependencies,

        Vf_Hard_Dependencies,
    }

    /// <summary>
    ///     The available categories
    /// </summary>
    /// <remarks>Case sensitive. _ replaces space, __ replaces -</remarks>
    public enum Category
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

    //	{

    //	"versions": [ // A list of version objects.
    //		{
    //			"status": "Semi-normal", // The BukkitDev version status (Bukkit Only).
    //			"commands": [ // List of command objects detailing what commands this plugins has (if parsable).
    //				{
    //					"usage": "", // Usage Description to be displayed to the user.
    //					"aliases": [], // List of aliases for this command.
    //					"command": "abacus", // The command name.
    //					"permission-message": "§cYou do not have access to that command.", // The message displayed if a user tried to run the command without permissions to.
    //					"permission": "abacus.abacus" // The permission this command relies on.
    //				}
    //			],
    //			"changelog": "LONG STRING OF STUFF!!!!!", // Base64 Encoded string of the version changelog.
    //			"game_versions": [ // List of server versions that this specific plug-in version supports.
    //				"CB 1.4.5-R0.2"
    //			],
    //			"filename": "Abacus.jar", // Version download filename.
    //			"hard_dependencies": [], // List of plugins that are required for this plugin to run.
    //			"date": 1353964798, // Date Released
    //			"version": "0.9.3", // The version number.
    //			"link": "http://dev.bukkit.org/server-mods/abacus/files/4-abacus-v0-9-2-cb-1-4-5-r0-2-compatible-w-1-3-2/", // URL for version specific page.
    //			"download": "http://dev.bukkit.org/media/files/650/288/Abacus.jar", // The download URL for this version.
    //			"md5": "1e1b6b6e131c617248f98c53bf650874", // The MD5Sum of the version download.
    //			"type": "Beta", // The version type. 
    //			"slug": "4-abacus-v0-9-2-cb-1-4-5-r0-2-compatible-w-1-3-2", // The canonical name of this version (example, BukkitDev version slug). This is exclusive to a plugin and cannot be changed.
    //			"soft_dependencies": [], // List of plugins that this plugins can optionally depend on.
    //			"permissions": [ // List of permission dictionaries details what permissions this plugin has (if parseable).
    //				{
    //					"default": "op", // Default permission for this role. Example, in Bukkit, there are 4 possibilities (“op”, “not op”, true, false).
    //					"role": "abacus.*" // Role name.
    //				},
    //				{
    //					"default": true,
    //					"role": "abacus.abacus"
    //				}
    //			]
    //		},

    //	],

    //}

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

    public enum BukgetVersion
    {
        V3
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