using AmountConverter.Helper;
using System.Linq;

namespace AmountConverter
{   
    public class ConvertService : IConvertService
    {       
        public string GetCurrencyInWords(string amount)
        {
            var val = amount.Replace(" ", "").Replace(",", ".");

            if (val.Count(a => a == '.') > 1)
            {
                return "Invalid Amount";
            }

            if (!decimal.TryParse(val, out decimal result))
            {
                return  "Invalid Amount";                
            }

            if (double.Parse(val) > 999999999.99 || double.Parse(val) < 0)
            {
                return "Please enter a valid Amount between 0 and 999 999 999,99";
            }

            return Currency.AmountInWords(decimal.Parse(val)).Replace("  ", " ");
        }
    }
}
