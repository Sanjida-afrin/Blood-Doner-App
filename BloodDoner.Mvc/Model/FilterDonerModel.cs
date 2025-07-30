namespace BloodDoner.Mvc.Model
{
    public class FilterDonerModel
    {
        public required string bloodGroup { get; set; } 
        public required string address { get; set; }
        public bool? isEligible { get; set; }
    }
}
