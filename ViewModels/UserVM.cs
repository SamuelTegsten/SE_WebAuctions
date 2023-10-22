using System;
using WebAuctions.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;


namespace WebAuctions.ViewModels
{
	public class UserVM
	{
		public string Email { get; set; }
		public string UserName { get; set; }
		public List<string> Roles { get; set; }


		public static async Task<UserVM> FromWebAuctionUser(WebAuctionsUser wau, UserManager<WebAuctionsUser> userManager)
		{
			var roles = await userManager.GetRolesAsync(wau);
			return new UserVM()
			{
				Email = wau.Email,
				UserName = wau.UserName,
				Roles = roles.ToList()

			};
		}

	}
	
}

