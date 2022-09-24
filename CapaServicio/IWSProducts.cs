using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CapaServicio
{
    [ServiceContract]
    public interface IWSProducts
    {

        [OperationContract]
        Product GetProduct(int productid);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class Product : BaseResponse
    {
        [DataMember]
        public string ProductType { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public int ProductPrice { get; set; }

        [DataMember]
        public int ProductStock { get; set; }

        [DataMember]
        public string ProductDescription{ get; set; }
    }


    [DataContract]
    public class BaseResponse
    {
        [DataMember]
        public string MessageResponse { get; set; }
        public string Error { get; set; }
    }




    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
