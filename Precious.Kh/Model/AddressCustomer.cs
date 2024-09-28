using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
    public class AddressCustomer
    {
        public Guid IDAddress { get; set; }

        /// <summary>
        /// tên địa chỉ
        /// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		public string AddressName { get; set; }

        /// <summary>
        /// thành phố
        /// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		public string City { get; set; }

        /// <summary>
        /// quận/ huyện
        /// </summary>
        [Required(ErrorMessage ="Không được để trống")]
		public string District { get; set; }

        /// <summary>
        /// xã/ phường
        /// </summary>
        [Required(ErrorMessage ="Không được để trống")]
		public string Ward { get; set; }

        public Guid IDCustomer { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
