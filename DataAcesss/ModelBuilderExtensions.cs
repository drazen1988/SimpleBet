using DataAcesss.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAcesss
{
    public static class ModelBuilderExtensions
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "Admin"
                },
                new IdentityRole()
                {
                    Id = "2",
                    Name = "Korisnik",
                    NormalizedName = "Korisnik"
                }
                );

            modelBuilder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser()
                    {
                        Id = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6",
                        UserName = "KamikazaSKacigom",
                        NormalizedUserName = "KAMIKAZASKACIGOM",
                        Email = "drazen.marinkovic1@gmail.com",
                        NormalizedEmail = "DRAZEN.MARINKOVIC1@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = "AQAAAAEAACcQAAAAELAPlQf8sVUM/Sc31lIipH7sBfuUsCGeZawx2x0YYRl4pDu1viNlCOk4SEiznbNjlw==",
                        SecurityStamp = "QSJGIOPEXML4J3IXUW3PVXBZ7GB5YN46",
                        ConcurrencyStamp = "77dd27c4-8531-4741-9231-2c0d859d0c09",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                        ClanId = 1,
                        FirstName = "Dražen",
                        LastName = "Marinković"
                    }
                    );

            modelBuilder.Entity<Clan>().HasData(
                    new Clan()
                    { 
                        ClanId = 1,
                        ClanName = "Lajbeki",
                        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                    }
                    );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                }
                );
        }

        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Country>().HasData(
            //    new Country()
            //    {
            //        CountryId = 1,
            //        CountryName = "Katar",
            //        CountryCoeficient = 400,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 2,
            //        CountryName = "Ekvador",
            //        CountryCoeficient = 250,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 3,
            //        CountryName = "Senegal",
            //        CountryCoeficient = 80,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 4,
            //        CountryName = "Nizozemska",
            //        CountryCoeficient = 15,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 5,
            //        CountryName = "Engleska",
            //        CountryCoeficient = 8,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 6,
            //        CountryName = "Iran",
            //        CountryCoeficient = 700,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 7,
            //        CountryName = "SAD",
            //        CountryCoeficient = 100,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 8,
            //        CountryName = "Wales",
            //        CountryCoeficient = 150,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 9,
            //        CountryName = "Argentina",
            //        CountryCoeficient = 9,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 10,
            //        CountryName = "Saudijska Arabija",
            //        CountryCoeficient = 999,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 11,
            //        CountryName = "Meksiko",
            //        CountryCoeficient = 150,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 12,
            //        CountryName = "Poljska",
            //        CountryCoeficient = 125,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 13,
            //        CountryName = "Francuska",
            //        CountryCoeficient = 7,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 14,
            //        CountryName = "Australija",
            //        CountryCoeficient = 250,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 15,
            //        CountryName = "Danska",
            //        CountryCoeficient = 40,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 16,
            //        CountryName = "Tunis",
            //        CountryCoeficient = 800,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 17,
            //        CountryName = "Španjolska",
            //        CountryCoeficient = 9,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 18,
            //        CountryName = "Kostarika",
            //        CountryCoeficient = 750,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 19,
            //        CountryName = "Njemačka",
            //        CountryCoeficient = 12,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 20,
            //        CountryName = "Japan",
            //        CountryCoeficient = 400,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 21,
            //        CountryName = "Belgija",
            //        CountryCoeficient = 15,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 22,
            //        CountryName = "Kanada",
            //        CountryCoeficient = 350,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 23,
            //        CountryName = "Maroko",
            //        CountryCoeficient = 450,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 24,
            //        CountryName = "Hrvatska",
            //        CountryCoeficient = 50,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 25,
            //        CountryName = "Brazil",
            //        CountryCoeficient = 5,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 26,
            //        CountryName = "Srbija",
            //        CountryCoeficient = 80,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 27,
            //        CountryName = "Švicarska",
            //        CountryCoeficient = 80,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 28,
            //        CountryName = "Kamerun",
            //        CountryCoeficient = 350,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 29,
            //        CountryName = "Portugal",
            //        CountryCoeficient = 15,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 30,
            //        CountryName = "Gana",
            //        CountryCoeficient = 400,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 31,
            //        CountryName = "Urugvaj",
            //        CountryCoeficient = 60,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    },
            //    new Country()
            //    {
            //        CountryId = 32,
            //        CountryName = "Južna Koreja",
            //        CountryCoeficient = 600,
            //        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
            //    }
            //    );
        }
    }
}
