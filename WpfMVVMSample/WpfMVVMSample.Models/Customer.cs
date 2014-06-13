using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using WpfMVVMSample.Foundation;

namespace WpfMVVMSample.Models
{
    /// <summary>
    /// Model实现示例：
    /// 1，定义Model属性
    /// 2，重写ValidatedProperties方法指示要验证的属性
    /// 3，重写GetValidationError方法自定义每个属性的验证逻辑
    /// </summary>
    public class Customer : BaseModel
    {
        #region Model属性

        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        #endregion

        #region 重写方法

        protected override string[] ValidatedProperties()
        {
            return new string[] 
            {
                "Name",
                "Email" 
            };
        }
        protected override string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties(), propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "Email":
                    error = this.ValidateEmail();
                    break;

                case "Name":
                    error = this.ValidateName();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on Customer: " + propertyName);
                    break;
            }

            return error;
        }

        #endregion

        #region 自定义属性验证逻辑

        string ValidateEmail()
        {
            if (IsStringMissing(this.Email))
            {
                return "Strings.Customer_Error_MissingEmail";
            }
            else if (!IsValidEmailAddress(this.Email))
            {
                return "Strings.Customer_Error_InvalidEmail";
            }
            return null;
        }
        string ValidateName()
        {
            if (IsStringMissing(this.Name))
            {
                return "Strings.Customer_Error_MissingName";
            }
            return null;
        }

        #endregion

        #region 其他私有方法

        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }
        static bool IsValidEmailAddress(string email)
        {
            if (IsStringMissing(email))
                return false;

            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        #endregion
    }
}
