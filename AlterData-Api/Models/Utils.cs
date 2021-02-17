using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AlterData_Api.Models
{
    public class Utils
    {
        public Utils()
        {

        }

        public void CriptografarSenha(Funcionario funcionario)
        {
            funcionario.Password = Criptografar(funcionario.Password);
        }

        public string Criptografar(string text)
        {
            HashAlgorithm hashing = SHA256.Create();
            StringBuilder stringBuilder = new StringBuilder();

            byte[] hash = hashing.ComputeHash(Encoding.UTF8.GetBytes(text));


            for (int i = 0; i < hash.Length; i++)
            {
                stringBuilder.Append(hash[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
