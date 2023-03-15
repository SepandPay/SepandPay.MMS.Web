namespace MMSApp.Models.ViewModels
{
    public class FullCustomerViewModel
    {
        public Person MainPerson { get; set; }
        public List<Person> People { get; set; }
        public Contract Contract { get; set; }
        public List<Iban> Ibans { get; set; }
        public List<PSP> Psps { get; set; }
    }
}
