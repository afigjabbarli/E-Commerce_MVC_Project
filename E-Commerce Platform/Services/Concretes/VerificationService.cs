using E_Commerce_Platform.DataBase;
using E_Commerce_Platform.Services.Abstracts;
using Org.BouncyCastle.Crypto.Generators;
using System.Text;

namespace E_Commerce_Platform.Services.Concretes
{
    
    
        public class VerificationService : IVerificationService
        {
            private readonly ECommerceDBContext _dbContext;
            private static Random random = new Random();
            private static HashSet<string> usedCodes = new HashSet<string>();

            public VerificationService(ECommerceDBContext dbContext)
            {
                _dbContext = dbContext;
            }

            public string GenerateMembershipPassword()
            {
                const string prefix = "USR";
                const int randomDigitsCount = 5;

                string Password;

                do
                {
                    string randomDigits = GenerateRandomDigits(randomDigitsCount);
                    Password = prefix + randomDigits;
                }
                while (IsUserCodeExists(Password));


               
                MarkPasswordAsUsed(Password);
                return Password;
            }

            private static string GenerateRandomDigits(int count)
            {
                
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < count; i++)
                {
                    int randomNumber = random.Next(10);
                    sb.Append(randomNumber);
                }

                return sb.ToString();
            }

            private bool IsUserCodeExists(string Password)
            {
                return _dbContext.Users.Any(u => u.MembershipPassword == Password);
            }

            private void MarkPasswordAsUsed(string Password)
            {
                usedCodes.Add(Password);
            }
        }
    
}
