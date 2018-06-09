using System;
using System.Text;

namespace Soulstone.Network
{
    public sealed class NetworkSearcher
    {
        #region private members
        private static NetworkSearcher _instance;
        private CompEnum _domains;
        #endregion

        #region constructor
        private NetworkSearcher(){ }
        #endregion

        #region public properties
        public static NetworkSearcher Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NetworkSearcher();
                }
                return _instance;
            }
        }

        private CompEnum Domains
        {
            get
            {
                if (_domains == null)
                {
                    _domains = new CompEnum(CompEnum.ServerType.SV_TYPE_DOMAIN_ENUM, null);
                }
                return _domains;
            }
            set
            {
                _domains = value;
            }
        }
        #endregion

        private string Seek()
        {
            StringBuilder sb = new StringBuilder();
            #region intialize search
            CompEnum domainComputers;
            domainComputers = new CompEnum(CompEnum.ServerType.SV_TYPE_DOMAIN_ENUM, null);
            #endregion

            #region search domains
            CompEnum networkComputers;
            for (int i = 0; i < domainComputers.Length; i++)
            {
                networkComputers = new CompEnum((uint)CompEnum.ServerType.SV_TYPE_SERVER + (uint)CompEnum.ServerType.SV_TYPE_PRINTQ_SERVER, domainComputers[i].Name);
                #region search computer shares
                ShareCollection shi = null;
                for (int j = 0; j < networkComputers.Length; j++)
                {

                    shi = ShareCollection.GetShares(networkComputers[j].Name);

                    if (!shi.AccessDenied)
                    {
                        foreach (Share anyShare in shi)
                        {
                            if (!anyShare.NetName.Contains("$"))
                            {
                                switch (anyShare.ShareType)
                                {
                                    case ShareType.Device:
                                        sb.AppendLine(string.Format("Network Folder:{0}", anyShare.Root.FullName));
                                        break;
                                    case ShareType.Disk:
                                        sb.AppendLine(string.Format("Network Disk:{0}", anyShare.Root.FullName));
                                        break;
                                    case ShareType.Printer:
                                        sb.AppendLine(string.Format("Network Printer:{0}", anyShare.Root.FullName));
                                        break;
                                    case ShareType.IPC:
                                        sb.AppendLine(string.Format("Network IPC:{0}", anyShare.Root.FullName));
                                        break;
                                    default:
                                        sb.AppendLine(string.Format("Network Default:{0}", anyShare.Root.FullName));
                                        break;
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion
            return sb.ToString();
        }

        public CompEnum GetDomainNames()
        {            
            return Domains;
        }

        public CompEnum GetComputersOnDomain(string domainName)
        {
            return new CompEnum((uint)CompEnum.ServerType.SV_TYPE_SERVER + (uint)CompEnum.ServerType.SV_TYPE_PRINTQ_SERVER, domainName);
        }

        public ShareCollection GetSharesForComputer(string computerName)
        {
            return ShareCollection.GetShares(computerName);
        }
    }
}
