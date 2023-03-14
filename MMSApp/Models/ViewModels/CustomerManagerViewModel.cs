using Microsoft.AspNetCore.Mvc.Rendering;

namespace MMSApp.Models.ViewModels
{
    public class CustomerManagerViewModel
    {
        public CustomerManagerViewModel()
        {

        }
        public List<Country> Countries { get; set; }
        public SelectList CountryCombo { get; set; }
    }
}
