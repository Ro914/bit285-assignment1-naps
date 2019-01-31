using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bit285_assignment1_naps.Models
{
    public class PasswordSuggestionService
    {
        public string generatePassword(User user)
        {
            Random random = new Random();
            string[] keywords = { user.LastName, user.BirthYear, user.FavoriteColor };

            for (int i = 2; i >0; i--){
                int j = random.Next(0, i + 1);
                string temp = keywords[j];
                keywords[j] = keywords[i];
                keywords[i] = temp;

            }

            return string.Concat(keywords[0] + keywords[1] + keywords[2]);
        }
    }
}
