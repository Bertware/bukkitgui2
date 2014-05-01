namespace Net.Bertware.Bukkitgui2.AddOn.Plugins.BukgetPlugins
{
    using System;
    using System.Collections.Generic;

    using Jayrock.Json;
    using Jayrock.Json.Conversion;

    using Net.Bertware.Bukkitgui2.Core.Logging;

    public class BukgetV3
    {
        /// <summary>
        ///     Construction of the URL's required to make API calls
        /// </summary>

        #region Url construction
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

        /// <summary>
        ///     Construct the url to make an API call to get a list of all plugins
        /// </summary>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl()
        {
            return ConstructBaseUrl(BukgetVersion.V3) + "/plugins";
        }

        /// <summary>
        ///     Construct the url to make an API call to get a list of all plugins
        /// </summary>
        /// <param name="field">the fields to retrieve</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(Field[] field)
        {
            return ConstructUrl() + GetFieldArrayUrlValue(field);
        }

        /// <summary>
        ///     Construct the url to make an API call to get a list of all plugins
        /// </summary>
        /// <param name="field">the fields to retrieve</param>
        /// <param name="limit">the maximum amount or results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(Field[] field, int limit)
        {
            return ConstructUrl(field) + GetLimitUrlValue(limit);
        }

        /// <summary>
        ///     Construct the url to make an API call to get a list of all plugins
        /// </summary>
        /// <param name="field">the fields to retrieve</param>
        /// <param name="sortField">the field to sort the results</param>
        /// <param name="limit">the maximum amount or results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(Field[] field, Field sortField, int limit)
        {
            return ConstructUrl(field, sortField, false, limit);
        }

        /// <summary>
        ///     Construct the url to make an API call to get a list of all plugins
        /// </summary>
        /// <param name="field">the fields to retrieve</param>
        /// <param name="sortField">the field to sort the results</param>
        /// <param name="negateSort">should the results list be reversed?</param>
        /// <param name="limit">the maximum amount or results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(Field[] field, Field sortField, Boolean negateSort, int limit)
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
            return ConstructBaseUrl(BukgetVersion.V3) + "/categories/" + GetCategoryUrlValue(pluginCategory);
        }

        /// <summary>
        ///     Construct the url to make an API call get a list of plugins in the requested category
        /// </summary>
        /// <param name="pluginCategory">The category to list</param>
        /// <param name="field">the fields to retrieve</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(PluginCategory pluginCategory, Field[] field)
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
        public static string ConstructUrl(PluginCategory pluginCategory, Field[] field, int limit)
        {
            return ConstructUrl(pluginCategory, field) + GetLimitUrlValue(limit);
        }

        /// <summary>
        ///     Construct the url to make an API call get a list of plugins in the requested category
        /// </summary>
        /// <param name="pluginCategory">The category to list</param>
        /// <param name="field">the fields to retrieve</param>
        /// <param name="sortField">the field to sort the results</param>
        /// <param name="limit">the maximum amount or results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(PluginCategory pluginCategory, Field[] field, Field sortField, int limit)
        {
            return ConstructUrl(pluginCategory, field, sortField, false, limit);
        }

        /// <summary>
        ///     Construct the url to make an API call get a list of plugins in the requested category
        /// </summary>
        /// <param name="pluginCategory">The category to list</param>
        /// <param name="field">the fields to retrieve</param>
        /// <param name="sortField">the field to sort the results</param>
        /// <param name="negateSort">should the results list be reversed?</param>
        /// <param name="limit">the maximum amount or results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(
            PluginCategory pluginCategory,
            Field[] field,
            Field sortField,
            Boolean negateSort,
            int limit)
        {
            return ConstructUrl(pluginCategory, field, limit) + GetSortUrlValue(sortField, negateSort);
        }

        /// <summary>
        ///     Construct the url to make an API call to search for a given value in the selected field
        /// </summary>
        /// <param name="searchField">The field to search</param>
        /// <param name="action">The relation between the given value and the result</param>
        /// <param name="value">the value to search for</param>
        /// <returns>The URL to make the api call to, as a string</returns>
        public static string ConstructUrl(Field searchField, SearchAction action, String value)
        {
            return ConstructUrl(searchField, action, value, DefaultLimit);
        }

        /// <summary>
        ///     Construct the url to make an API call to search for a given value in the selected field
        /// </summary>
        /// <param name="searchField">The field to search</param>
        /// <param name="action">The relation between the given value and the result</param>
        /// <param name="value">the value to search for</param>
        /// <param name="limit">the maximum amount of results</param>
        /// <returns>The URL to make the api call to, as a string</returns>
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

        private static string GetCategoryUrlValue(PluginCategory pluginCategory)
        {
            return pluginCategory.ToString().Replace("__", "-").Replace('_', '-');
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

        /// <summary>
        ///     Get the URL value for a sort command
        /// </summary>
        /// <param name="sortfield">the field to sort</param>
        /// <param name="negate">should the sort direction be reversed?</param>
        /// <returns>the url value for the sort command</returns>
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

        #endregion

        #region parsing

        /// <summary>
        ///     Parse a bukget plugin from the json result
        /// </summary>
        /// <param name="jsonCode"></param>
        /// <returns></returns>
        public BukgetPlugin ParsePlugin(string jsonCode)
        {
            // Load the string into a json object
            JsonObject json;
            // In case of an array, load the first entry
            if (jsonCode.StartsWith("["))
            {
                json = (JsonObject)JsonConvert.Import<JsonArray>(jsonCode)[0];
            }
            else
            {
                json = JsonConvert.Import<JsonObject>(jsonCode);
            }

            string main = "namespace.unknown";
            if (json["main"] != null)
            {
                main = (string)json["main"];
            }

            string pluginName = "unnamed";
            if (json["plugin_name"] != null)
            {
                pluginName = (string)json["plugin_name"];
            }

            Logger.Log(LogLevel.Info, "BukGetAPI", "parsing plugin:" + pluginName, main);
            BukgetPlugin plugin = new BukgetPlugin(main, pluginName);

            if (json["slug"] != null)
            {
                plugin.Slug = (String)json["slug"];
            }
            else
            {
                plugin.Slug = "unkown name";
            }

            if (json["description"] != null)
            {
                plugin.Description = (String)json["description"];
            }
            else
            {
                plugin.Description = "";
            }
            if (json["dbo_page"] != null)
            {
                plugin.BukkitDevLink = (String)json["dbo_page"];
            }
            else
            {
                plugin.BukkitDevLink = "http://dev.bukkit.org";
            }
            if (json["link"] != null)
            {
                plugin.Website = (String)json["link"];
            }
            else
            {
                plugin.Website = "";
            }

            if (json["stage"] != null)
            {
                try
                {
                    plugin.Status = (PluginStatus)Enum.Parse(typeof(PluginStatus), json["stage"].ToString());
                }
                catch (Exception e)
                {
                    Logger.Log(LogLevel.Warning, "BukgetV3", "Couldn't parse plugin status", e.Message);
                }
            }

            plugin.AuthorsList = this.ParseJsonStringList(json["authors"]);

            // load strings
            List<String> categories = this.ParseJsonStringList(json["categories"]);
            // convert to enum values
            foreach (string category in categories)
            {
                plugin.CategoryList.Add((PluginCategory)Enum.Parse(typeof(PluginCategory), category));
            }

            IEnumerable<JsonObject> versions = this.ParseJsonObjectList(json["versions"]);
            foreach (JsonObject jsonObject in versions)
            {
                BukgetPluginVersion v = this.ParsePluginVersion(plugin, jsonObject.ToString());
                plugin.VersionsList.Add(v);
            }
            return plugin;
        }

        private BukgetPluginVersion ParsePluginVersion(BukgetPlugin plugin, String jsonCode)
        {

            {
                JsonObject json = (JsonObject)JsonConvert.Import(jsonCode);
                //create JSON object

                if (json["version"] == null)
                {
                    return null;
                }

                string version = json["version"].ToString();

                BukgetPluginVersion v = new BukgetPluginVersion(plugin, version)
                                            {
                                                CompatibleBuilds =
                                                    this.ParseJsonStringList(
                                                        json["game_versions"])
                                            };

                //add all versions

                //name of this version
                if (json["download"] != null)
                {
                    v.DownloadLink = json["download"].ToString();
                }
                //download link
                if (json["link"] != null)
                {
                    v.PageLink = json["link"].ToString();
                }
                //download link
                if (json["date"] != null)
                {
                    v.ReleaseDate = new DateTime(1970, 1, 1).AddSeconds(
                        Convert.ToDouble(json["date"].ToString()));
                }
                //date, in UNIX formart (seconds elapsed since 1/1/1970)
                if (json["filename"] != null)
                {
                    v.Filename = json["filename"].ToString();
                }
                //filename
                if (json["status"] != null)
                {
                    v.Type = (PluginStatus)Enum.Parse(typeof(PluginStatus), json["status"].ToString().Replace("-", "_"));
                }
                return v;
            }
        }

        /// <summary>
        ///     Parse a JsonArray to a list of strings
        /// </summary>
        /// <param name="jsonArray">the Json to convert</param>
        /// <returns> The strings contained in the Json array</returns>
        /// <remarks>
        ///     This code should always be able to handle any unexpected input or value, since the input will be coming from
        ///     a web resource that might change over time
        /// </remarks>
        private List<String> ParseJsonStringList(object jsonArray)
        {
            // list with result
            List<String> result = new List<string>();

            if (jsonArray == null)
            {
                return result;
            }

            // convert the object
            JsonArray array = (JsonArray)jsonArray;

            // If no entries, return
            if (array.Length < 1)
            {
                return result;
            }

            for (byte i = 0; i <= array.Length - 1; i++)
            {
                String value = array.GetString(i);
                // make sure there is a value in the string
                if (String.IsNullOrEmpty(value))
                {
                    continue;
                }
                // check if it's already added
                if (result.Contains(value))
                {
                    continue;
                }
                // if not, add
                result.Add(value);
            }

            return result;
        }

        /// <summary>
        ///     Parse a JsonArray to a list of Json objects
        /// </summary>
        /// <param name="jsonArray">the Json to convert</param>
        /// <returns> The Json objects contained in the Json array</returns>
        /// <remarks>
        ///     This code should always be able to handle any unexpected input or value, since the input will be coming from
        ///     a web resource that might change over time
        /// </remarks>
        private IEnumerable<JsonObject> ParseJsonObjectList(object jsonArray)
        {
            // list with result
            List<JsonObject> result = new List<JsonObject>();

            if (jsonArray == null)
            {
                return result;
            }

            // convert the object
            JsonArray array = (JsonArray)jsonArray;

            // If no entries, return
            if (array.Length < 1)
            {
                return result;
            }

            for (byte i = 0; i <= array.Length - 1; i++)
            {
                JsonObject value = array.GetObject(i);
                // make sure there is a value in the string
                if (value == null)
                {
                    continue;
                }
                // check if it's already added
                if (result.Contains(value))
                {
                    continue;
                }
                // if not, add
                result.Add(value);
            }

            return result;
        }

        #endregion
    }

    /// <summary>
    ///     A field describing a plugin property. Fields starting with vf_ describe info about the versions.
    /// </summary>
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
        Vf_Changelog
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