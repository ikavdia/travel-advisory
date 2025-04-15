using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace FlightService
{
    [ServiceContract]
    public interface IFlightService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/flights?origin={origin}&destination={destination}&travelDate={travelDate}")]
        Stream GetFlights(string origin, string destination, string travelDate);
    }
}
