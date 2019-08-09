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

        //public static bool LinkValidation(string link)
        //{
        //    if (Regex.IsMatch(link, "^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?"))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
