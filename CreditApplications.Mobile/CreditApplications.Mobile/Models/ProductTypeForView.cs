using System.ComponentModel;
using CreditApplications.ServiceReference;

namespace CreditApplications.Mobile.Models;

public class ProductTypeForView
{
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("Product type")]
    public string ProductTypeName { get; set; }
    

    public ProductTypeForView()
    {
        
    }

    public ProductTypeForView(ProductTypeModel model)
    {
        Id = model.Id;
        ProductTypeName = model.ProductTypeName;
    }
}