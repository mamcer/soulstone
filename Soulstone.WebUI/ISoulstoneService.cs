using System;
using System.ServiceModel;

namespace Soulstone.WebUI
{
    // NOTE: If you change the interface name "ISoulstoneService" here, you must also update the reference to "ISoulstoneService" in Web.config.
    [ServiceContract]
    public interface ISoulstoneService
    {
        [OperationContract]
        SearchResultSet Search(string album, string artist, string title, int year, string genre);

        [OperationContract]
        MusicTrack GetMusicTrack(Guid musicTrackId);

        [OperationContract]
        FileCountInfo GetTotalFileCount();
    }
}
