using FlowerShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Utility.Extension
{
    public static class ClaimExtension
    {
        public static ClaimsIdentity ToClaimsIdentity(this User user)
        {
            var result = new ClaimsIdentity(new[] {
                    new Claim("id", user.Id.ToString()),
                    new Claim("email", !string.IsNullOrEmpty( user.Email) ? user.Email : ""),
                    new Claim("phoneNumber", user.PhoneNumber),
                    new Claim("nationalCode", !string.IsNullOrEmpty( user.NationalCode) ? user.NationalCode : ""),
                    new Claim("lastSignedinAt", user.LastSignedinAt.ToString("yyyy-MM-dd hh:mm:ss tt"))
                });
            return result;
        }

        public static User ToUser(this ClaimsPrincipal principal)
        {
            var result = new UserResponse();
            foreach (var claim in principal.Claims)
            {
                switch (claim.Type.ToLower())
                {
                    case "id":
                        result.Id = long.Parse(claim.Value);
                        break;

                    case "email":
                        result.Email = claim.Value;
                        break;

                    case "phoneNumber":
                        result.PhoneNumber = claim.Value;
                        break;

                    case "nationalCode":
                        result.NationalCode = claim.Value;
                        break;

                    case "lastsignedinat":
                        DateTime.TryParse(claim.Value, out var lastSignedinAt);
                        result.LastSignedinAt = lastSignedinAt;
                        break;
                }
            }
            return result;
        }

        public static void Key(this Claim claim)
        {
            //var result = new Dictionary<string, string> {
            //    ["Surname"] = ClaimTypes.Surname,
            //    ["UserData"] = ClaimTypes.UserData,
            //    ["NameIdentifier"] = ClaimTypes.NameIdentifier,
            //    ["Name"] = ClaimTypes.Name,
            //    ["MobilePhone"] = ClaimTypes.MobilePhone,
            //    ["Country"] = ClaimTypes.Country,
            //    ["DateOfBirth"] = ClaimTypes.DateOfBirth,
            //    ["Email"] = ClaimTypes.Email,
            //    ["Gender"] = ClaimTypes.Gender,
            //    ["GivenName"] = ClaimTypes.GivenName,
            //    ["Locality"] = ClaimTypes.Locality
            //};
            //return result;
        }
    }
}
