
namespace Models.ViewModels
{
    public class CountryBetVM
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public decimal CountryCoeficient { get; set; }
        public string TextConcat 
        { 
            get 
            { 
                return CountryName + " - " + CountryCoeficient.ToString(); 
            } 

            set { } 
        }
        public string UserId { get; set; }
    }
}
