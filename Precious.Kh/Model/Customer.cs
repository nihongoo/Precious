using Precious.core.Extention;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
    public class Customer
    {
        public Guid IDCustomer { get; set; }

        /// <summary>
        ///Họ và tên 
        /// </summary>
        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        [Required(ErrorMessage = "Không được để trống")]
        public int GioiTinh { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        [Required(ErrorMessage = "Không được để trống")]
        [FutureDate]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Số điện thoại +84/ 0
        /// </summary>
        [Required(ErrorMessage = "Không được để trống")]
		[RegularExpression("^(?:\\+84|0)(?:3[2-9]|5[6|8|9]|7[0|6-9]|8[1-5]|9[0-4|6-9])[0-9]{7}$", ErrorMessage = "Số điện thoại sai định dạng")]
		public string PhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Không được để trống")]
        [EmailAddress]
        public string Email { get; set; }

        public int Status { get; set; }

        public Guid IDUser { get; set; }

        public virtual Cart? Cart { get; set; }
        public virtual Account? Account { get; set; }
        public virtual ICollection<AddressCustomer>? Address { get; set; }
        public virtual ICollection<Bill>? Bills { get; set; }
        public virtual ICollection<FavoriteProducts>? FavoriteProducts { get; set;}
    }
}
