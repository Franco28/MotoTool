
using System;
using System.Collections.Generic;

namespace Franco28Tool.Engine
{
    public sealed class EngineController
    {
        private const string ANDROID_CONTROLLER_FOLDER = "adb\\lib64\\";

        private static readonly Dictionary<string, string> RESOURCES = new Dictionary<string, string>
        {
            {"flash.cmd", ""},
            {"edl.cmd", ""},
            {"libc++.so", ""},
        };

        private static EngineController instance;
        private string resourceDirectory;
        private bool Extract_Resources = false;

        public static EngineController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EngineController();
                    instance.CreateResourceDirectories();
                    instance.ExtractResources();
                }
                return instance;
            }
        }

        internal string ResourceDirectory
        {
            get { return this.resourceDirectory; }
        }

        private EngineController()
        {
            ResourceFolderManager.Register(ANDROID_CONTROLLER_FOLDER);
            this.resourceDirectory = ResourceFolderManager.GetRegisteredFolderPath(ANDROID_CONTROLLER_FOLDER);
        }

        private void CreateResourceDirectories()
        {
            try
            {
                ResourceFolderManager.Unregister(ANDROID_CONTROLLER_FOLDER);
                Extract_Resources = true;

            }
            catch (Exception)
            {
                Extract_Resources = true;
            }
            ResourceFolderManager.Register(ANDROID_CONTROLLER_FOLDER);
        }

        private void ExtractResources()
        {
            if (this.Extract_Resources)
            {
                string[] res = new string[RESOURCES.Count];
                RESOURCES.Keys.CopyTo(res, 0);
                Extract.Resources(this, this.resourceDirectory, "Resources", res);
            }
        }
    }
}
