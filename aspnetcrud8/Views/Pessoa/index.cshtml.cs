using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace aspnetcrud8.Views.Pessoa
{
    public class indexModel : PageModel
        {
            DataTable dt = new DataTable();

            public void OnGet()
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                }
            }
    }
}
