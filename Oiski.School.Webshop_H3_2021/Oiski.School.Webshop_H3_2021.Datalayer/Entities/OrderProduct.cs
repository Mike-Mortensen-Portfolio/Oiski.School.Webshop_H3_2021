using System.ComponentModel.DataAnnotations.Schema;

namespace Oiski.School.Webshop_H3_2021.Datalayer.Entities
{
    [Table ("OrderProducts")]
    public class OrderProduct
    {
        public int ProductID { get; set; }
        public int OrderID { get; set; }
    }
}
