using System;
using System.Collections.Generic;
using System.Xml;

#nullable enable

namespace WDACConfig
{
    public static class XmlFilePathExtractor
    {
        public static HashSet<string> GetFilePaths(string xmlFilePath)
        {
            // Initialize HashSet with StringComparer.OrdinalIgnoreCase to ensure case-insensitive, ordinal comparison
            HashSet<string> filePaths = new(StringComparer.OrdinalIgnoreCase);

            // Instantiate the policy
            CodeIntegrityPolicy codeIntegrityPolicy = new(xmlFilePath, null);

            // Select all nodes with the "Allow" tag
            XmlNodeList? allowNodes = codeIntegrityPolicy.XmlDocument.SelectNodes("//ns:Allow", codeIntegrityPolicy.NamespaceManager);

            if (allowNodes != null)
            {

                foreach (XmlNode node in allowNodes)
                {
                    // Ensure node.Attributes is not null
                    if (node.Attributes != null && node.Attributes["FilePath"] != null)
                    {
                        // Add the file path to the HashSet
                        _ = filePaths.Add(node.Attributes["FilePath"]!.Value);
                    }
                }
            }

            return filePaths;
        }
    }
}