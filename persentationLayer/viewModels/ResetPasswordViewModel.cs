using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Demo.persentationLayer.viewModels
{
    public class ResetPasswordViewModel
    {
       
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
