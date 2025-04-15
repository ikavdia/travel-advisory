using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace TravelBooking
{
    [ServiceContract]
    public interface IHotelService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/hotels?cityCode={cityCode}", ResponseFormat = WebMessageFormat.Json)]
        string GetHotelsByCity(string cityCode);
    }
}