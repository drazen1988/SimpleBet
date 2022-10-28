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
                        UserName = "dmarinkovic",
                        NormalizedUserName = "DMARINKOVIC",
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
                    },
                    new ApplicationUser()
                    {
                        Id = "45a0f303-506b-4a0e-b42f-0b1c814d84f7",
                        UserName = "tberisic",
                        NormalizedUserName = "TBERISIC",
                        Email = "tomislav.berisic@gmail.com",
                        NormalizedEmail = "TOMISLAV.BERISIC@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = "AQAAAAEAACcQAAAAECCRKBsGtZvndBuz9iFwly0sqK8/vI/2GskOb/RMBxQYQXXu/ZUBlmXye+qZ+PMxjg==",
                        SecurityStamp = "QSJGIOPEXML4J3IXUW3PVXBZ7GB5YN46",
                        ConcurrencyStamp = "77dd27c4-8531-4741-9231-2c0d859d0c09",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                        ClanId = 2,
                        FirstName = "Tomislav",
                        LastName = "Berišić"
                    },
                    new ApplicationUser()
                    {
                        Id = "d2b416d1-7861-4d6e-835e-4e1ebc65ce7b",
                        UserName = "korisnik",
                        NormalizedUserName = "KORISNIK",
                        Email = "test@test.com",
                        NormalizedEmail = "TEST@TEST.COM",
                        EmailConfirmed = false,
                        PasswordHash = "AQAAAAEAACcQAAAAECCRKBsGtZvndBuz9iFwly0sqK8/vI/2GskOb/RMBxQYQXXu/ZUBlmXye+qZ+PMxjg==",
                        SecurityStamp = "QSJGIOPEXML4J3IXUW3PVXBZ7GB5YN46",
                        ConcurrencyStamp = "77dd27c4-8531-4741-9231-2c0d859d0c09",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                        ClanId = 2,
                        FirstName = "Pero",
                        LastName = "Perić"
                    }
                    );

            modelBuilder.Entity<Clan>().HasData(
                    new Clan()
                    { 
                        ClanId = 1,
                        ClanName = "HRPRO",
                        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                    },
                    new Clan()
                    {
                        ClanId = 2,
                        ClanName = "Erste",
                        UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                    });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "45a0f303-506b-4a0e-b42f-0b1c814d84f7"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2",
                    UserId = "d2b416d1-7861-4d6e-835e-4e1ebc65ce7b"
                });
        }

        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country()
                {
                    CountryId = 1,
                    CountryName = "Katar",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 2,
                    CountryName = "Ekvador",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 3,
                    CountryName = "Senegal",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 4,
                    CountryName = "Nizozemska",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 5,
                    CountryName = "Engleska",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 6,
                    CountryName = "Iran",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 7,
                    CountryName = "SAD",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 8,
                    CountryName = "Wales",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 9,
                    CountryName = "Argentina",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 10,
                    CountryName = "Saudijska Arabija",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 11,
                    CountryName = "Meksiko",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 12,
                    CountryName = "Poljska",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 13,
                    CountryName = "Francuska",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 14,
                    CountryName = "Australija",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 15,
                    CountryName = "Danska",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 16,
                    CountryName = "Tunis",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 17,
                    CountryName = "Španjolska",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 18,
                    CountryName = "Kostarika",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 19,
                    CountryName = "Njemačka",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 20,
                    CountryName = "Japan",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 21,
                    CountryName = "Belgija",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 22,
                    CountryName = "Kanada",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 23,
                    CountryName = "Maroko",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 24,
                    CountryName = "Hrvatska",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 25,
                    CountryName = "Brazil",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 26,
                    CountryName = "Srbija",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 27,
                    CountryName = "Švicarska",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 28,
                    CountryName = "Kamerun",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 29,
                    CountryName = "Portugal",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 30,
                    CountryName = "Gana",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 31,
                    CountryName = "Urugvaj",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                },
                new Country()
                {
                    CountryId = 32,
                    CountryName = "Južna Koreja",
                    UserId = "4009d724-f1e3-46ab-b58b-ad78a0f8a1f6"
                }
                );
        }
    }
}
