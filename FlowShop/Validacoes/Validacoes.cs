using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;

namespace FlowShop_INFRA
{
    public static class Validacoes
    {
        public static bool StringValidation(string nome)
        {

            if (Regex.IsMatch(nome, @"^[ a-zA-Z záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EmailValidation(string email)
        {
            if (Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool LinkValidation(string link)
        {
            if (Regex.IsMatch(link, @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
