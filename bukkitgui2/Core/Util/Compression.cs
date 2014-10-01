// Compression.cs in bukkitgui2/bukkitgui2
// Created 2014/07/13
// 
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file,
// you can obtain one at http://mozilla.org/MPL/2.0/.
// 
// ©Bertware, visit http://bertware.net

using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Net.Bertware.Bukkitgui2.Core.Logging;

namespace Net.Bertware.Bukkitgui2.Core.Util
{
    /// <summary>
    ///     Compress and decompress zip files.
    /// </summary>
    /// <remarks></remarks>
    internal static class Compression
    {
        /// <summary>
        ///     Compress the content of a directory to a zip file
        /// </summary>
        /// <param name="directoryToZip">The directory that should be compressed</param>
        /// <param name="theZipFile">The output file path</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool Compress(string directoryToZip, string theZipFile)
        {
            // Compress file (DirectoryToZip is source, ZipFile is output file)
            // Example: compression("c:/Directory", "c:/Directory.zip")


            try
            {
                int i;
                // index Create file index
                // length of index

                // Get complete name of files to compress
                string[] filestozip = Directory.GetFiles(directoryToZip, "*.*", SearchOption.AllDirectories);

                // mydirname : name of directory to compress
                string mydirname = new DirectoryInfo(directoryToZip).Name;

                // create zip stream
                ZipOutputStream zipStream = new ZipOutputStream(File.Create(theZipFile));

                // For all files

                for (i = 0; i < filestozip.Length; i++)
                {
                    try
                    {
                        // Open file and read
                        FileStream fs = File.OpenRead(filestozip[i]);
                        Int32 mylength = Convert.ToInt32(fs.Length);

                        // Tableau de byte, de la taille du fichier à lire
                        byte[] buffer = new byte[mylength + 1];

                        // Read and close files
                        fs.Read(buffer, 0, mylength);
                        fs.Close();

                        // define entry in zip
                        ZipEntry entry = new ZipEntry(mydirname + filestozip[i].Replace(directoryToZip, ""));

                        // Add new entry
                        zipStream.PutNextEntry(entry);

                        // Create in zip archive
                        zipStream.Write(buffer, 0, mylength);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(LogLevel.Severe, "Compression",
                            "Error while compressing file " + (i + 1) + " of " + filestozip.Length + " :" +
                            filestozip[i], ex.Message);
                    }
                }

                //Close stream
                zipStream.Finish();
                zipStream.Close();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Severe, "Compression", "Error while compressing files!", ex.Message);
                return false;
            }
        }

        /// <summary>
        ///     Decompress a zip compatible archive
        /// </summary>
        /// <param name="destinationDirectory">the directory where the files should be decompressed</param>
        /// <param name="myzipfile">the zip file to decompress</param>
        /// <returns>true if success</returns>
        /// <remarks></remarks>
        public static bool Decompress(string destinationDirectory, string myzipfile)
        {
            //Decompress zip archive in DestinationDirectory
            //Example: decompression("c:/DossierResultat", "c:/Dossier.zip")

            try
            {
                // Create zipstream
                ZipInputStream zipIStream = new ZipInputStream(File.OpenRead(myzipfile));

                // For all entry's

                while (true)
                {
                    // Read next entry
                    ZipEntry theEntry = zipIStream.GetNextEntry();

                    if (theEntry == null)
                        break;
                    //end when done

                    // check if file
                    if (!theEntry.IsFile) continue;

                    // Define zipfile
                    FileInfo myFile = new FileInfo(destinationDirectory + "/" + theEntry.Name);
                    if (myFile.Directory == null) continue;
                    // Create directory
                    if (!myFile.Directory.Exists)
                        myFile.Directory.Create();

                    // Create end file
                    FileStream fs = new FileStream(myFile.FullName, FileMode.Create);
                    int size = 2048;
                    byte[] data = new byte[size + 1];
                    while (!((size <= 0)))
                    {
                        size = zipIStream.Read(data, 0, data.Length);
                        fs.Write(data, 0, size);
                    }
                    fs.Flush();
                    fs.Close();
                }

                // Close stream
                zipIStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Severe, "Compression", "Error while decompressing files!", ex.Message);
                return false;
            }
        }
    }
}