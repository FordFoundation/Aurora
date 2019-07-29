namespace BagItProcess
{
    /// <summary>
    /// This class contains the properties which are configured.
    /// </summary>
    internal class Bagit_Props
    {
        /// <summary>
        /// The Bagit_getProp
        /// </summary>
        public void Bagit_getProp()
        {
        }

        /// <summary>
        /// Gets the HostName
        /// </summary>
        public string HostName
        {
            get { return Utility.GetConfigValueByKey("HostName"); }
        }

        /// <summary>
        /// Gets the SFTPUserName
        /// </summary>
        public string SFTPUserName
        {
            get { return Utility.GetConfigValueByKey("SFTPUserName"); }
        }

        /// <summary>
        /// Gets the SFTPPassword
        /// </summary>
        public string SFTPPassword
        {
            get { return Utility.GetConfigValueByKey("SFTPPassword"); }
        }

        /// <summary>
        /// Gets the SFTPPort
        /// </summary>
        public string SFTPPort
        {
            get { return Utility.GetConfigValueByKey("SFTPPort"); }
        }

        /// <summary>
        /// Gets the SFTPDirectory
        /// </summary>
        public string SFTPDirectory
        {
            get { return Utility.GetConfigValueByKey("SFTPDirectory"); }
        }

        /// <summary>
        /// Gets the PythonDirectory
        /// </summary>
        public string PythonDirectory
        {
            get { return Utility.GetConfigValueByKey("PythonDirectory"); }
        }

        /// <summary>
        /// Gets the PythonExePath
        /// </summary>
        public string PythonExePath
        {
            get { return Utility.GetConfigValueByKey("PythonExePath"); }
        }

        /// <summary>
        /// Gets the SourceOrganization
        /// </summary>
        public string SourceOrganization
        {
            get { return Utility.GetConfigValueByKey("SourceOrganization"); }
        }

        /// <summary>
        /// Gets the BagitDirectory
        /// </summary>
        public string BagitDirectory
        {
            get { return Utility.GetConfigValueByKey("BagitDirectory"); }
        }

        /// <summary>
        /// Gets the ProcessDirectory
        /// </summary>
        public string ProcessDirectory
        {
            get { return Utility.GetConfigValueByKey("ProcessDirectory"); }
        }

        /// <summary>
        /// Gets the ProcessArchiveDirectory
        /// </summary>
        public string ProcessArchiveDirectory
        {
            get { return Utility.GetConfigValueByKey("ProcessArchiveDirectory"); }
        }

        /// <summary>
        /// Gets the SuccessBagMessage
        /// </summary>
        public string SuccessBagMessage
        {
            get { return Utility.GetConfigValueByKey("SuccessBagMessage"); }
        }

        /// <summary>
        /// Gets the Template_bag
        /// </summary>
        public string Template_bag
        {
            get { return Utility.GetConfigValueByKey("Template_bag"); }
        }

        /// <summary>
        /// Gets the Create_bag
        /// </summary>
        public string Create_bag
        {
            get { return Utility.GetConfigValueByKey("Create_bag"); }
        }

        /// <summary>
        /// Gets the Validate_bag
        /// </summary>
        public string Validate_bag
        {
            get { return Utility.GetConfigValueByKey("Validate_bag"); }
        }

        /// <summary>
        /// Gets the BagitDirectoryName
        /// </summary>
        public string BagitDirectoryName
        {
            get { return Utility.GetConfigValueByKey("BagitDirectoryName"); }
        }

        /// <summary>
        /// Gets the Profile_Json
        /// </summary>
        public string Profile_Json
        {
            get { return Utility.GetConfigValueByKey("Profile_Json"); }
        }
    }
}
