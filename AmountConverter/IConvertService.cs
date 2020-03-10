using System.ServiceModel;

namespace AmountConverter
{
    [ServiceContract]
    public interface IConvertService
    {
        [OperationContract]
        string GetCurrencyInWords(string amount);
    }

}
