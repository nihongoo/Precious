using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
    public class Cart
    {
        public Guid IDCart { get; set; }

        /// <summary>
        /// Thời gian tạo
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Tổng tiền tạm thời trong giỏ hàng
        /// </summary>
        public double Total { get; set; }

        public string Status { get; set; }

        public Guid IDCustomer { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<CartDetail>? CartDetails { get; set; }
    }
}
