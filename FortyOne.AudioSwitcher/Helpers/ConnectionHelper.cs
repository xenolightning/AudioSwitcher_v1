using System.Net;
using FortyOne.AudioSwitcher.Properties;

namespace FortyOne.AudioSwitcher.Helpers
{
    public static class ConnectionHelper
    {
        public static bool IsServerOnline
        {
            get
            {
                try
                {
                    var wc = new WebClient();

                    var defaultProxy = WebRequest.DefaultWebProxy;
                    if (defaultProxy != null)
                    {
                        defaultProxy.Credentials = CredentialCache.DefaultCredentials;
                        wc.Proxy = defaultProxy;
                    }

                    wc.DownloadData(Resources.WebServiceURL);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static AudioSwitcherService.AudioSwitcher GetAudioSwitcherProxy()
        {
            if (IsServerOnline)
            {
                var defaultProxy = WebRequest.DefaultWebProxy;
                if (defaultProxy != null)
                    defaultProxy.Credentials = CredentialCache.DefaultCredentials;

                return new AudioSwitcherService.AudioSwitcher
                {
                    Proxy = defaultProxy,
                    Url = Resources.WebServiceURL
                };
            }
            return null;
        }
    }
}