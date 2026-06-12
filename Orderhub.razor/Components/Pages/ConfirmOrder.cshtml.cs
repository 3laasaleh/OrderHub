using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Orderhub.razor.Components.Pages
{
    public class ConfirmOrderModel : PageModel
    {
        [BindProperty]
        public List<OrderLineViewModel> Lines { get; set; } = [];

        public string SchoolName { get; set; } = string.Empty;

        public decimal Subtotal => Lines.Sum(x => x.UnitPrice * x.Quantity);

        public void OnGet()
        {
            SchoolName = "Brindleford School";

            Lines =
            [
                new OrderLineViewModel
            {
                Id = 1,
                Sku = "ABC-001",
                Embroidery = "Tom",
                UnitPrice = 20.00m,
                Quantity = 2
            },
            new OrderLineViewModel
            {
                Id = 2,
                Sku = "ABC-002",
                Embroidery = "School Crest",
                UnitPrice = 35.00m,
                Quantity = 1
            }
            ];
        }

        public IActionResult OnPost()
        {
            foreach (var line in Lines)
            {
                if (line.Quantity < 0)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        $"Quantity cannot be negative for SKU {line.Sku}.");
                }
            }

            if (!ModelState.IsValid)
            {
                SchoolName = "Brindleford School";
                return Page();
            }

            // Call application service here:
            // await _orderProcessor.ProcessOrderAsync(...)

            return RedirectToPage("OrderConfirmed");
        }
    }

    public class OrderLineViewModel
    {
        public int Id { get; set; }

        public string Sku { get; set; } = string.Empty;

        public string? Embroidery { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
