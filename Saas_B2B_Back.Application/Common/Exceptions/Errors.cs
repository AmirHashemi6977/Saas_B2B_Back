using Saas_B2B_Back.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Common.Exceptions
{
    public class Errors : Exception
    {

        //public int ErrorCode { get; }

        //public string MyMessage { get; } = string.Empty;

        //public Errors(int errorCode, string entity, Exception? innerException = null) : base()


        //{
        //    string message = string.Empty;

        //    string entityStringFa = string.Empty;

        //    ErrorCode = errorCode;

        //    switch (entity)
        //    {
        //        case "Product":
        //            entityStringFa = "محصول";
        //            break;

        //        case "ProductDetail":
        //            entityStringFa = "مشخصات محصول";
        //            break;
        //        case "ProductImages":
        //            entityStringFa = "عکس های محصول";
        //            break;
        //        case "Stock":
        //            entityStringFa = "موجودی محصول";
        //            break;
        //        case "Warehouse":
        //            entityStringFa = "انبار محصول";
        //            break;
        //        case "User":
        //            entityStringFa = "کاربر";
        //            break;
        //        case "UserAddress":
        //            entityStringFa = "آدرس های کاربر";
        //            break;
        //        case "UserRole":
        //            entityStringFa = "نقش های کاربر";
        //            break;

        //        case "Order":
        //            entityStringFa = "سفارش کاربر";
        //            break;

        //        case "OrderItems":
        //            entityStringFa = "اقلام سفارش کاربر";
        //            break;
                    
        //    }


        //    switch (ErrorCode)
        //    {
        //        case 429:
        //            message = " مشکلی در دریافت اطلاعات " + entityStringFa + " پیش آمده است. سرور مشغول می باشد! ";
        //            break;

        //        case 404:
        //            message ="موردی برای " + entityStringFa + " یافت نشد!";
                    
        //            break;

        //        case 401:
        //            message = "عدم ورورد کاربر. دسترسی استفاده از وب سرویس وجود ندارد!";
        //            break;

        //        case 403:
        //            message = "دسترسی به فرم یا اجزا مورد نظر را ندارید!";
        //            break;

        //        case 400:
        //            message = "فرمت ورودی درخواست های Api به درستی ارسال نشده اند.";
        //            break;

        //        case 500:
        //        case 502:
        //        case 503:
        //        case 504:
        //        case 501:
        //            message = "سرور از دسترس خارج می باشد. با پشتیبانی تماس بگیرید.";
        //            break;

        //        case 200:
        //            message = "با موفقیت انجام شد.";
        //            break;

        //    }
        //    MyMessage = message;

        //}



    }
}


